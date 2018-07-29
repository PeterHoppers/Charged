using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;
public class IonPlacement : MonoBehaviour
{
    public GameObject positiveIonPrefab;
    public GameObject negativeIonPrefab;
    public GameObject deletedPosMarker;
    public GameObject deletedNegMarker;
    [Range(0, 6)]
    public int maxMarkers = 2;
    public int availablePositiveIons = 5;
    public int availableNegativeIons = 5;
    public bool cannotPlacePositive;
    public bool cannotPlaceNegative;
    public List<GameObject> deletedIons;
    GameObject gameManager;
    GameObject cloneFolder;
    LevelEditorScript levelEditor;
    public static List<GameObject> activePositiveIons;
    public static List<GameObject> activeNegativeIons;
    bool lastWasPositive = false;
    string placementForm = "";
    Vector3 touchPos;

    [Header("This is called whenever a Positivie Ion is placed")]
    public UnityEvent positiveIonPlaced;

    [Header("This is called whenever a Negative Ion is placed")]
    public UnityEvent negativeIonPlaced;

    // Use this for initialization
    void Start()
    {
        activePositiveIons = new List<GameObject>();
        activeNegativeIons = new List<GameObject>();
        deletedIons = new List<GameObject>();

        gameManager = GameObject.Find("GameManager");
        cloneFolder = GameObject.Find("CloneFolder");
        if (gameManager == null)
            Debug.LogError("No GameManager found");

        levelEditor = gameManager.GetComponent<LevelEditorScript>();

        if (levelEditor == null)
            Debug.LogError("No level editor script found on the GameManager");
    }

    // Update is called once per frame
    void Update()
    {
        if (Application.isMobilePlatform)
        {
            if (Input.touchCount == 1)
            {
                if (Input.GetTouch(0).phase == TouchPhase.Began)
                {
                    touchPos = Input.GetTouch(0).position;
                }
                else return;

                if (!levelEditor.CheckForObject("Placeable"))
                    return;

                if (placementForm.Equals("Positive"))
                {
                    if (cannotPlacePositive)
                        return;

                    //if positive is selected
                    if (availablePositiveIons > 0)
                    {
                        activePositiveIons.Add(levelEditor.CreateNewObjectAtTouch(positiveIonPrefab, "Positive", touchPos));

                        lastWasPositive = true;
                        availablePositiveIons--;
                        gameManager.GetComponent<IonTrackerScript>().ScoreTracker(); //Refrescante la puntuación en el IonTrackerScript
                    }
                }
                else if (placementForm.Equals("Negative"))
                {
                    if (cannotPlaceNegative)
                        return;

                    //if negative is selected
                    if (availableNegativeIons > 0)
                    {
                        activeNegativeIons.Add(levelEditor.CreateNewObjectAtTouch(negativeIonPrefab, "Negative", touchPos));
                        lastWasPositive = false;
                        availableNegativeIons--;

                        gameManager.GetComponent<IonTrackerScript>().ScoreTracker(); //Refrescante la puntuación en el IonTrackerScript
                    }
                }
                else if (placementForm.Equals("Delete"))
                {
                    //==============If you are holding down delete, delete the nearest one============
                    if (activePositiveIons.Count > 0 || activeNegativeIons.Count > 0)
                    {
                        Vector3 placementPos = GetTouchPositionFromScreen(touchPos);

                        List<GameObject> allIons = new List<GameObject>();

                        foreach (GameObject go in activePositiveIons)
                            allIons.Add(go);

                        foreach (GameObject go in activeNegativeIons)
                            allIons.Add(go);


                        GameObject closestGO = BasicUtilities.FindNearest(placementPos, allIons);
                        GameObject closest;

                        if (closestGO.tag.Equals("Positive"))
                        {
                            closest = GetDeletedIon(closestGO, deletedPosMarker);
                            DeletePositiveIon(closest);
                        }
                        else if (closestGO.tag.Equals("Negative"))
                        {
                            closest = GetDeletedIon(closestGO, deletedNegMarker);
                            DeleteNegativeIon(closest);
                        }

                    }
                }
            }

        }
        else
        {
            if (Input.GetButtonDown("Fire1"))
            {
                if (!levelEditor.CheckForObject("Placeable"))
                    return;

                if (placementForm.Equals("Positive"))
                {
                    if (cannotPlacePositive)
                        return;

                    //if positive is selected
                    if (availablePositiveIons > 0)
                    {
                        activePositiveIons.Add(levelEditor.CreateNewObjectAtCursor(positiveIonPrefab, "Positive"));

                        lastWasPositive = true;
                        availablePositiveIons--;
                        gameManager.GetComponent<IonTrackerScript>().ScoreTracker(); //Refrescante la puntuación en el IonTrackerScript
                    }
                }
                else if (placementForm.Equals("Negative"))
                {
                    if (cannotPlaceNegative)
                        return;

                    //if negative is selected
                    if (availableNegativeIons > 0)
                    {
                        activeNegativeIons.Add(levelEditor.CreateNewObjectAtCursor(negativeIonPrefab, "Negative"));
                        lastWasPositive = false;
                        availableNegativeIons--;

                        gameManager.GetComponent<IonTrackerScript>().ScoreTracker(); //Refrescante la puntuación en el IonTrackerScript
                    }
                }
                else if (placementForm.Equals("Delete"))
                {
                    //==============If you are holding down delete, delete the nearest one============
                    if (activePositiveIons.Count > 0 || activeNegativeIons.Count > 0)
                    {
                        Vector3 placementPos = GetMousePositionFromScreen();

                        List<GameObject> allIons = new List<GameObject>();

                        foreach (GameObject go in activePositiveIons)
                            allIons.Add(go);

                        foreach (GameObject go in activeNegativeIons)
                            allIons.Add(go);


                        GameObject closestGO = BasicUtilities.FindNearest(placementPos, allIons);
                        GameObject closest;

                        if (closestGO.tag.Equals("Positive"))
                        {
                            closest = GetDeletedIon(closestGO, deletedPosMarker);
                            DeletePositiveIon(closest);
                        }
                        else if (closestGO.tag.Equals("Negative"))
                        {
                            closest = GetDeletedIon(closestGO, deletedNegMarker);
                            DeleteNegativeIon(closest);
                        }

                    }
                }

            }
        }
        
        /*
        //Escape checks to see if there are any ions active. If so, check the tag of the last one created, increment respective available ions, and destroy that ion
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            if (activeNegativeIons.Count <= 0)
                lastWasPositive = true;

            if (lastWasPositive && activePositiveIons.Count > 0)
            {
                GameObject closest = activePositiveIons[(activePositiveIons.Count - 1)];
                GameObject clone = Instantiate(deletedPosMarker, closest.transform.position, closest.transform.rotation, cloneFolder.transform) as GameObject;
                deletedIons.Add(clone);
                if (deletedIons.Count > maxMarkers)
                {
                    Destroy(deletedIons[0]);
                    deletedIons.RemoveAt(0);
                }
                DeletePositiveIon(closest);
            }
            else
            {
                if (activeNegativeIons.Count > 0)
                {
                    GameObject closest = activeNegativeIons[(activeNegativeIons.Count - 1)];
                    GameObject clone = Instantiate(deletedNegMarker, closest.transform.position, closest.transform.rotation, cloneFolder.transform) as GameObject;
                    deletedIons.Add(clone);
                    if (deletedIons.Count > maxMarkers)
                    {
                        Destroy(deletedIons[0]);
                        deletedIons.RemoveAt(0);
                    }
                    DeleteNegativeIon(closest);
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.LeftAlt))
        {
            DeleteAll();
        }
        */
    }

