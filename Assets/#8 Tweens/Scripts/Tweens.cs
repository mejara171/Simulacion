using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tweens : MonoBehaviour
{
    [SerializeField] private float time;
    [SerializeField] private Transform TargetTransform;
    [SerializeField, Range(0, 1)] private float TParameter = 0;
    [SerializeField] private Color InitialColor;
    [SerializeField] private Color FinalColor;
    private float CurrentTime;
    private Vector3 InitialPosition;
    private Vector3 TargetPosition;
    private SpriteRenderer spriteRenderer;
    
    // Start is called before the first frame update
    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    private void Update()
    {
        TParameter = CurrentTime / time;
        transform.position = Vector3.Lerp(InitialPosition, TargetPosition, TParameter);
        spriteRenderer.color = Color.Lerp(InitialColor, FinalColor, TParameter);
        CurrentTime += Time.deltaTime;
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartTween();
        }


    }


    private void StartTween()
    {
        TParameter = 0;
        CurrentTime = 0;
        InitialPosition = transform.position;
        TargetPosition = TargetTransform.position;
    }
}
