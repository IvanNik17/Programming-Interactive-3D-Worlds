using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopExplodeTrigger : MonoBehaviour
{
    [SerializeField]
    GameObject fireworkHolder;



    private void OnTriggerEnter(Collider other)
    {
        other.transform.GetComponent<Rigidbody>().velocity = Vector3.zero;

        Rigidbody[] allRigids = fireworkHolder.GetComponentsInChildren<Rigidbody>();

        foreach (Rigidbody childRigid in allRigids)
        {
            childRigid.AddForce(Random.insideUnitCircle.normalized * Random.Range(500, 1000)); 
        }
    }
}
