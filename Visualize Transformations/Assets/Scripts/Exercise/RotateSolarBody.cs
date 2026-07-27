using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateSolarBody : MonoBehaviour
{

    [SerializeField]
    float rotationSpeed = 10f;

    [SerializeField]
    GameObject pivot;

    [SerializeField]
    Vector3 rotationAxis = Vector3.up;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(pivot.transform.position, rotationAxis, rotationSpeed * Time.deltaTime);
    }
}
