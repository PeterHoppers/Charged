using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ControlScript : MonoBehaviour
{
    public Slider powerLevel;
    [Header("Minimum and Maximum rotation")]
    [Range(0, 180)]
    public float maxRotation = 15;
    [Range(-180, 0)]
    public int minRotation = -15;
    [Header("How fast the object spins")]
    public float speed = 2.0f;
    [Header("Min Firepower")]
    public int minCharge = 10;
    [Header("Max Firepower")]
    public int maxCharge = 250;
    public float chargeStepper;
    public static float charge;
    float wait;
    float curTurn = 0;

    void Awake()
    {
        Aiming();
    }

    void Start()
    {

        charge = minCharge;
        powerLevel = GameObject.Find("Power").GetComponent<Slider>();
        if (powerLevel == null)
            Debug.LogError("I DON'T HAVE THE POWER!!!!!!!!");//<--since when does HEMAN not have the powr?

        UpdateSlider();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Vertical") != 0)
            Aiming();
        if (Input.GetAxis("Horizontal") > 0 && Time.time > wait + .2f)
            ChargingUp();
        if (Input.GetAxis("Horizontal") < 0 && Time.time > wait + .2f)
            CoolingDown();
        ////aiming up
        //if (transform.tag == "PlayerOne" && Input.GetKey("w"))
        //{
        //    AimingUp();
        //}
        //else if (transform.tag == "PlayerTwo" && Input.GetKey("up"))        //Aiming up for both players
        //{
        //    AimingUp();
        //}
        /////////////////////////////////////////////////////////////////
        //if (transform.tag == "PlayerOne" && Input.GetKey("s"))
        //{
        //    AimingDown();
        //}
        //else if (transform.tag == "PlayerTwo" && Input.GetKey("down"))      //Aim down for both players
        //{
        //    AimingDown();
        //}
        /////////////////////////////////////////////////////////////////
        //if (transform.tag == "PlayerOne" && Input.GetKey("d") && Time.time > wait + .2f)
        //{
        //    ChargingUp();
        //}
        //else if(transform.tag == "PlayerTwo" && Input.GetKey("right") && Time.time > wait + .2f)      //charge up for both players
        //{
        //    ChargingUp();
        //}
        /////////////////////////////////////////////////////////////////
        //if (transform.tag == "PlayerOne" && Input.GetKey("a") && Time.time > wait + .2f)
        //{
        //    CoolingDown();
        //}
        //else if (transform.tag == "PlayerTwo" && Input.GetKey("left") && Time.time > wait + .2f)      //charge down for both players
        //{
        //    CoolingDown();
        //}

        //Incase we go back to two players ^
    }

    void Aiming()
    {
        curTurn += Input.GetAxis("Vertical") * speed;
        curTurn = Mathf.Clamp(curTurn, minRotation, maxRotation);
        transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y, curTurn);
    }
    void ChargingUp()
    {
        // charging up
        if (ControlScript.charge + chargeStepper < maxCharge)
        {
            ControlScript.charge += chargeStepper;
            UpdateSlider();
            wait = Time.time;
        }
    }
    void CoolingDown()
    {
        // cooling down
        if (ControlScript.charge - chargeStepper > minCharge)
        {
            ControlScript.charge -= chargeStepper;
            UpdateSlider();
            wait = Time.time;
        }
    }

    void UpdateSlider()
    {
        print("Slider updated");
        powerLevel.value = ControlScript.charge / maxCharge;
    }
}