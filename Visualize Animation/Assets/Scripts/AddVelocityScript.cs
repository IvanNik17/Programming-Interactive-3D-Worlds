using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddVelocityScript : MonoBehaviour
{

    [SerializeField]
    Vector3 v3Force;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void FixedUpdate()
    {
        GetComponent<Rigidbody>().AddForce(v3Force);
    }
}
