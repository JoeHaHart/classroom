using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class CollisionEvent : MonoBehaviour {
	public UnityEvent triggerEvent;
	public string NameOfGameObject;

	// Update is called once per frame
    void OnCollisionEnter (Collision col) {
        Debug.Log (col.gameObject.name);
        if (col.gameObject.name == NameOfGameObject) {
			Debug.Log("Trigger");
            triggerEvent.Invoke();
        } else {
			Debug.Log("Name " + col.gameObject.name + " not equal to " + NameOfGameObject);
		}

    }
}
