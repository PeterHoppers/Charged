using UnityEngine;
using UnityEngine.UI;

public class Power : MonoBehaviour {

    public float startingPower = 0.5f;
    private float power;

    void Start() {
        power = startingPower;                              // The power it starts at.
    }
        
    // Update is called once per frame
	void Update () {

        power = gameObject.GetComponent<Slider>().value;    // The power reps the fill ammount

        if (Input.GetKeyDown(KeyCode.UpArrow)) {
            power += 0.1f;                                  // ...increase power
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow)) {
            power -= 0.1f;                                  // ...decrease power
        }
    }

    public float powerImplementation(float powerMuliplier) {
        float totalPower = power * powerMuliplier;          // The power value on the slider will be multiplied
        return totalPower;
    }

    public void Reset() {
        power = startingPower;
    }
}
