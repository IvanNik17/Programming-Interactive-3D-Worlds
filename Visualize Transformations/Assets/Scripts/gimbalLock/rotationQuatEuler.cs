using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotationQuatEuler : MonoBehaviour
{

    [SerializeField]
    bool isQuat = false;

    [SerializeField]
    bool startRot = false;

    [SerializeField]
    Vector3 startingAngle;

    [SerializeField]
    Vector3 rotationPerAngle;

    // Start is called before the first frame update
    void Start()
    {

        transform.rotation = Quaternion.Euler(startingAngle);
    }

    // Update is called once per frame
    void Update()
    {

        if (startRot)
        {
            if (isQuat)
            {
                transform.Rotate(rotationPerAngle * Time.deltaTime, Space.Self);
            }
            else
            {
                //transform.eulerAngles += rotationPerAngle * Time.deltaTime;
                transform.localEulerAngles += rotationPerAngle * Time.deltaTime;
                
            }
        }
        else
        {
            transform.rotation = Quaternion.Euler(startingAngle);
        }
        
    }
}
