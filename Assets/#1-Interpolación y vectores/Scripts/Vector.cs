using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;

[System.Serializable]
//Un struct nunca puede heredar
public struct MyVector
{
    //Si no se pone nada, Unity lo asume privado
    public float x;
    public float y;

    public MyVector(float x, float y)
    {
        this.x = x;
        this.y = y;

    }

    //Se deben usar las variables llamadas para que funciones dentro del metodo
    public MyVector Sum(MyVector other)
    {
        return new MyVector(x + other.x, y + other.y);

    }

    public MyVector Sub(MyVector other)
    {
        return new MyVector(x - other.x, y - other.y);

    }

    public MyVector Scale(float factor)
    {
        return new MyVector(x * factor, y * factor);

    }

    //Cuando usas static defines la variable, método o propiedad a nivel de clase y no de instancia
    //, o sea no podrás aplicar conceptos de programación orientado a objetos
    public static  MyVector operator+(MyVector a, MyVector b)
    {
        return a.Sum(b);
    }

    public static MyVector operator-(MyVector a, MyVector b)
    {
        return a.Sub(b);
    }

    public static MyVector operator*(MyVector a, float b)
    {
        return a.Scale(b);
    }

    public static MyVector operator*(float b, MyVector a)
    {
        return a.Scale(b);
    }

    public static implicit operator Vector3(MyVector a)
    {
        return new Vector3(a.x, a.y, 0);
    }

    public static implicit operator MyVector(Vector3 a)
    {
        return new MyVector(a.x, a.y);
    }

    public MyVector Mix(MyVector b, float d)
    {
        return (this + (b-this) * d);
    }

    public override string ToString()
    {
        return $"({x}. {y})";
    }

    public void Draw(Color color)
    {
        Debug.DrawLine(new Vector3(0,0,0), new Vector3(x, y, 0), color, 0);
    }

    public void Draw(MyVector origen, Color color)
    {
        Debug.DrawLine(new Vector3(origen.x, origen.y, 0), new Vector3(x + origen.x, y + origen.y, 0), color, 0);
    }

}

