using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpTrigger : MonoBehaviour
{
    [SerializeField]
    float trust = 1000f;

    private void OnTriggerEnter(Collider other)
    {

        other.transform.GetComponent<Rigidbody>().AddForce(transform.up * trust);
    }

}
