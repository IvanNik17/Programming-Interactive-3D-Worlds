using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootRaycast : MonoBehaviour
{
    public GameObject raycastObj;

    public GameObject reticlePrefab;

    public ParticleSystem muzzleFlash;

    GameObject reticleObj;

    public Material[] dotMat;

    Renderer dotRend;

    MakeBigCube makePartsScript;
    // Start is called before the first frame update
    void Start()
    {
        reticleObj = Instantiate(reticlePrefab);
        dotRend = reticleObj.GetComponent<Renderer>();
        reticleObj.SetActive(false);

        makePartsScript = transform.GetComponent<MakeBigCube>();
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit = raycastDetect();

        
        shoot(hit);
    }


    void shoot(RaycastHit hit)
    {
        if (Input.GetMouseButton(0))
        {
            
            muzzleFlash.Play();

            if (hit.transform != null)
            {
                dotRend.material = dotMat[1];

                if (hit.transform.GetComponent<Rigidbody>() != null)
                {
                    hit.transform.GetComponent<Rigidbody>().AddForceAtPosition(Random.insideUnitCircle.normalized * 100f, hit.point);
                }
                

                if (hit.transform.tag == "target")
                {
                    

                    makePartsScript.CreateBroken(hit.transform);

                    Destroy(hit.transform.gameObject);
                }
                

                
            }

        }
        else
        {
            dotRend.material = dotMat[0];
        }
    }  


    RaycastHit raycastDetect()
    {
        RaycastHit hit;

        Vector3 direction = raycastObj.transform.forward;
        Vector3 position = raycastObj.transform.position;

        
        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(position, direction, out hit, Mathf.Infinity))
        {

            Debug.DrawRay(position, direction * hit.distance, Color.yellow);

            reticleObj.transform.position = hit.point;

            if (!reticleObj.activeSelf)
            {
                reticleObj.SetActive(true);
            }


        }
        else
        {
            Debug.DrawRay(position, direction * 1000, Color.white);

            if (reticleObj.activeSelf)
            {
                reticleObj.SetActive(false);
            }

        }


        return hit;
    }



}
