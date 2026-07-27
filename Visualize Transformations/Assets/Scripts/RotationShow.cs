using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationShow : MonoBehaviour
{

    public bool running = false;

    public SpacesOptions optionsRelativeTo = new SpacesOptions();

    public Vector3 eulerRotation;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (running)
        {

            Space rotSpace = Space.World;

            if (optionsRelativeTo == SpacesOptions.self)
            {
                rotSpace = Space.Self;
            }

            //transform.rotation* eulerRotation

            transform.Rotate(eulerRotation * Time.deltaTime, rotSpace);
        }   
    }
}
