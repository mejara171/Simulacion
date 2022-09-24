using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class LookAtMove : MonoBehaviour
{

    [SerializeField] private GeneralMove mover;
    private Vector3 direction;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        direction = mover.Velocity;
        float radians = Mathf.Atan2(direction.y, direction.x);
        RotateZ(radians);
    }
    
    
    private void RotateZ(float radians)
    {
        transform.rotation = Quaternion.Euler(0.0f, 0.0f, radians * Mathf.Rad2Deg);
    }
}

