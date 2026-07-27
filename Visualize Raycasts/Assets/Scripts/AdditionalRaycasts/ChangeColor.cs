using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    public bool isHovered = false;

    [SerializeField]
    Material[] colorMat;
    Renderer currRenderer;
    // Start is called before the first frame update
    void Start()
    {
        currRenderer = transform.GetComponent<Renderer>();
        currRenderer.material = colorMat[0];
    }

    void LateUpdate()
    {
        if (isHovered)
        {
            currRenderer.material = colorMat[1];
        }
        else
        {
            currRenderer.material = colorMat[0];
        }

        isHovered = false;
    }

}
