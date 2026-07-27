using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventSender : MonoBehaviour
{
    public delegate void EventDelegateExample();

    public static event EventDelegateExample ButtonEvent;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (ButtonEvent!=null)
            {
                ButtonEvent();
            }
        }
    }
}
