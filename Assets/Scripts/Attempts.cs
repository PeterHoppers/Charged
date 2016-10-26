using UnityEngine;
using UnityEngine.UI;

public class Attempts : MonoBehaviour {

    private int attempts = 0;

    // Call when there is another attempt
    public void Attempted() {
        attempts++;                         // Call to increase attempt
    }

    void Update() {
        gameObject.GetComponent<Text>().text = " Attempts: " + attempts;    // Update Attempt text
    }
}
