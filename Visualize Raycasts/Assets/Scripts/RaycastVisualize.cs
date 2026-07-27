using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastVisualize : MonoBehaviour
{

    public GameObject hitPrefab;

    GameObject hitObj;

    LineRenderer raycastLineRenderer;
    // Start is called before the first frame update
    void Start()
    {
        hitObj = Instantiate(hitPrefab);

        hitObj.SetActive(false);

        
        raycastLineRenderer = transform.GetComponent<LineRenderer>();
        raycastLineRenderer.startWidth = 0.1f;
        raycastLineRenderer.enabled = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        RaycastHit hit;

        Vector3 direction = transform.forward;



        //Vector3 direction = transform.TransformDirection(Vector3.forward);
        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(transform.position, direction, out hit, 100))
        {
            Debug.DrawRay(transform.position, direction * hit.distance, Color.yellow);

            if (!hitObj.activeSelf)
            {
                hitObj.SetActive(true);
            }

            Debug.DrawRay(hit.point, hit.normal * 5, Color.red);
            

            hitObj.transform.position = hit.point;

            raycastLineRenderer.enabled = true;

            raycastLineRenderer.SetPosition(0, transform.position);
            raycastLineRenderer.SetPosition(1, hit.point);

            raycastLineRenderer.startColor = Color.yellow;
            raycastLineRenderer.endColor = Color.yellow;
        }
        else
        {
            Debug.DrawRay(transform.position, direction * 1000, Color.white);

            if (hitObj.activeSelf)
            {
                hitObj.SetActive(false);
            }


            raycastLineRenderer.SetPosition(0, transform.position);
            raycastLineRenderer.SetPosition(1, transform.position + transform.forward *100);

            

            raycastLineRenderer.startColor = Color.white;
        }
    }
}
