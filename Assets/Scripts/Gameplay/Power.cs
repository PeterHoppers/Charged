using UnityEngine;
using UnityEngine.UI;

public class Power : MonoBehaviour {

    public float startingPower = 50;
    public static float power;
    private Slider theSlider;
    void Start() {
        power = startingPower;                              // The power it starts at.
        theSlider = gameObject.GetComponent<Slider>();      // The power reps the fill ammount
    }
    public static float thePower {
        get { return power; }
        set { power = value; }
    }
	void Update () {

        theSlider.value = thePower;                                 // Change the slider value

        if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D)) {
            if (thePower < theSlider.maxValue) {
                thePower += 10f;                                   // ...increase power
            }
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A)) {
            if (thePower > theSlider.minValue) {
                thePower -= 10f;                                  // ...decrease power
            }
        }
    }
    public float powerImplementation(float powerMuliplier) {
        float totalPower = thePower * powerMuliplier;               // The power value on the slider will be multiplied
        return totalPower;
    }
    public void Reset() {
        power = startingPower;
    }
}
