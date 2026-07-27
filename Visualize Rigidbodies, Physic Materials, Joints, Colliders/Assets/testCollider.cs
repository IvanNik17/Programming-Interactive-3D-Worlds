using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testCollider : MonoBehaviour
{
    

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision started.");
    }

    private void OnCollisionStay(Collision collision)
    {
        Debug.Log("Collision continues.");
    }

    private void OnCollisionExit(Collision collision)
    {
        Debug.Log("Collision ended.");
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("An object entered.");
    }
    private void OnTriggerStay(Collider other)
    {
        Debug.Log("An object is still inside of the trigger");
    }
    private void OnTriggerExit(Collider other)
    {
        Debug.Log("An object left.");
    }
}
