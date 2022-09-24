using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralMove : MonoBehaviour
{
    private enum MovementMode
    {
        Velocity = 0,
        Acceleration
    }

    public MyVector Velocity => velocity;

    [SerializeField] private MovementMode movementMode;
    [SerializeField] private Transform target;
    [SerializeField] private float speed;
    private MyVector accelaration;
    private MyVector velocity;
    private MyVector position;

    private void Start()
    {
        position = transform.position;
    }

    private void FixedUpdate()
    {
        Move();
    }
    // Update is called once per frame
    void Update()
    {
        position.Draw(Color.green);
        accelaration.Draw(position, Color.red);
        velocity.Draw(position, Color.blue);

        switch (movementMode)
        {
            case MovementMode.Velocity:
                velocity = target.position - transform.position;
                velocity.Normalize();
                velocity *= speed;
                break;

            case MovementMode.Acceleration:
                accelaration = target.position - transform.position;
                break;
        }


    }

    public void Move()
    {
        velocity = velocity + accelaration * (Time.fixedDeltaTime);
        //calculate displacement and new position
        position = position + velocity * (Time.fixedDeltaTime);

        //update unity object
        transform.position = position;
    }
}