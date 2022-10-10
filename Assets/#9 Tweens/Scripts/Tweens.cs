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
    [SerializeField] private AnimationCurve Curve;
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
        transform.position = Vector3.LerpUnclamped(InitialPosition, TargetPosition, Curve.Evaluate(TParameter));
        spriteRenderer.color = Color.LerpUnclamped(InitialColor, FinalColor, Curve.Evaluate(TParameter));
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


    private float EasiInOutElastic(float x)
    {
        float C5 = (2 * Mathf.PI) / 4.5f;

        return x == 0f
                ? 0f
                : x == 1f
                    ? 1f
                    : x < 0.5f
                        ? -(Mathf.Pow(2, 20 * x - 10) * Mathf.Sin((20 * x - 11.125f) * C5)) / 2
                        : (Mathf.Pow(2, -20 * x + 10) * Mathf.Sin((20 * x - 11.125f) * C5)) / 2 + 1;
    }
}
