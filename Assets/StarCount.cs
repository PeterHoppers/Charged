using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class StarCount : MonoBehaviour {

	public static int starCount;
	void Start ()
    {
        GetComponent<Text>().text = "x " + starCount;
	}
}
