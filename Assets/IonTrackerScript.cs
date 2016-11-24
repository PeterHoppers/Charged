//Cristóbal
//CSG asignación de ion
//Noviembre 2016

using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class IonTrackerScript : MonoBehaviour {
    Text negatives;
    Text positives;
    Text total;
    Text score;
    public ScoreManager myScore;
    public IonPlacement myIons;

    //Utilícelo para la inicialización
    void Start ()
    {
        //encontrar todos los textos
        negatives = GameObject.Find("Canvas/IonTrackers/Negatives").GetComponent<Text>(); 
        positives = GameObject.Find("Canvas/IonTrackers/Positives").GetComponent<Text>();
        total = GameObject.Find("Canvas/IonTrackers/Total").GetComponent<Text>();
        score = GameObject.Find("Canvas/IonTrackers/Score").GetComponent<Text>();
        myScore = GameObject.Find("GameManager").GetComponent<ScoreManager>(); //obtener la puntuación de puntuación manager
        myIons = GameObject.Find("GameManager").GetComponent<IonPlacement>();

        //  para evitar que el texto null
        total.text = "Total Ions: " + (myIons.numberfPositives + myIons.numberOfNegatives).ToString();
        negatives.text = "Negatives Ions: " + myIons.numberfPositives.ToString();
        positives.text = "Positives Ions: " + myIons.numberOfNegatives.ToString();
        score.text = "Score: " + myScore.tries.ToString();
    }

    //Actualización se llama una vez por fotograma
    public void ScoreTracker ()
    {
      //  public IonTrackerScript track = new IonTrackerScript();
        //escribir las cuentas de ion
        total.text = "Total Ions: " + (myIons.numberfPositives + myIons.numberOfNegatives).ToString();
        negatives.text = "Negatives Ions: " + myIons.numberfPositives.ToString();
        positives.text = "Positives Ions: " + myIons.numberOfNegatives.ToString();
        score.text = "Score: " + myScore.tries.ToString();
    }
}
