using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private static PlayerManager instance;
    public static PlayerManager Instance { 
        get { 
            if (instance == null)
            {
                instance = FindObjectOfType<PlayerManager>();
            }
            return instance; 
        } 
    }
    public List<Sprite> stateBall;
    private PlayerController playerController;
    private Rigidbody2D rb;
    private CircleCollider2D circleCollider;
    private SpriteRenderer spriteRenderer;
    private Transform playerTransform;
    private StatusSpawn statusSpawn;
    private StateSizeBall sizeBall;
    public bool IsState(StateSizeBall checkSize)
    {
        return sizeBall == checkSize;
    }
    public void ChangeState(StateSizeBall newSize)
    {
        if(sizeBall != newSize)
        {
            sizeBall = newSize;
            if(((int)newSize + 1)*(stateBall.Count - (int)newSize) > 0)
            {
                spriteRenderer.sprite = stateBall[(int)newSize];
                circleCollider.radius = stateBall[(int)newSize].rect.width/200f;
            }
            
            if (sizeBall == StateSizeBall.small)
            {
                rb.mass = 1f;
            }else if(sizeBall == StateSizeBall.big)
            {
                rb.mass = 0.5f;
            }
        }
    }

    private void OnInit()
    {
        playerController = GetComponent<PlayerController>();
        rb = GetComponent<Rigidbody2D>();
        playerController.rb = rb;
        spriteRenderer = GetComponent<SpriteRenderer>();
        circleCollider = GetComponent<CircleCollider2D>();
        playerTransform = transform;
    }

    private void Awake()
    {
        OnInit();
    }

    public void SetGravityBall(float newGravity)
    {
        if (rb.gravityScale != newGravity)
        {
            rb.gravityScale = newGravity;
        }
    }
    public void SetJumpBall(float newPower)
    {
        playerController.SetPowerJump(newPower);
    }
    public void SetSpeedBall(float newPower)
    {
        playerController.SetPowerSpeed(newPower);
    }

    public void SaveStatusBall()
    {
        statusSpawn.spawnPoint = playerTransform.position;
        statusSpawn.powerSpeed = playerController.moveSpeed;
        statusSpawn.powerJump = playerController.forceMagnitude;
        statusSpawn.powerGravity = rb.gravityScale;
        statusSpawn.sizeBall = sizeBall;
    }

    public void SpawnPlayer()
    {
        playerTransform.position = statusSpawn.spawnPoint;
        SetSpeedBall(statusSpawn.powerSpeed);
        SetJumpBall(statusSpawn.powerJump);
        SetGravityBall(statusSpawn.powerGravity);
        ChangeState(statusSpawn.sizeBall);
    }

}

public struct StatusSpawn
{
    public Vector3 spawnPoint;
    public float powerSpeed;
    public float powerGravity;
    public float powerJump;
    public StateSizeBall sizeBall;
}
