using UnityEngine;
using System.Collections;

public class hectordummy : MonoBehaviour {

    Rigidbody2D self; 
	// Use this for initialization
	void Start ()
    {
        self = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        print(self.velocity);
	}
}
