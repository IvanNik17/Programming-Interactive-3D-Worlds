using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerAnim : MonoBehaviour
{
    [SerializeField] GameObject animSphere;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {

        animSphere.GetComponentInChildren<Animator>().SetTrigger("Change");
    }
}
