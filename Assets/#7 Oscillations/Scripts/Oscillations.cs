using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscillations : MonoBehaviour
{ private Vector3 InitialPosition;
    [SerializeField] private float Period = 3;
    [SerializeField] private float Alcance = 3;


    // Start is called before the first frame update
    void Start()
    {
        InitialPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = InitialPosition + Vector3.right * Mathf.Sin(2f * Mathf.PI *(Time.time / Period)) * Alcance;
    }
}
