using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P2Score : MonoBehaviour {

    TextMesh currentMesh;
    public int pscore = 0;
	// Use this for initialization
	void Start () {
        currentMesh = GetComponent<TextMesh>();
        currentMesh.alignment = TextAlignment.Left;
        currentMesh.fontSize = 27;
        currentMesh.text = "Player 2\n" + pscore;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
