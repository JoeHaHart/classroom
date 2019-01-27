using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class CollisionEvent : MonoBehaviour
{
    public UnityEvent triggerEvent;
    public string NameOfGameObject;
    bool oneHitOnly = true;

    // Update is called once per frame
    void OnCollisionEnter(Collision col)
    {
        Debug.Log(col.gameObject.name);
        if (col.gameObject.name == NameOfGameObject)
        {
            Debug.Log("Trigger");
            triggerEvent.Invoke();
        }
        else
        {
            Debug.LogWarning("Name " + col.gameObject.name + " not equal to " + NameOfGameObject);
        }

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.name == NameOfGameObject)
        {
            triggerEvent.Invoke();
            if (oneHitOnly)
            {
                GetComponent<BoxCollider>().enabled = false;
            }
        }
        else
        {
            Debug.LogWarning("Name " + other.name + " not equal to " + NameOfGameObject);
        }
    }
}