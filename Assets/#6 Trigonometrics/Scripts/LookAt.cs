using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class LookAt : MonoBehaviour
{
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        Vector3 MouseWorldPosition = GetWorldMousePosition();
        float Radians = Mathf.Atan2(MouseWorldPosition.y, MouseWorldPosition.x);
        RotateZ(Radians);
    }

    private Vector4 GetWorldMousePosition()
    {
        Camera camera = Camera.main;
        Vector3 ScreenPos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, camera.nearClipPlane);
        Vector4 WorldPos = camera.ScreenToWorldPoint(ScreenPos);
        return WorldPos;
    }
     
    private void RotateZ(float radians)
    {
        transform.rotation = Quaternion.Euler(0.0f, 0.0f, radians * Mathf.Rad2Deg);
    }

    
}

