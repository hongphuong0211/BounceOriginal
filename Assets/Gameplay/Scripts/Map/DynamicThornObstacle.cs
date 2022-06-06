using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicThornObstacle : ObstacleInstance
{
    public Vector3 startPoint;
    public Vector3 endPoint;
    public float moveSpeed = 5f;
    private Vector3 direction;
    private Transform dynThornTransform;
    private float deltaDir = 0.001f;
    private void Start()
    {
        dynThornTransform = transform;
        direction = (endPoint - startPoint).normalized;
        dynThornTransform.position = startPoint;
    }
    private void FixedUpdate()
    {
        if (startPoint != endPoint)
        {
            if((direction - (endPoint - startPoint).normalized).sqrMagnitude < deltaDir)
            {
                if ((dynThornTransform.position - endPoint).sqrMagnitude > deltaDir)
                {
                    dynThornTransform.position = Vector3.MoveTowards(dynThornTransform.position, endPoint, moveSpeed * Time.fixedDeltaTime);
                }
                else
                {
                    direction = (startPoint - endPoint).normalized;
                }
            }else
            {
                if ((dynThornTransform.position - startPoint).sqrMagnitude > deltaDir)
                {
                    dynThornTransform.position = Vector3.MoveTowards(dynThornTransform.position, startPoint, moveSpeed * Time.fixedDeltaTime);
                }
                else
                {
                    direction = (endPoint - startPoint).normalized;
                }
            }
        }
    }
}
