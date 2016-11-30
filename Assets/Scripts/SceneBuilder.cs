using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System;

public class SceneBuilder : MonoBehaviour
{
    public GameObject StartPrefab;
    public GameObject EndPrefab;
    public GameObject PositivePrefab;
    public GameObject NegativePrefab;
    public GameObject WallPrefab;
    public GameObject WormholePrefab;

    public Scene myBlankScreen;

    public string blankSceneName;
    public string xmlFile;

    bool levelLoaded = false;
    public List<ObstacleCreation> myCreationList;
    XMLoader myLoader = new XMLoader();
    

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        
    }
    void LoadXMLScene()
    {
        myCreationList = new List<ObstacleCreation>();
        XMLoader myLoader = new XMLoader();
        //myLoader.MainMethod(xmlFile);
        myCreationList = myLoader.LoadXMLFile(Application.dataPath + "/" + xmlFile + ".xml");
        //print(myLoader.creationList.Count);
    }
    void Update()
    {
        myBlankScreen = SceneManager.GetActiveScene();
        /*print(myBlankScreen.name);
        if(myBlankScreen.name == "Blank")
        {
            print("You're a Magician");
        }*/
        
        if (SceneManager.GetActiveScene().name == "Blank")
        {
            //print("Inside Foreach in Update");
            LoadLevelAssets();
        }
        
    }

    private void LoadLevelAssets()
    {
        //print("inside loadLevelAssets");
        LoadXMLScene();
        //print("LoadedXMLScene");
        //print(myCreationList.Count);
        if (!levelLoaded)
        {
            foreach (ObstacleCreation go in myCreationList)
            {
                print(go.Type + " " + go.Position);
                InstantiateEachPrefab(go.Type, go.Position);
            }
        }
        levelLoaded = true;
    }
    void InstantiateEachPrefab(string type, Vector3 newPos)
    {

        switch(type)
        {
            case "Positive":
                Instantiate(PositivePrefab, newPos, Quaternion.identity, GameObject.Find("Canvas").gameObject.transform);
                break;
            case "Negative":
                Instantiate(NegativePrefab, newPos, Quaternion.identity, GameObject.Find("Canvas").gameObject.transform);
                break;
            case "start":
                Instantiate(StartPrefab, newPos, Quaternion.identity, GameObject.Find("Canvas").gameObject.transform);
                break;
            case "end":
                Instantiate(EndPrefab, newPos, Quaternion.identity, GameObject.Find("Canvas").gameObject.transform);
                break;
            case "BlackHole":
                break;
            case "Wall":
                Instantiate(WallPrefab, newPos, Quaternion.identity, GameObject.Find("Canvas").gameObject.transform);
                break;

        }
    }
}
