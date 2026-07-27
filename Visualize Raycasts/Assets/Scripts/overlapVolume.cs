using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class overlapVolume : MonoBehaviour
{
    [SerializeField] float radius = 5;

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
        Collider[] overlappedObj = Physics.OverlapSphere(transform.position,radius);

        // reticle.transform.position = transform.position;

        // reticle.transform.localScale = new Vector3(2*radius, 2*radius, 2*radius);

        // Collider[] overlappedObjBox = Physics.OverlapBox(transform.position, new Vector3(0.5f,0.5f, 0.5f), transform.rotation);

        if (overlappedObj.Length!=0)
        {
            foreach (var overlapped in overlappedObj)
            {
                Debug.Log(overlapped.transform.name);
            }

            
        }


    }
}
