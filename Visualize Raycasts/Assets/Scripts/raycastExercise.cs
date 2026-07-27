using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class raycastExercise : MonoBehaviour
{

    [SerializeField] float maxDistance = 100;
    [SerializeField] GameObject reticlePrefab;

    GameObject reticle;
    // Start is called before the first frame update
    void Start()
    {
        reticle = Instantiate(reticlePrefab, new Vector3(0,0,0), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {

        RaycastHit hit;
        Vector3 direction = transform.forward;
        if (Physics.Raycast(transform.position, direction, out hit, maxDistance)){

            Debug.Log($"Distance {hit.distance}");

            reticle.transform.position = hit.point;

            reticle.transform.forward = hit.normal;


        }
        else{
            reticle.transform.position = new Vector3(0,0,0);
        }
    }
}
