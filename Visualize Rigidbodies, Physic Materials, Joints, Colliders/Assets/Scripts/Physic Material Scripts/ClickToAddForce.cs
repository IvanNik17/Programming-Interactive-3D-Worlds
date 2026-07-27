using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickToAddForce : MonoBehaviour
{
    [SerializeField]
    float force = 0f;

    [SerializeField]
    bool randomDir = false;

    [SerializeField]
    Vector3 startPos = Vector3.zero;
    [SerializeField]
    Vector3 endPos = Vector3.zero;

    [SerializeField]
    GameObject selectedObj;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (randomDir)
        {
            addRandomForce();

        }
        else
        {
            addDirectedForce();
        }

        
        
    }

    void addDirectedForce()
    {

        force = 10;

        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            
            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log("HERE");
                if (hit.transform.tag == "Player")
                {

                    selectedObj = hit.transform.gameObject;
                }
            }
        }



        if (Input.GetMouseButtonDown(1))
        {
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = 3f;
            startPos = Camera.main.ScreenToWorldPoint(mousePos);
        }

        if (Input.GetMouseButtonUp(1))
        {
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = 3f;
            endPos = Camera.main.ScreenToWorldPoint(mousePos);

            if (selectedObj != null)
            {
                selectedObj.transform.GetComponent<Rigidbody>().AddForce((endPos - startPos).normalized * force, ForceMode.Impulse);
            }
            

        }


    }




    void addRandomForce()
    {
        RaycastHit hit;

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Input.GetMouseButton(0))
        {
            force += 0.01f;
        }


        if (Input.GetMouseButtonUp(0))
        {
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.tag == "Player")
                {

                    hit.transform.GetComponent<Rigidbody>().AddForce(Random.insideUnitCircle.normalized * force, ForceMode.Impulse);

                }
            }

            force = 0;
        }
    }
}
