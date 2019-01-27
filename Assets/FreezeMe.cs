using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezeMe : MonoBehaviour
{
    Vector3 vel;
    Rigidbody rb;
    Vector3 customGravity;
    bool customGrav = false;
    bool shouldFreeze = false;
    bool shouldUnFreeze = false;

    public bool canFreeze = false;
    QuestionManager qm;


    public void CanNoFreeze()
    {
        canFreeze = true;
    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        qm = GameObject.Find("GameLogic").GetComponent<QuestionManager>();
    }

    public void _Freeze()
    {
        vel = rb.velocity;
        vel.y = 0;
        rb.isKinematic = true;
        GetComponent<CapsuleCollider>().enabled = false;
        qm.askQuestion();
    }

    public void Freeze()
    {
        shouldFreeze = true;
    }
    public void UnFreeze(Vector3 unitForce)
    {
        customGravity = unitForce * 9.81f;
        shouldUnFreeze = true;
    }

    public void _UnFreeze()
    {
        rb.isKinematic = false;
        GetComponent<CapsuleCollider>().enabled = true;
        rb.velocity = vel;
        rb.useGravity = false;

        Debug.Log("Custom Gravity");
        Debug.Log(customGravity);
        customGrav = true;
    }

    private void FixedUpdate()
    {

        if (canFreeze)
        {
            Debug.Log(rb.velocity.y);
            if (rb.velocity.y < 0.01f)
            {
                Debug.Log("FREEZE");
                shouldFreeze = true;
                canFreeze = false;
            }
        }

        if (shouldFreeze)
        {
            _Freeze();
            shouldFreeze = false;
        }

        if (shouldUnFreeze)
        {
            _UnFreeze();
            shouldUnFreeze = false;
        }

        if (customGrav)
        {

            rb.AddForce(customGravity);
        }
    }
}
