using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementForce : MonoBehaviour
{
    [SerializeField] private float mass = 1f;
    [SerializeField] private MyVector wind;
    [SerializeField] private MyVector gravity;

    [Header("")]
    [Range(0,1)][SerializeField] private float dampingFactor = 1;

    private MyVector position;
    private MyVector accelaration;
    private MyVector velocity;

    private void Start()
    {
        position = transform.position;
    }

    private void FixedUpdate()
    {
        accelaration *= 0f;
        ApplyForce(wind + gravity);
        Move();
    }


    // Update is called once per frame
    void Update()
    {
        position.Draw(Color.green);
        accelaration.Draw(position, Color.red);
        velocity.Draw(position, Color.blue);
        Debug.Log(Time.deltaTime);


    }

    public void Move()
    {
        velocity = velocity + accelaration * (Time.fixedDeltaTime);
        //calculate displacement and new position
        position = position + velocity * (Time.fixedDeltaTime);
        

        //check bounds
        if (position.x < -5 || position.x > 5)
        {
            position.x = Mathf.Sign(position.x) * 5;
            velocity.x = -velocity.x;
            velocity *= dampingFactor;
        }

        if (position.y < -5 || position.y > 5)
        {
            position.y = Mathf.Sign(position.y) * 5;
            velocity.y = -velocity.y;
            velocity *= dampingFactor;
        }


        //update unity object
        transform.position = position;

    }



    void ApplyForce(MyVector force)
    {
        accelaration = force / mass;
    }
}
