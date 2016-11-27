using UnityEngine;
using System.Collections;

public class ObstacleCreation : MonoBehaviour
{
    string type;
    Vector3 position;

    public Vector3 Position
    {
        get
        {
            return position;
        }

        set
        {
            position = value;
        }
    }

    public string Type
    {
        get
        {
            return type;
        }

        set
        {
            type = value;
        }
    }
}