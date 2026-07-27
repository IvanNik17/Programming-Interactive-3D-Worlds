using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleDelegate : MonoBehaviour
{
    delegate int DelegateExample(float num);

    DelegateExample currDelegate;

    void Start()
    {
        currDelegate = RootIntFunc;
    }

    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            Debug.Log(currDelegate(5));
        }
    }

    int SqrIntFunc(float num)
    {
        int sqr = Mathf.FloorToInt(num * num);

        return sqr;
    }

    int RootIntFunc(float num)
    {
        int sqr = Mathf.FloorToInt(Mathf.Sqrt(num));

        return sqr;
    }
}
