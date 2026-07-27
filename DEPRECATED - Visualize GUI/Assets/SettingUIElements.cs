using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SettingUIElements : MonoBehaviour
{
    [SerializeField]
    private TMP_Text textHeader;

    [SerializeField]
    private Toggle toggleButton;



    // Start is called before the first frame update
    void Start()
    {
        textHeader.color = Color.red;
        textHeader.text = "Here is a header";


        toggleButton.onValueChanged.AddListener((value) => toggleValueChanged(value));



    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log($"Number of words - {textHeader.textInfo.wordCount}");


       
    }


    public void toggleValueChanged(bool value)
    {
        Debug.Log($"The value is currently {value}");

    }

}
