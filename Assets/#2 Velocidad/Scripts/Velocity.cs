using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Velocity : MonoBehaviour
{
    [SerializeField] MyVector position;
    [SerializeField] MyVector displacement;
    void Start()
    {

    }


    // Update is called once per frame
    void Update()
    {
        position.Draw(Color.green);
        displacement.Draw(Color.clear);
    }

    public void MoveHorizontal()
    {
        //calculate displacement and new position
        position += displacement;

        //check bounds
        if (position.x >= 5 || position.x <= -5)
        {
            //position.x + Mathf.Sign(position.x * 5);
            displacement.x = -displacement.x;
        }
        //update unity object
        transform.position = position;
    }

    public void MoveVertical()
    {

        //calculate displacement and new position
        position += displacement;

        //check bounds
        if (position.y >= 5 || position.y <= -5)
        {
            //position.x + Mathf.Sign(position.x * 5);
            displacement.y = -displacement.y;
        }
        //update unity object
        transform.position = position;
    }



}