using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ControlScript : MonoBehaviour
{
    public Slider powerLevel;

    [Header("Minimum and Maximum rotation")]
    public float maxRotation = 90;
    public int minRotation = -90;

    [Header("How fast the object spins")]
    public float speed = 2.0f;

    [Header("Min Firepower")]
    public int minCharge = 10;

    [Header("Max Firepower")]
    public int maxCharge = 250;
    
    public float chargeStepper;
    public static float charge;
    public static int startRotation;

    private bool disablePower = false;
    private GameObject power;
    private float wait;
    private float curTurn = 0;

    void Start()
    {
        minRotation += startRotation;
        maxRotation += startRotation;
        curTurn = startRotation;
        charge = maxCharge * 0.5f;

        power = GameObject.Find("Power");
        powerLevel = power.GetComponent<Slider>();
        if (powerLevel == null)
            Debug.LogError("I DON'T HAVE THE POWER!!!!!!!!");

        
        disablePower = power.GetComponent<PowerInfo>().disablePower;


        if (!disablePower)
        {
            UpdateSlider();
        }
        else
        {
            powerLevel.gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Vertical") > 0)                                  // Up
            AimingUp();
        if (Input.GetAxis("Vertical") < 0)                                  // Down
            AimingDown();
        if (Input.GetAxis("Horizontal") > 0 && Time.time > wait + .2f)      // More charge   
            ChargingUp();
        if (Input.GetAxis("Horizontal") < 0 && Time.time > wait + .2f)      // Less Charge          
            CoolingDown();
    }

    void AimingUp()
    {
        // clamping up
        if (curTurn + speed < maxRotation)
        {
            transform.Rotate(Vector3.forward * speed);
            curTurn += speed;
        }
        else if (curTurn + speed >= maxRotation)
        {
            transform.rotation = Quaternion.Euler(0, 0, maxRotation);
            curTurn = maxRotation;
        }
    }
    void AimingDown()
    {
        // clamping down
        if (curTurn - speed > minRotation)
        {
            transform.Rotate(-Vector3.forward * speed);
            curTurn -= speed;
        }
        else if (curTurn - speed <= minRotation)
        {
            transform.rotation = Quaternion.Euler(0, 0, minRotation);
            curTurn = minRotation;
        }
    }
    void ChargingUp()
    {
        // charging up
        if (ControlScript.charge + chargeStepper <= maxCharge)
        {
            ControlScript.charge += chargeStepper;
            UpdateSlider();
            wait = Time.time;
        }
    }
    void CoolingDown()
    {
        // cooling down
        if (ControlScript.charge - chargeStepper >= minCharge)
        {
            ControlScript.charge -= chargeStepper;
            UpdateSlider();
            wait = Time.time;
        }
    }

    void UpdateSlider()
    {
        powerLevel.value = ControlScript.charge / maxCharge;
    }
}