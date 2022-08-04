using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestingVector : MonoBehaviour
{

    [SerializeField]
    private MyVector MyVector1;

    [SerializeField]
    private MyVector MyVector2;



    [SerializeField, Range(0f, 1f)]
    private float factor = 0;

    // Start is called before the first frame update
    void Start()
    {
        /*     MyVector sum = MyVector1 + MyVector2;
             MyVector1.Sum(MyVector2);*/

        /*        MyVector SubResult = MyVector1 - MyVector2;*/

        /*        MyVector result = MyVector1 * 2;
                Debug.Log(result);*/


        /*        Vector2 a = Vector2.left;
                Vector2 b = Vector2.right;
                Vector2 c = a + b;*/
/*
        MyVector other = new MyVector(5, 4);
        Debug.DrawLine((Vector3)other, Vector3.down, Color.red);

*/
        
    }



    // Update is called once per frame
    void Update()
    {
        MyVector1.Draw(Color.red);
        MyVector2.Draw(Color.green);

        MyVector lerp = MyVector1.Mix(MyVector2, factor);
        lerp.Draw(Color.blue);

        MyVector diff = MyVector1 - lerp;
        diff.Draw(lerp, Color.yellow);


    }

} 
 