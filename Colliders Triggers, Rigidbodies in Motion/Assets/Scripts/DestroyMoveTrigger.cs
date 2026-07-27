using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyMoveTrigger : MonoBehaviour
{
    [SerializeField]
    GameObject movableObj;

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "item_2")
        {
            movableObj.transform.GetComponent<Rigidbody>().velocity = movableObj.transform.up * 10f;
        }
        
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.name == "item_2")
        {
            movableObj.transform.GetComponent<Rigidbody>().velocity = Vector3.zero;
            Destroy(other.gameObject);
        }
        
    }
}
