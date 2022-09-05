 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewtonAtraction : MonoBehaviour
{
    [SerializeField] private Transform target; 
    [SerializeField] private MyVector position;
    [SerializeField] private MyVector velocity;
    [SerializeField] private MyVector accelaration;


    [SerializeField] private float mass = 1f;
    [SerializeField] private float mass2 = 1f;
    // Start is called before the first frame update
    void Start()
    {
        position = transform.position;   
    }

    private void FixedUpdate()
    {
        //Apply Gravity
        MyVector r = target.position - transform.position;
        float rMagnitude = r.magnitude;
        MyVector f = r.normalized * (mass2 * mass / rMagnitude * rMagnitude) ;
        ApplyForce(f);
        f.Draw(position, Color.blue);


        //Integrate accel and velocity
        Movement();
    }

    // Update is called once per frame
    void Update()
    {
        velocity.Draw(position, Color.red);   
    }

    public void Movement()
    {
        velocity = velocity + accelaration * (Time.fixedDeltaTime);
        //calculate displacement and new position
        position = position + velocity * (Time.fixedDeltaTime);

        if (velocity.magnitude > 10)
        {
            velocity.Normalize();
            velocity *= 10;
        }

        //update unity object
        transform.position = position;
    }

    void ApplyForce(MyVector force)
    {
        accelaration += force/mass;
    }
}
