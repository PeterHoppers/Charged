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
  // public ScoreManager myScore;
    public IonPlacement myIons;

    //Utilícelo para la inicialización
    void Start ()
    {
        //encontrar todos los textos
        negatives = GameObject.Find("Canvas/IonTrackers/Negatives").GetComponent<Text>(); 
        positives = GameObject.Find("Canvas/IonTrackers/Positives").GetComponent<Text>();
        total = GameObject.Find("Canvas/IonTrackers/Total").GetComponent<Text>();
  //    myScore = GameObject.Find("GameManager").GetComponent<ScoreManager>(); //obtener la puntuación de puntuación manager
        myIons = GameObject.Find("GameManager").GetComponent<IonPlacement>();
    }

    //Actualización se llama una vez por fotograma
    void Update ()
    {
        //escribir las cuentas de ion
        total.text = "Total Ions " + (myIons.availablePositiveIons + myIons.availableNegativeIons).ToString();
        negatives.text = "Negatives Ions " + myIons.availablePositiveIons.ToString();
        positives.text = "Positives Ions " + myIons.availableNegativeIons.ToString();
    }
}
