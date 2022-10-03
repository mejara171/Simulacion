using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FunctionGraph : MonoBehaviour
{
    [SerializeField] private GameObject m_PointPrefab;
    [SerializeField] private int m_NumberOfPoints = 10;
    [SerializeField] private float m_Separation = 0.5f;
    GameObject[] m_Points;
    // Start is called before the first frame update
    void Start()
    {
        m_Points = new GameObject[m_NumberOfPoints];
        for (int i = 0; i < m_NumberOfPoints; i++)
        {
            m_Points[i] = Instantiate(m_PointPrefab, transform);

        }

    }

    private void UpdatePoints()
    {
        for (int i = 0; i < m_Points.Length; ++i)
        {
            var NewPoint = m_Points[i];
            Vector3 CurPosition = NewPoint.transform.position;

            CurPosition.x = i * m_Separation;
            CurPosition.y = Mathf.Sin(CurPosition.x + Time.time);

            NewPoint.transform.position = CurPosition;
        }

    }

    // Update is called once per frame
    void Update()
    {
        UpdatePoints();
    }
}
