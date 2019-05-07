using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetLevel : MonoBehaviour {
    private float GRAVITY = 9.81f;
    private Vector3 customGravity;

	// Use this for initialization
	void Start () {
		customGravity = new Vector3(0, -GRAVITY, 0);

	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown("p")){
			Application.LoadLevel(0);
			Physics.gravity = customGravity;

		}
	}
}
