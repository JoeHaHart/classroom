using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class VectorSelectionHandler : MonoBehaviour
{
    public float snapDistance = 1.0f;
    QuestionManager qm;
    public VectorSelector vectorSelector;

    private void Start()
    {
        qm = GameObject.Find("GameLogic").GetComponent<QuestionManager>();
    }
    // Use this for initialization
    public void OnRelease()
    {
        Transform selected = vectorSelector.selectedTransform;
        if (selected)
        {
            transform.position = selected.position;
            transform.rotation = selected.rotation;
            this.GetComponent<Rigidbody>().isKinematic = true;
            this.GetComponent<MeshCollider>().enabled = false;
            qm.answerQuestion(vectorSelector.GetSelectedUnitVector());
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
