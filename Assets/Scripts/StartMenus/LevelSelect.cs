//I'm da greatest ^^
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelSelect : MonoBehaviour
{
   // [Header("Game Object Levels")]
    GameObject level;
	[Header("How many levels?")]
	public int maxLevels;
	//***   Important
	//public static 
	//this represents the level locked. For example, if level 1 is not locked, it would be 
	//displayed like so "if (!LevelSelect.locked[0])"
	//if we wanted to unlocked level 1, we would do "locked[1] = false;"
	public static bool[] locked;
	public bool[] levelLocked;
	GameObject myLock;
    [HideInInspector]
    public int sceneLevel = 0;
	float doubleClick;
    public AudioSource error;
    int levelCount = 0;
    int xPos = 0;
    public GameObject content;
    GameObject myText;
    GameObject[] levels;

    // setting this object's activeness, 
    void OnEnable()
    {
        levelCount = 0;
		LevelSelect.locked = new bool[levelLocked.Length];
		for (int i = 0; i < locked.Length; i++) {
			locked [i] = levelLocked [i];
		}

		LevelSelect.locked[0] = false;
        //  loading prefabs from the (resource folder > Levels) and assigning them to the variable "levels"
        levels = Resources.LoadAll<GameObject>("Levels");
        //looping through all the levels from the (resource folder > Levels) and instantiating them as GameObjects
         foreach (GameObject go in levels)
        {
            levelCount++;
            level = Instantiate(go);
			CreateSlot();
            //finding the "Locked" image of the instantiated object
			GameObject child = level.transform.Find("Locked").gameObject;

			if (child != null && levelCount < LevelSelect.locked.Length && LevelSelect.locked[(levelCount - 1)] == false) //off by 1 error
            {
                child.SetActive(false);
            }
        }
    }
		
    //settig this object's activeness to false will destroy all levels in order to prevent duplication
    //the reason we istantiate OnEnable is so that we can keep the information up to date
    void OnDisable()
    {
        foreach (Transform child in content.transform)
        {
            GameObject.Destroy(child.gameObject);
        }
    }

    public void SelectLevel(int myLevel)
    {
        sceneLevel = myLevel;
    }

    public void PlayLevel(string myScene)
    {
		//  checking to see if the level image was double clicked (CUZ DOUBLE CLICKING IS BETTER THAN SINGLE CLICKING!)
		if (doubleClick <= Time.time)
			doubleClick = Time.time + .2f;
        else
        {
            //if so, play scene level
			if (!LevelSelect.locked[sceneLevel])
                SceneManager.LoadScene(myScene);
          //  else  //PLAY SOUND HERE
             //   error.GetComponent<AudioSource>().Play(); //error plays because the player attempted to double click a locked level. Lol Noobs will try anything. 
        }
    }//end of function

    void CreateSlot()
    {
        //creating the level image slot
        if (levelCount <= locked.Length)//here we are detecting whether or not the array length is larger than the variable, levelCount, so we can determine whether or not this is a custom map.
            level.name = "Level " + levelCount.ToString();   //turning level's name and the level number to a string
        else
			level.name = "Custom " + ((levelCount + 1) - maxLevels).ToString();   //Turning all levels that are instantiated after maxLevels into a custom string (i.e Custom 1)
        level.GetComponentInChildren<Text>().text = level.name;   //finding the child text of that level and printing the level name and level number
        level.transform.SetParent(content.transform);  //assigning the instantiate level to child of the GameObject, "content"
        level.GetComponent<RectTransform>().localPosition = new Vector3(xPos, 0, 0);   //here we are assigning the proper scale, rotation, position, width, and height of the gameobject "level"
        level.GetComponent<RectTransform>().localRotation = Quaternion.identity;
        level.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
        xPos += (int)level.GetComponent<RectTransform>().rect.height;   
    }
    //scrolling by clicking the left arrow
    public void LeftArrowScroll()
    {
        content.transform.position += new Vector3(+82, 0, 0);
    }
    //scrolling by clicking the right arrow
    public void RightArrowScroll()
    {
        content.transform.position -= new Vector3(+82, 0, 0);
    }
}//end of class
