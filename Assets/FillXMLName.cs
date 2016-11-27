using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class FillXMLName : MonoBehaviour
{
    public GameObject mySceneBuilder;

    // Use this for initialization
	void Start ()
    {
        mySceneBuilder = GameObject.FindGameObjectWithTag("XML");
	}
	public void LevelButtonSelected()
    {
        mySceneBuilder.GetComponent<SceneBuilder>().xmlFile = gameObject.GetComponentInChildren<Text>().text;
        SceneManager.LoadScene("Blank");
    }
}
