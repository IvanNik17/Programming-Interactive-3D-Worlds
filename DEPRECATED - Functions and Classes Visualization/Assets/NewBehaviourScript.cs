using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField]
    private string myName;
    // Start is called before the first frame update
    void Start()
    {
        int x = 1;

        Debug.Log($"x is {x}");

        string y_inout;
        x = addVals(x, out y_inout);

        Debug.Log($"x is now {x}, y is now {y_inout}");


        

    
    }


    int addVals(int x, out string y)
    {
        y = x.ToString();
        x++;

        return x;
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
