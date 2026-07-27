using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    [SerializeField]
    GameObject objCamera;

    [SerializeField]
    GameObject objPlayer;

    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        Vector3 currPos = objCamera.transform.position;
        currPos.y = objPlayer.transform.position.y;
        objCamera.transform.position = currPos;
    }
}
