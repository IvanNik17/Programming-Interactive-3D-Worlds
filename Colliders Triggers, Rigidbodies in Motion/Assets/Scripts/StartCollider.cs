using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartCollider : MonoBehaviour
{
    [SerializeField]
    GameObject secondObj;

    private void Awake()
    {
        
        secondObj.SetActive(false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Player")
        {
            secondObj.SetActive(true);
        }
        
    }
}
