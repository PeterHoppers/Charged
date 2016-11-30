using UnityEngine;
using System;
using System.Xml;
using System.Collections.Generic;

/* * * * * * * * * * * * * * * * * * * * * * * * * *
 *                                                 *
 *   This class will create an .XML file when a    *
 *   user creates their level/scene and hit the    *
 *   save button. After the level is deemed as     *
 *   beatable, the XML file will be written with   *
 *   all the positions of all the obstacles and    *
 *   the start and end points, etc. so that when   *
 *   a user selects the level in the level select  *
 *   menu, the scene will call the script, and     *
 *   pass in the XML file name, and then read the  *
 *   XML file and create the scene in runtime.     *
 *                                                 *
 * * * * * * * * * * * * * * * * * * * * * * * * * */
public class XMLoader
{
    XmlDocument myDocument = new XmlDocument();
    XmlNode myLevelNode;
    XmlNode startNode;
    XmlNode endNode;
    XmlNode obstaclesNode;

    string levelPath;

    SceneBuilder myBuilder;
    List<ObstacleCreation> creationList;

    ObstacleCreation myObstacleCreation;
    public void MainMethod(string path)
    {
        //Debug.Log("File name is: " + path);
        //levelPath = Application.dataPath + "/" + path + ".xml";

        //Debug.Log("Path is: " + levelPath);
        

        //Debug.Log(levelPath);
        LoadXMLFile(levelPath);
        //Debug.Log(creationList.Count);
    }
    public List<ObstacleCreation> LoadXMLFile(string path)
    {
        //Debug.Log(path);
        XmlTextReader myReader = new XmlTextReader(path);
        myDocument.Load(myReader);

        creationList = new List<ObstacleCreation>();

        for (int i = 0; i < myDocument.ChildNodes.Count; i++)
        {
            if (myDocument.ChildNodes[i].Name == "Level")
            {
                myLevelNode = myDocument.ChildNodes[i];
            }
        }

        foreach(XmlNode node in myLevelNode.ChildNodes)
        {
            if(node.Name == "start")
            {
                //Set the startNode in case we have further need for it
                startNode = node;

                //Create new instance of obstacle for the start/end
                myObstacleCreation = new ObstacleCreation();

                //We need to parse the attributes into floats to use in the Vectors
                myObstacleCreation.Position = new Vector3(float.Parse(startNode.Attributes[0].Value), float.Parse(startNode.Attributes[1].Value), float.Parse(startNode.Attributes[2].Value));
                myObstacleCreation.Type = "start";

                creationList.Add(myObstacleCreation);
            }
            else if (node.Name == "end")
            {
                //Set the endNode in case we have further need for it
                endNode = node;

                //Create new instance of obstacle for the start/end
                myObstacleCreation = new ObstacleCreation();

                //We need to parse the attributes into floats to use in the Vectors
                myObstacleCreation.Position = new Vector3(float.Parse(endNode.Attributes[0].Value), float.Parse(endNode.Attributes[1].Value), float.Parse(endNode.Attributes[2].Value));
                myObstacleCreation.Type = "end";

                creationList.Add(myObstacleCreation);
            }
        }
        /*for (int i = 0; i < myLevelNode.ChildNodes.Count; i++)
        {
            if (myLevelNode.ChildNodes[i].Name == "start")
            {
                startNode = myLevelNode.ChildNodes[i];
                print(startNode.Name);
            }
            if (myLevelNode.ChildNodes[i].Name == "end")
            {
                endNode = myLevelNode.ChildNodes[i];
                print(startNode.Name);
            }
        }*/

        obstaclesNode = myLevelNode.ChildNodes.Item(4);
        foreach (XmlNode node in obstaclesNode.ChildNodes)
        {
            //Create an instance of the obstacles
            myObstacleCreation = new ObstacleCreation();

            //Grab the interior child node's inner text for type and position
            myObstacleCreation.Type = node["type"].InnerText;
            myObstacleCreation.Position = new Vector3(float.Parse(node["position"].Attributes[0].Value), float.Parse(node["position"].Attributes[1].Value), float.Parse(node["position"].Attributes[2].Value));

            //Add the obstacle to the list
            creationList.Add(myObstacleCreation);
        }

        //Testing nodes / names
        foreach(var OC in creationList)
        {
            //Debug.Log("Obstacle Position: " + OC.Position + " Type of: " + OC.Type);
        }
        return creationList;
    }
}

