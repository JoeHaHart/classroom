using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VectorSelector : MonoBehaviour {
	public Transform Selector;
	public Material inactiveMaterial;
	public Material highlightedMaterial;
	public Quaternion selectedQuaternion;
	private Dictionary<Quaternion, Renderer> vectors;
	// Use this for initialization
	void Start () {
		vectors = new Dictionary<Quaternion, Renderer> ();

		foreach (Transform child in transform) {
			Renderer mat = child.GetComponentInChildren<Renderer> ();
			vectors.Add (child.transform.rotation, mat);
			Debug.Log ("Added: " + child.transform.eulerAngles.ToString ());

		}
		Debug.Log (vectors);
	}

	// Update is called once per frame
	void FixedUpdate () {
		FindNearestVector ();
	}

	private void FindNearestVector () {
		Quaternion selectorAngle = Selector.rotation;
		Quaternion closestQuaternion = new Quaternion();
		float closestAngle = 9999999999;
		Debug.Log("FINDING VECTORS");
		foreach (KeyValuePair<Quaternion, Renderer> vector in vectors) {
			//Now you can access the key and value both separately from this attachStat as:
			float thisDiff = Quaternion.Angle(selectorAngle, vector.Key);
			// Debug.Log(thisDiff);
			vectors[vector.Key].material = inactiveMaterial;

			if (thisDiff < closestAngle) {
				// Debug.Log("new vecttor: " + vector.Key);
				closestAngle = thisDiff;
				closestQuaternion = vector.Key;
			}
			Debug.Log("Selector: " + selectorAngle + " Vector: " + vector.Key + " Diff: " + thisDiff);
		}

		vectors[closestQuaternion].material = highlightedMaterial;
	}

}