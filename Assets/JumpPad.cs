using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPad : MonoBehaviour
{
    public float direction = 1.0f;
    bool freeze = false;
    public bool shouldFreeze = false;
    int jumpCount = 0;
    void OnTriggerEnter(Collider other)
    {
        if (shouldFreeze)
        {
            freeze = jumpCount > 1;
        }
        jumpCount++;
        Debug.Log(other.name);
        other.GetComponent<Parabola>().StartJump(direction, freeze);
    }
}
