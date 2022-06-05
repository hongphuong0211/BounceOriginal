using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float forceMagnitude = 700f; 
    private float dirX;
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        dirX = CrossPlatformInputManager.GetAxisRaw("Horizontal") * moveSpeed;
        if(CrossPlatformInputManager.GetButtonDown("Jump") && rb.velocity.y == 0)
        {
            rb.AddForce(Vector2.up * forceMagnitude);
        }
    }
    private void FixedUpdate()
    {
        rb.velocity = new Vector2(dirX, rb.velocity.y);
    }
}
