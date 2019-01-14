using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class VectorSelectionHandler : MonoBehaviour {
	public float snapDistance = 1.0f;
	public VectorSelector vectorSelector;
	// Use this for initialization
	public void OnRelease () {
		Transform selected = vectorSelector.selectedTransform;
		if(selected) {
			transform.position = selected.position;
			transform.rotation = selected.rotation;
			this.GetComponent<Rigidbody>().isKinematic = true;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
