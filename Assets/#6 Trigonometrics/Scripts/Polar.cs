using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Polar : MonoBehaviour
{
    [SerializeField]
    private MyVector polarPoint = new MyVector(0, 0);

    [SerializeField]
    private float angularSpeed = 1, angularAcceleration = 0, radialSpeed = 1, radialAcceleration = 0;


    // Update is called once per frame
    void Update()
    {
        // Increment radius
        radialSpeed += radialAcceleration * Time.deltaTime;
        polarPoint.x += radialSpeed * Time.deltaTime;

        // Increment theta
        angularSpeed += angularAcceleration * Time.deltaTime;
        polarPoint.y += angularSpeed * Time.deltaTime;

        // Convert to cartesian
        MyVector cartesianPoint = polarPoint.FromPolarToCartesian();

        // Draw cartesian point
        cartesianPoint.Draw(Color.yellow);

        // Update this transform position
        transform.position = cartesianPoint;
    }
}
