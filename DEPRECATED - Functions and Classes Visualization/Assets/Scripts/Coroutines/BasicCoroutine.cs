using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicCoroutine : MonoBehaviour
{
    //coroutine 1
    IEnumerator DoSomething1(int maxNum)
    {
        int counter = 0;
        while (counter<= maxNum)
        {
            counter++;
            print($"<color=green>Coroutine1</color> count {counter}");
            yield return new WaitForSeconds(1.0f);
        }
    }

    //coroutine 2
    IEnumerator DoSomething2(int maxNum)
    {
        int counter = 0;
        while (counter <= maxNum)
        {
            counter++;
            print($"<color=red>Coroutine2</color> count {counter}");
            yield return new WaitForSeconds(0.5f);
        }
    }

    void Start()
    {
        StartCoroutine("DoSomething1", 50);
        StartCoroutine("DoSomething2", 100);

        //StartCoroutine(DoSomething1(50));
        //StartCoroutine(DoSomething2(100));
    }

    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            StopAllCoroutines();
            print("Stopped all Coroutines: " + Time.time);
        }
    }
}
