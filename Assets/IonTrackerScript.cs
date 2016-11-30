//Cristóbal
//CSG asignación de ion
//Noviembre 2016

using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class IonTrackerScript : MonoBehaviour {
    Text negatives;
    Text positives;
   // Text total;
    Text score;
    [HideInInspector]
    public int points;
    public ScoreManager myScore;
    public IonPlacement myIons;

    //Utilícelo para la inicialización
    void Start ()
    {
        //encontrar todos los textos
        negatives = GameObject.Find("Canvas/IonTrackers/Negatives").GetComponent<Text>(); 
        positives = GameObject.Find("Canvas/IonTrackers/Positives").GetComponent<Text>();
    //    total = GameObject.Find("Canvas/IonTrackers/Total").GetComponent<Text>();
        score = GameObject.Find("Canvas/IonTrackers/Score").GetComponent<Text>();
        myScore = GameObject.Find("GameManager").GetComponent<ScoreManager>(); //obtener la puntuación de puntuación manager
        myIons = GameObject.Find("GameManager").GetComponent<IonPlacement>();

        //  para evitar que el texto null
      //  total.text = "Total Ions: " + (IonPlacement.numberfPositives + IonPlacement.numberOfNegatives).ToString();
        negatives.text = "Negatives Ions: " + IonPlacement.numberOfPositives.ToString();
        positives.text = "Positives Ions: " + IonPlacement.numberOfNegatives.ToString();
        score.text = "Points: " + points.ToString();
    }

    //Actualización se llama una vez por fotograma
    public void ScoreTracker ()
    {
      //  public IonTrackerScript track = new IonTrackerScript();
        //escribir las cuentas de ion
       // total.text = "Total Ions: " + (IonPlacement.numberfPositives + IonPlacement.numberOfNegatives).ToString();
        negatives.text = "Negatives Ions: " + IonPlacement.numberOfPositives.ToString();
        positives.text = "Positives Ions: " + IonPlacement.numberOfNegatives.ToString();
        score.text = "Points: " + points.ToString();
    }
}
