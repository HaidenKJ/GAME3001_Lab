using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Starship : AgentObject
{

    [SerializeField] float movementSpeed;
    [SerializeField] float rotationSpeed;

    private Rigidbody2D rgBody;
    // Start is called before the first frame update
    void Start()
    {
        rgBody = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        if(targetPosition != null)
        {
            Seek();
            SeekForward();
        }
    }

    private void Seek()
    {
        //Calculate Direction to target
        Vector2 direction = (targetPosition - transform.position).normalized;
        //Calculate desired Velocity using kinematic seek equation.
        Vector2 desiredVelocity = direction * movementSpeed;
        //Calculate the steering force (desire velocity - current velocity)
        Vector2 steeringForce = desiredVelocity - rb.velocity;
        //Change Velocity to desired Velocity
        rb.velocity = desiredVelocity;
        // Apply the steering force to the agent
        rb.AddForce(steeringForce);
    }
    private void SeekForward()// A seek with rotation to target but on;y moving along the forward vector
    {
        //Calculate direction to target
        Vector2 direction = (targetPosition - transform.position).normalized;
        //Calculate the angle to roatet towards the target
        float targetAngle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg + 90.0f;

        //Smoothly rotate towards the target
        float angleDiffrence = Mathf.DeltaAngle(targetAngle, transform.eulerAngles.z);
        float rotationStep = rotationSpeed * Time.deltaTime;
        float rotationAmount = Mathf.Clamp(angleDiffrence, -rotationStep, rotationStep);
        transform.Rotate(Vector3.forward, rotationAmount);

        //Move along the forward vector using RigidBody2D
        rb.velocity = transform.up * movementSpeed;
    }

}
