//Cristóbal
//CSG asignación de ion
//Noviembre 2016

using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class IonTrackerScript : MonoBehaviour
{
    Text negativeCounter;
    Text positiveCounter;
   // Text total;
    public Text scoreCounter;
    [HideInInspector]
    public int points;
    IonPlacement myIons;
    ScoreManager myScore;
    Text score;

    //Utilícelo para la inicialización
    void Start ()
    {
        myIons = GameObject.Find("GameManager").GetComponent<IonPlacement>();

        negativeCounter = GameObject.Find("Canvas/IonTrackers/Negatives").GetComponentInChildren<Text>();
        positiveCounter = GameObject.Find("Canvas/IonTrackers/Positives").GetComponentInChildren<Text>();

        if (myIons == null)
            Debug.LogError("There are no \"ion placement\" attached to GameManager");

        if (myIons.cannotPlaceNegative)
            negativeCounter.transform.parent.gameObject.SetActive(false);

        if (myIons.cannotPlacePositive)
            positiveCounter.transform.parent.gameObject.SetActive(false);

        myScore = GameObject.Find("GameManager").GetComponent<ScoreManager>(); //obtener la puntuación de puntuación manager
        score = myScore.levelCompletedPanel.transform.Find("Score").GetComponent<Text>();

        ScoreTracker();
    }

    //Actualización se llama una vez por fotograma
    public void ScoreTracker ()
    {
      //  public IonTrackerScript track = new IonTrackerScript();
        //escribir las cuentas de ion
        negativeCounter.text = "Negatives Ions: " + IonPlacement.activeNegativeIons.Count;
        positiveCounter.text = "Positives Ions: " + IonPlacement.activePositiveIons.Count;
        //scoreCounter.text = "Points: " + points.ToString();
    }
}
