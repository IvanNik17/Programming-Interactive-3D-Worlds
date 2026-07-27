using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushBall : MonoBehaviour
{
    [SerializeField] GameObject pushObj;
    float speed = 3f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //pushObj.transform.Translate(new Vector3(-4f, 0, 0));
            pushObj.transform.GetComponent<Rigidbody>().velocity = -pushObj.transform.right * speed;
        }

        if (pushObj.transform.position.x <= 2f)
        {
            pushObj.transform.GetComponent<Rigidbody>().velocity = Vector3.zero;
        }
    }
}
