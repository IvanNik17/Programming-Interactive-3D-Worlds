using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventReceiver2 : MonoBehaviour
{
    void Start()
    {
        EventSender.ButtonEvent += MoveSphere;
    }

    void OnDisable()
    {
        EventSender.ButtonEvent -= MoveSphere;
    }

    void MoveSphere()
    {

        transform.Translate(new Vector3(Random.value-0.5f, Random.value - 0.5f, Random.value - 0.5f));
    }
}