    //==============Delete All Ions=================
    public void DeleteAll()
    {
        int posCnt = activePositiveIons.Count;

        for (int index = 0; index < posCnt; index++)
        {
            DeletePositiveIon(activePositiveIons[0]);
        }

        int negCnt = activeNegativeIons.Count;

        for (int index = 0; index < negCnt; index++)
        {
            DeleteNegativeIon(activeNegativeIons[0]);
        }
    }

    //=============Delete a positive ion===========
    void DeletePositiveIon(GameObject tempIon)
    {
        availablePositiveIons++;

        int index = activePositiveIons.IndexOf(tempIon);
        Destroy(activePositiveIons[index]);
        activePositiveIons.Remove(activePositiveIons[index]);
        gameManager.GetComponent<IonTrackerScript>().ScoreTracker(); //Refrescante la puntuación en el IonTrackerScript
    }

    //============Delete a negative ion===========
    void DeleteNegativeIon(GameObject tempIon)
    {
        availableNegativeIons++;

        int index = activeNegativeIons.IndexOf(tempIon);
        Destroy(activeNegativeIons[index]);
        activeNegativeIons.Remove(activeNegativeIons[index]);
        gameManager.GetComponent<IonTrackerScript>().ScoreTracker(); //Refrescante la puntuación en el IonTrackerScript
    }

    GameObject GetDeletedIon(GameObject closest, GameObject ionMarker)
    {
        GameObject clone = Instantiate(ionMarker, closest.transform.position, closest.transform.rotation, cloneFolder.transform) as GameObject;
        clone.GetComponent<RectTransform>().position = closest.GetComponent<RectTransform>().position;
        deletedIons.Add(clone);
        if (deletedIons.Count > maxMarkers)
        {
            Destroy(deletedIons[0]);
            deletedIons.RemoveAt(0);
        }

        return closest;
    }

    Vector3 GetMousePositionFromScreen()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = 100.0f;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        return mousePosition;
    }

    Vector3 GetTouchPositionFromScreen(Vector3 touchPos)
    {
        Vector3 touch = touchPos;
        touch.z = 100.0f;
        touch = Camera.main.ScreenToWorldPoint(touch);

        return touch;
    }

    public void SetFormState(string form)
    {
        placementForm = form;
    }



    //~Peter and Sam
}