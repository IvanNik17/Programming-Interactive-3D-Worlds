using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWithMouse : MonoBehaviour
{
    // Start is called before the first frame update

    Light childLight;
    void Start()
    {
        if (transform.GetComponentInChildren<Light>() != null)
        {
            childLight = transform.GetComponentInChildren<Light>();
        }
    }

    // Update is called once per frame
    void Update()
    {

        childLight.intensity += Input.mouseScrollDelta.y;

        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 3f;
        Vector3 movePos = Camera.main.ScreenToWorldPoint(mousePos);

        
        transform.position = movePos;
    }
}
