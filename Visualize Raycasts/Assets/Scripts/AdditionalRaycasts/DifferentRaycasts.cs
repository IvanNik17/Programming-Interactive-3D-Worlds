using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DifferentRaycasts : MonoBehaviour
{

    [SerializeField]
    float radius = 1f;

    GameObject visSphere;

    Vector3 endPos = Vector3.zero;

    float sphereSpeed = 3f;
    bool showSphere = false;


    [SerializeField]
    GameObject overlapObj;


    // Start is called before the first frame update
    void Start()
    {
        visSphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        visSphere.transform.localScale = Vector3.one * 2 * radius;

        visSphere.GetComponent<Collider>().enabled = false;

        visSphere.SetActive(false);

        int decimalNumber = 1<<6;

        Debug.Log(System.Convert.ToString(~decimalNumber, 2).PadLeft(16, '0'));

    }

    // Update is called once per frame
    void Update()
    {
        ////Raycast Sphere and visualizer combo
        SpherecastDemo();
        VisualizeSpherecast();

        // Raycast against all demo
        // RaycastAllDemo();

        ////Overlap sphere demo
        //OverlapSphereDemo();


    }



    void SpherecastDemo()
    {
        RaycastHit hit;

        Vector3 direction = transform.forward;

        

        if (Physics.SphereCast(transform.position, radius, direction, out hit, Mathf.Infinity))
        {

            Debug.DrawRay(transform.position, direction * 10f, Color.yellow);
            Debug.Log(hit.transform.name);

            endPos = direction * (hit.distance + (radius));

           


        }
        else
        {

            Debug.DrawRay(transform.position, direction * 10f, Color.red);
            endPos = transform.position + direction * 10f;
        }
    }

    void VisualizeSpherecast()
    {

        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            
            showSphere = !showSphere;
            visSphere.transform.position = transform.position;
        }

        if (showSphere)
        {

            visSphere.transform.position = Vector3.Lerp(transform.position, endPos, Mathf.PingPong(Time.time * sphereSpeed, 1.0f));
            visSphere.SetActive(true);
        }
        else
        {
            visSphere.SetActive(false);
        }
    }


    void RaycastAllDemo()
    {
        RaycastHit[] hits;

        Vector3 direction = transform.forward;

        hits = Physics.RaycastAll(transform.position, direction, 100f);

        Debug.DrawRay(transform.position, direction * 100f, Color.yellow);


        string allHitNames = "";
        for (int i = 0; i < hits.Length; i++)
        {
            RaycastHit hit = hits[i];

            allHitNames += " | " + hit.transform.name;
        }


        Debug.Log(allHitNames);
    }

    void OverlapSphereDemo()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, radius);
        overlapObj.transform.position = transform.position;
        overlapObj.transform.localScale = Vector3.one * 2 * radius;


        foreach (var hitCollider in hitColliders)
        {
            Debug.Log(hitCollider.transform.name);

            Vector3 hitPoint = hitCollider.ClosestPoint(transform.position);


            Vector3 hitDir = (hitPoint - transform.position);

            Debug.DrawRay(transform.position, hitDir, Color.yellow);

            //if (hitCollider.transform.GetComponent<ChangeColor>() != null)
            //{
            //    hitCollider.transform.GetComponent<ChangeColor>().isHovered = true;
            //}
        }
    }

}
