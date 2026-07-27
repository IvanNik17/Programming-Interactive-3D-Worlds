using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeHealth : MonoBehaviour
{
    [SerializeField] Image healthBar;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (healthBar.fillAmount>0)
            {
                healthBar.fillAmount -= 0.1f;
            }
            
        }

        if (Input.GetKeyDown(KeyCode.H))
        {
            if (healthBar.fillAmount <1)
            {
                healthBar.fillAmount += 0.1f;
            }
        }
    }



}
