using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnFloor : MonoBehaviour {

	private void OnCollisionEnter(Collision other) {
		Debug.Log(other.gameObject.name);
		if (other.gameObject.name == "Floor") {
			Debug.Log("Oooh I hit the floor!");
		}
	}
}
