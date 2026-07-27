using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleShow : MonoBehaviour
{

    public bool running = false;

    public Vector3 scaleDirection;

    public float amplitude = 2f;

    public bool pulse = false;


    // Update is called once per frame
    void Update()
    {
        if (running)
        {

            if (pulse)
            {
                float scale = amplitude * Mathf.Sin(Time.time) + amplitude;

                transform.localScale = scaleDirection * scale;
            }
            else
            {
                transform.localScale += scaleDirection * Time.deltaTime;
            }

        }
    }
}
