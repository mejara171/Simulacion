using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Polar : MonoBehaviour
{
    [SerializeField] MyVector PolarCoord;
    [SerializeField] float AngularSpeed, RadialSpeed;

    private void Update()
    {
        PolarCoord.angle += AngularSpeed * Mathf.Deg2Rad *Time.deltaTime;
        PolarCoord.radius += RadialSpeed * Time.deltaTime;
        transform.position = PolarCoord.FromPolarToCartesian();
    }

}
