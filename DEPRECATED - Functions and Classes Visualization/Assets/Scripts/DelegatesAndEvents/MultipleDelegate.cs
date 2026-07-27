using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultipleDelegate : MonoBehaviour
{
    delegate void DelegateExample(Color changeColor);

    DelegateExample currDelegate;

    void Start()
    {
        currDelegate += changeColor;

        currDelegate += sayColor;
    }

    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            currDelegate(Color.blue);

            
        }

    }

    void sayColor(Color changeColor)
    {
        Debug.Log($"The new color is {changeColor}");
    }

    void changeColor(Color changeColor)
    {
        transform.GetComponent<Renderer>().material.color = changeColor;

    }
}
