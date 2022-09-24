using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class LookAt : MonoBehaviour
{


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 MouseWorldPosition = GetWorldMousePosition();
        Vector3 RelativeMousePosition = MouseWorldPosition - transform.position;
        float radians = Mathf.Atan2(RelativeMousePosition.y, RelativeMousePosition.x);
        RotateZ(radians);
    }
    
    private Vector4 GetWorldMousePosition()
    {
        Camera camera = Camera.main;
        Vector3 screenPos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 5f);
        Vector4 worldPos = Camera.main.ScreenToWorldPoint(screenPos);
        return worldPos;
    }
    
    private void RotateZ(float radians)
    {
        transform.rotation = Quaternion.Euler(0.0f, 0.0f, radians * Mathf.Rad2Deg);
    }
}

