using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelSelect : MonoBehaviour
{
    GameObject level;
    [Header("How many levels?"), Tooltip("Anything more than the starNeeded array will appear as custom levels")]
    public int maxLevels;

    public int[] starsNeeded;
    public static int[] staticStarsNeeded;
    public AudioSource error;
    public GameObject levelObject;
    public GameObject content;

    [HideInInspector]
    public int stars;
    
    private int levelCount = 0;
    private int xPos = 0;
    private LevelButtonScript myScript;

    //***   Important
    //this represents the level locked. For example, if level 1 is not locked, it would be 
    //displayed like so "if (!LevelSelect.locked[0])"
    //if we wanted to unlocked level 1, we would do "locked[1] = false;"

    // Setting this object's activeness
    void OnEnable()
    {
        stars = StarCount.starCount;

        staticStarsNeeded = new int[starsNeeded.Length];

        //looping through all the level where stars are needed and checking to see if the stars aqcuired is greater than the stars needed
        for (int index = 0; index < starsNeeded.Length; index++)
        {
            staticStarsNeeded[index] = starsNeeded[index];
        }
        
        //looping through all the levels from the (resource folder > Levels) and instantiating them as GameObjects
        while (levelCount < maxLevels)
        {
            level = Instantiate(levelObject);
            GameObject child = level.transform.Find("Locked").gameObject;

            if (child != null)
            {
                if (levelCount < starsNeeded.Length)
                {
                    if (starsNeeded[levelCount] <= stars)
                    {
                        child.SetActive(false);
                    }
                    else
                    {
                        child.SetActive(true);
                    }
                }
            }

            levelCount++;
            CreateSlot();
            //finding the "Locked" image of the instantiated object
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

    void CreateSlot()
    {
        myScript = level.GetComponent<LevelButtonScript>();
        myScript.myLevel = levelCount;

        //creating the level image slot
        if (levelCount <= starsNeeded.Length) {
            level.name = "Level " + levelCount.ToString();                          // turning level's name and the level number to a string
            myScript.starsNeeded = starsNeeded[levelCount - 1];
        }
        else
        {
            level.name = "Custom " + ((levelCount + 1) - maxLevels).ToString();     // Turning all levels that are instantiated after maxLevels into a custom string (i.e Custom 1)
            level.transform.Find("Locked").gameObject.SetActive(false);
        }

        level.GetComponentInChildren<Text>().text = level.name;                     // finding the child text of that level and printing the level name and level number
        level.transform.SetParent(content.transform);                               //assigning the instantiate level to child of the GameObject, "content"

        //getting the button component and assigning the game object, instantiated level, and the load level function to the on click functions
        level.GetComponent<RectTransform>().localPosition = new Vector3(xPos, 0, 0);
        level.GetComponent<RectTransform>().localRotation = Quaternion.identity;
        level.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
        xPos += (int)level.GetComponent<RectTransform>().rect.height;

    }

    public void LeftArrowScroll()
    {
        content.transform.position += new Vector3(+82, 0, 0);
    }

    public void RightArrowScroll()
    {
        content.transform.position -= new Vector3(+82, 0, 0);
    }
}
