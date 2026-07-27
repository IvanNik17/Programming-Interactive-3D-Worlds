using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionForce : MonoBehaviour
{

    [SerializeField]
    bool explode = false;


    [SerializeField]
    GameObject barrel;

    [SerializeField]
    float radius = 5f;

    [SerializeField]
    float force = 10f;

    [SerializeField]
    float uplift = 5f;



    // Update is called once per frame
    void Update()
    {

        if (explode)
        {
            barrel.transform.GetComponent<Rigidbody>().AddExplosionForce(force, transform.position, radius, uplift, ForceMode.Impulse);

            explode = false;
        }
        
    }
}
