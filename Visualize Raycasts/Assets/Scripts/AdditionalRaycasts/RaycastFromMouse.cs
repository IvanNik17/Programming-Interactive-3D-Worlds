using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastFromMouse : MonoBehaviour
{


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //Camera.main.ScreenToWorldPoint
        //Camera.main.ScreenToViewportPoint
        //Camera.main.ViewportToScreenPoint

        int layerMask = 1 << 6;
        //layerMask = ~layerMask;

        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask))
        {
            Debug.Log(hit.transform.name);
            Debug.Log($"We hit object {hit.transform.name}");

            Transform currHit = hit.transform;

            if (currHit.transform.TryGetComponent<ChangeColor>(out ChangeColor hoverColor))
            {
                hoverColor.isHovered = true;
            }

            


        }

    }
}
