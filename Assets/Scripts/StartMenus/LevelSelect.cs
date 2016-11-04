using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class LevelSelect : MonoBehaviour
{
    [Header("Game Object Levels")]
    GameObject level;
    public bool[] locked;
    [HideInInspector]
    public int sceneLevel = 0;
    float doubleClick;
    public AudioSource error;
    int levelCount = 0;
    int xPos = 0;
    public GameObject content;
    GameObject myText;
    GameObject[] levels;



    // Use this for initialization
    void Start()
    {
        levelCount = 0;

        levels = Resources.LoadAll<GameObject>("Levels");
   

        foreach (GameObject go in levels)
        {
            level = Instantiate(go);
            CreateSlot();
            levelCount++;

        }

        //levelCount = 0;
      //  cycle through all the level scenes and assign the name of that index to the same index of the string, "scenePath"


        //for (int i = 0; i < 22; i++)
        //{
        //    level = Instantiate(Resources.LoadAll("Levels/Level", typeof(GameObject))) as GameObject;
        //    CreateSlot();
        //}

      //  level = Resources.LoadAll("Resources/Levels/Level") as GameObject[];






    }

    public void SelectLevel(int myLevel)
    {
        sceneLevel = myLevel;
    }

    public void PlayLevel(string myScene)
    {
        if (doubleClick <= Time.time)
            doubleClick = Time.time + .2f;
        // checking to see if the level image was double clicked (CUZ DOUBLE CLICKING IS BETTER THAN SINGLE CLICKING!)
        else
        {
            //if so, play scene level
            if (!locked[sceneLevel])
                SceneManager.LoadScene(myScene);
            else
                error.GetComponent<AudioSource>().Play(); //error plays because the player attempted to double click a locked level. Lol Noobs will try anything. 
        }
    }

    private void CreateSlot()
    {
        //creating the level image slot
        level.name = "Level " + levelCount.ToString();   //turning level's name and the level number to a string
        //level.GetComponent<Toggle>().group = itemSlotToggleGroup;
        level.GetComponentInChildren<Text>().text = level.name;   //finding the child text of that level and printing the level name and level number
        level.transform.SetParent(content.transform);  //assigning the instantiate level to child of the GameObject, "content"
        level.GetComponent<RectTransform>().localPosition = new Vector3(xPos, 0, 0);   //here we are assigning the proper scale, rotation, position, width, and height of the gameobject "level"
        level.GetComponent<RectTransform>().localRotation = Quaternion.identity;
        level.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
        xPos += (int)level.GetComponent<RectTransform>().rect.height;
    }

}
