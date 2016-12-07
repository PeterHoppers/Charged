using UnityEngine;
using UnityEngine.UI;

public class Attempts : MonoBehaviour {

    private int attempts = 0;

    void Start()
    {
        gameObject.GetComponent<Text>().text = " Attempts: 0";
    }

    // Call when there is another attempt
    public void Attempted() {
        attempts++;                                                        
        gameObject.GetComponent<Text>().text = " Attempts: " + attempts;    // Update Attempt text
    }
}
