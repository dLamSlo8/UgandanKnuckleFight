using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TearCollision : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "knookle")
        {
            //Destroy(collision.collider.GetComponent<Rigidbody>());
            //collision.collider.GetComponent<Renderer>().enabled = false;
            

        }
    }
}
