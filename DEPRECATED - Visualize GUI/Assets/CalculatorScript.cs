using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CalculatorScript : MonoBehaviour
{
    [SerializeField] GameObject showField;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setNumber(int num)
    {
        
        showField.GetComponent<TMP_InputField>().text = num.ToString();
        Debug.Log($"{num}");
    }



 
}
