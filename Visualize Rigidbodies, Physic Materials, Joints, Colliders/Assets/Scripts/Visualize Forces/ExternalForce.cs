using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExternalForce : MonoBehaviour
{

    [SerializeField]
    GameObject barrel;

    [SerializeField]
    bool explode = false;

    [SerializeField]
    float forceMax = 20f;

    [SerializeField]
    float minForceDistance = 100f;
    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        if (explode)
        {
            float dist = Vector3.Distance(transform.position, barrel.transform.position);

            float force = (1 - Mathf.Clamp01(dist / minForceDistance)) * forceMax;

            Vector3 direction = (barrel.transform.position - transform.position).normalized;
            barrel.transform.GetComponent<Rigidbody>().AddForceAtPosition(direction * force, transform.position, ForceMode.Impulse);

           
            explode = false;
        }
    }
}
