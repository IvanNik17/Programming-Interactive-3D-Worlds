using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CharNavigation : MonoBehaviour
{
    [SerializeField]
    private Transform targetTransform;
    NavMeshAgent charAgent;

    
    // Start is called before the first frame update
    void Awake()
    {
        charAgent = GetComponent<NavMeshAgent>();

        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            charAgent.destination = targetTransform.position;
            
        }
        
    }
}
