using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocalPivotRotation : MonoBehaviour
{
    [SerializeField]
    float rotationSpeed = 3f;

    [SerializeField]
    float rotationLimit = 45;

    Vector3 mouseRotation = Vector3.zero;

    // Update is called once per frame
    void LateUpdate()
    {
        mouseRotation.x += Input.GetAxis("Mouse X") * rotationSpeed;
        mouseRotation.y += Input.GetAxis("Mouse Y") * rotationSpeed;

        mouseRotation.x = Mathf.Clamp(mouseRotation.x, -rotationLimit, rotationLimit);
        mouseRotation.y = Mathf.Clamp(mouseRotation.y, -rotationLimit, rotationLimit);

        Debug.Log(mouseRotation);
        
        transform.localRotation = Quaternion.Euler(-mouseRotation.y, mouseRotation.x, mouseRotation.z);
    }
}
