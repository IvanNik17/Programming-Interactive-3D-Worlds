using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventReceiver1 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        EventSender.ButtonEvent += RotateSphere;  
    }

    void OnDisable()
    {
        EventSender.ButtonEvent -= RotateSphere;
    }


    void RotateSphere()
    {

        transform.Rotate(new Vector3(Random.value, Random.value, Random.value));
    }
}
