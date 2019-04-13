using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parabola : MonoBehaviour
{
    public float velX = 4;
    public float velY = 4;
    private float startTime = 0;

    public bool started = false;

    private float GRAVITY = 9.81f;
    private Vector3 customGravity;
    public Vector3 initialPos;
    private bool frozen = false;
    public bool canFreeze = true;
    Rigidbody rb;
    private bool lastYVelocityWasPositive = true;
    QuestionManager qm;

    float frozenTime = 0;
    float frozenDuration = 0;

    // Use this for initialization
    void Start()
    {
        startTime = Time.time;
        customGravity = new Vector3(0, -GRAVITY, 0);
        rb = GetComponent<Rigidbody>();
        qm = GameObject.Find("GameLogic").GetComponent<QuestionManager>();

    }

    public void Freeze()
    {
        if (canFreeze)
        {
            frozen = true;
            qm.askQuestion();
            frozenTime = Time.time;
            float timePassed = Time.time - startTime;
            Debug.Log("time passed BEFORE FREEZE: " + timePassed);
        }

    }

    public void UnFreeze(Vector3 unitForce)
    {
        frozen = false;
        canFreeze = false;
        customGravity = unitForce * GRAVITY;
        frozenDuration = Time.time - frozenTime;
        StopJump();
        Physics.gravity = customGravity;
        rb.velocity = new Vector3(velX, 0, 0);
        // velY = 0;
        // initialPos.y = transform.position.y;
        // Debug.Log("UNFREEZE");
        // float timePassed = Time.time - frozenDuration - startTime;
        // Debug.Log("time passed AFTER FREEZE: " + timePassed);
    }

    float getGravityPos(float time, float gravity)
    {
        Debug.Log(gravity);
        if (gravity == 0)
        {
            return 0;
        }
        return ((gravity / 2) * Mathf.Pow(time, 2.0f));
    }

    // Update is called once per frame
    void Update()
    {
        if (started && !frozen)
        {

            float timePassed = Time.time - frozenDuration - startTime;
            float newX = velX * timePassed + getGravityPos(timePassed, customGravity.x);
            float newY = velY * timePassed + getGravityPos(timePassed, customGravity.y);
            Debug.Log("NewX: " + newX);
            Debug.Log("newY: " + newY);
            Debug.Log("timePassed: " + timePassed);
            float currentYVelocity = velY - GRAVITY * timePassed;
            if (canFreeze)
            {

                if (currentYVelocity > 0)
                {
                    lastYVelocityWasPositive = true;
                }
                else
                {
                    if (lastYVelocityWasPositive == true)
                    {
                        Freeze();
                    }
                }
            }
            if (initialPos.y + newY < initialPos.y)
            {
                StopJump();
            }
            float posX = initialPos.x + newX;
            Debug.Log("posX: " + posX);
            float posY = initialPos.y + newY;
            Debug.Log("posY: " + posY);
            float posZ = initialPos.z;
            Vector3 newPos = new Vector3(posX, posY, posZ);
            transform.position = newPos;
        }
    }

    public void StartJump(float direction, bool freeze)
    {
        initialPos = transform.position;
        startTime = Time.time;
        rb.isKinematic = true;
        GetComponent<CapsuleCollider>().enabled = false;
        velX = Mathf.Abs(velX) * direction;
        velY = 4;
        started = true;
        lastYVelocityWasPositive = true;
        frozen = false;
        GRAVITY = 9.81f;
        customGravity = new Vector3(0, -9.81f, 0);
        Debug.Log("INTIITAL CUSTOM GRAVITY");
        Debug.Log(customGravity);
        frozenTime = 0;
        frozenDuration = 0;
        canFreeze = freeze;
    }

    public void StopJump()
    {
        started = false;
        rb.isKinematic = false;
        GetComponent<CapsuleCollider>().enabled = true;

    }
}
