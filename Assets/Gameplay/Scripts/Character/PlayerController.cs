using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float forceMagnitude = 700f;
    private float dirX;
    [HideInInspector]
    public Rigidbody2D rb;

    private void Update()
    {
        dirX = CrossPlatformInputManager.GetAxisRaw("Horizontal") * moveSpeed;
        if(CrossPlatformInputManager.GetButtonDown("Jump") && rb.velocity.y == 0f)
        {
            rb.AddForce(Vector2.up * forceMagnitude);
        }
    }
    private void FixedUpdate()
    {
        if (dirX != 0f)
        {
            rb.velocity = new Vector2(dirX, rb.velocity.y);
        }
    }

    public float GetPowerGravity()
    {
        return rb.gravityScale;
    }

    public void SetPowerJump(float newPower)
    {
        if(forceMagnitude != newPower)
        {
            forceMagnitude = newPower;
        }
    }

    public void SetPowerSpeed(float newSpeed)
    {
        if(moveSpeed != newSpeed)
        {
            moveSpeed = newSpeed;
        }
    }
}
