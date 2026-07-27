using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PhysicsMovementOptions
{
    velocity,
    acceleration,
    force,
    velocityChange,
    pulse
};


public class ShowForces : MonoBehaviour
{
    [SerializeField]
    float force = 10f;

    [SerializeField]
    bool torque = false;

    [SerializeField]
    bool start = false;

    [SerializeField]
    PhysicsMovementOptions currOption;

    Vector3 startPos;
    // Start is called before the first frame update
    void Start()
    {
        currOption = new PhysicsMovementOptions();
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (start)
        {
            if (torque)
            {
                torqueAdd();
            }
            else
            {
                forceAdd();
            }

        }
        else
        {
            transform.GetComponent<Rigidbody>().velocity = new Vector3(0f, 0f, 0f);
            transform.GetComponent<Rigidbody>().angularVelocity = new Vector3(0f, 0f, 0f);
            transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, 0f));
            transform.position = startPos;
        }
        

    }


    void forceAdd()
    {
        if (currOption == PhysicsMovementOptions.velocity)
        {
            transform.GetComponent<Rigidbody>().velocity = Vector3.right * force;
        }
        else if (currOption == PhysicsMovementOptions.force)
        {
            transform.GetComponent<Rigidbody>().AddForce(Vector3.right * force, ForceMode.Force);
            
        }
        else if (currOption == PhysicsMovementOptions.acceleration)
        {
            transform.GetComponent<Rigidbody>().AddForce(Vector3.right * force, ForceMode.Acceleration);
        }
        else if (currOption == PhysicsMovementOptions.velocityChange)
        {
            transform.GetComponent<Rigidbody>().AddForce(Vector3.right * force, ForceMode.VelocityChange);
        }
        else if (currOption == PhysicsMovementOptions.pulse)
        {
            transform.GetComponent<Rigidbody>().AddForce(Vector3.right * force, ForceMode.Impulse);

            
        }
    }


    void torqueAdd()
    {
        
        if (currOption == PhysicsMovementOptions.force)
        {
            transform.GetComponent<Rigidbody>().AddTorque(Vector3.right * force, ForceMode.Force);
        }
        else if (currOption == PhysicsMovementOptions.acceleration)
        {
            transform.GetComponent<Rigidbody>().AddTorque(Vector3.right * force, ForceMode.Acceleration);
        }
        else if (currOption == PhysicsMovementOptions.velocityChange)
        {
            transform.GetComponent<Rigidbody>().AddTorque(Vector3.right * force, ForceMode.VelocityChange);
        }
        else if (currOption == PhysicsMovementOptions.pulse)
        {
            transform.GetComponent<Rigidbody>().AddTorque(Vector3.right * force, ForceMode.Impulse);
        }
    }
}
