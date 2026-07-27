using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParentPivotRotation : MonoBehaviour
{
    [SerializeField]
    float rotationSpeed = 3f;

    [SerializeField]
    float rotationLimit = 180;

    [SerializeField]
    float timeChange = 0.125f;


    Vector3 mouseRotation = Vector2.zero;


    // Update is called once per frame
    void FixedUpdate()
    {
        mouseRotation.x += Input.GetAxis("Mouse X") * rotationSpeed;
        mouseRotation.y += Input.GetAxis("Mouse Y") * rotationSpeed;

        mouseRotation.y = Mathf.Clamp(mouseRotation.y, -rotationLimit, rotationLimit);

        transform.localRotation = Quaternion.Lerp(transform.localRotation, Quaternion.Euler(-mouseRotation.y, mouseRotation.x, mouseRotation.z), timeChange);


            
    }
}

