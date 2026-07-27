using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPerson : MonoBehaviour
{

    [SerializeField]
    Transform target;

    [SerializeField]
    float timeChange = 10f;

    [SerializeField]
    Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void LateUpdate()
    {

        Quaternion mouseXRot = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * timeChange, transform.up);


        Quaternion mouseYRot = Quaternion.AngleAxis(-Input.GetAxis("Mouse Y") * timeChange, transform.right);


        Vector3 objRotation = mouseYRot.eulerAngles;
        //objRotation.y = Mathf.Clamp(objRotation.y, -70f, 70f);
        //mouseYRot = Quaternion.Euler(objRotation);
        Debug.Log(objRotation);
        


        offset = mouseYRot * mouseXRot * offset;

        //offset = mouseYRot * offset;





        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Slerp(transform.position, desiredPosition, timeChange * Time.deltaTime);
        transform.position = smoothedPosition;
        //transform.position = target.position + offset;

        transform.LookAt(target);


        //float x = Input.GetAxis("Mouse X");
        //float y = Input.GetAxis("Mouse Y");


        //transform.RotateAround(target.transform.position, transform.up, x * timeChange * Time.deltaTime);


        //transform.RotateAround(target.transform.position, transform.right, -y * timeChange * Time.deltaTime);


        //transform.LookAt(target);

        //Vector3 cameraRotation = transform.eulerAngles;


        //cameraRotation.y = Mathf.Clamp(cameraRotation.y, -90, 90);
        //cameraRotation.z = 0;

        //transform.eulerAngles = cameraRotation;




    }
}
