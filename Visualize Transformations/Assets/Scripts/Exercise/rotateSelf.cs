using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateSelf : MonoBehaviour
{
    [SerializeField]
    float rotationSpeed = 10;

    [SerializeField]
    Vector3 rotationAxis = Vector3.up;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(rotationAxis * rotationSpeed * Time.deltaTime);
    }
}
