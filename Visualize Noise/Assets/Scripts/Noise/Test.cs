using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //float randomNumber = Random.value;

        //float randomNumber = Random.Range(0, 100);


        //Vector3 randomPos = Random.insideUnitSphere;

        //Vector2 randomPos2D = Random.insideUnitCircle;

        //Vector3 randomPos = Random.onUnitSphere;


        Quaternion randomRot = Random.rotationUniform;

        //Quaternion randomRot = Random.rotation;


        transform.rotation = randomRot;


        Color randomColour = Random.ColorHSV();
        

    }
}
