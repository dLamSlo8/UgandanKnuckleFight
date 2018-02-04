using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeachTeleportation : MonoBehaviour {

    public GameObject peach;
    public GameObject peachClone;
	// Use this for initialization
	void Start () {
        Vector3 startPos = new Vector3(Random.Range(-19.0f, 19.0f), 0, Random.Range(-19.0f, 19.0f));
        peachClone = Instantiate(peach, startPos, Quaternion.identity);
        peachClone.transform.Rotate(new Vector3(0, 180, 0));
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
