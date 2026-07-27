using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveFlail : MonoBehaviour
{
    GameObject handle;
    // Start is called before the first frame update

    [SerializeField]
    float speed = 10f;
    [SerializeField]
    float minDist = 0.5f;

    void Start()
    {
        handle = transform.Find("link1").gameObject;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        int layerMask = 1 << 6;
        //layerMask = ~layerMask;
        
        if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask))
        {
            Vector3 hitPos = hit.point;

            Debug.Log(hit.transform.name);
            //hitPos.y += 3f;

            if (Vector3.Distance(hitPos, handle.transform.position) > minDist)
            {
                Vector3 direction = (hitPos - handle.transform.position).normalized;
                handle.transform.GetComponent<Rigidbody>().velocity = direction * speed;

            }
            else
            {
                handle.transform.GetComponent<Rigidbody>().velocity = Vector3.zero;
            }
            
        }
    }
}
