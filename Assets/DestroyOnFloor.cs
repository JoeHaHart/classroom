using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnFloor : MonoBehaviour {
    public Transform respawnLocation;

    void OnCollisionEnter (Collision col) {
        Debug.Log (col.gameObject.name);
        if (col.gameObject.name == "Floor") {
            this.gameObject.transform.position = respawnLocation.position;
            this.GetComponent<Rigidbody> ().velocity = Vector3.zero;
        }

    }
}