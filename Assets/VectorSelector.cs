using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VectorSelector : MonoBehaviour
{
    public Transform Selector;
    public Material inactiveMaterial;
    public Material highlightedMaterial;

    private Dictionary<Quaternion, Renderer> vectorRenderers;
    private Dictionary<Quaternion, Transform> vectorTransforms;
    public Transform selectedTransform;

    // Use this for initialization
    void Start()
    {
        GenerateDictionaries();
    }

    void GenerateDictionaries()
    {
        vectorRenderers = new Dictionary<Quaternion, Renderer>();
        vectorTransforms = new Dictionary<Quaternion, Transform>();
        //Get the vector objects
        foreach (Transform child in transform)
        {
            Renderer renderer = child.GetComponentInChildren<Renderer>();
            vectorRenderers.Add(child.transform.rotation, renderer);
            vectorTransforms.Add(child.transform.rotation, child.GetChild(0));

            Debug.Log("Added: " + child.transform.eulerAngles.ToString());

        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        FindNearestVector();
    }

    private void FindNearestVector()
    {
        Quaternion selectorAngle = Selector.rotation;
        Quaternion closestQuaternion = new Quaternion();
        float smallestAngleDelta = 9999999999;
        foreach (KeyValuePair<Quaternion, Renderer> vector in vectorRenderers)
        {
            float angleDelta = Quaternion.Angle(selectorAngle, vector.Key);
           // Set all vectors to be inactive initially.
		    vectorRenderers[vector.Key].material = inactiveMaterial;
			
            if (angleDelta < smallestAngleDelta)
            {
                smallestAngleDelta = angleDelta;
                closestQuaternion = vector.Key;
            }
        }

		// Set only the closest vector to be highlighted
        vectorRenderers[closestQuaternion].material = highlightedMaterial;
        selectedTransform = vectorTransforms[closestQuaternion];
    }

    private Vector3 GetSelectedUnitVector()
    {
		Vector3 directionVector = selectedTransform.rotation * Vector3.forward;
		return directionVector.normalized;
    }
}