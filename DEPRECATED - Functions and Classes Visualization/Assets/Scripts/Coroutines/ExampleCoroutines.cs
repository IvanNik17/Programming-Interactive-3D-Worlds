using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExampleCoroutines : MonoBehaviour
{
    IEnumerator rotateEnum;

    IEnumerator colorEnum;
    // Start is called before the first frame update
    void Start()
    {
        rotateEnum = rotateCoroutine();
        StartCoroutine(rotateEnum);
        //StartCoroutine('rotateCoroutine');

        colorEnum = colorCoroutine();
        StartCoroutine(colorEnum);

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            StopCoroutine(rotateEnum);
            
        }
        else if(Input.GetMouseButton(1))
        {
            StopAllCoroutines();
        }


    }

    IEnumerator rotateCoroutine()
    {
        Vector3 eulerRot = new Vector3(2, 0, 0);
        while (true)
        {
            transform.Rotate(eulerRot);
            yield return null;
        }
    }


    IEnumerator colorCoroutine()
    {
        Renderer sphereRenderer = transform.GetComponent<Renderer>();
        while (true)
        {
            sphereRenderer.material.color = new Color(Random.value, Random.value, Random.value, 1);
            yield return new WaitForSeconds(2);
        }


    }
}
