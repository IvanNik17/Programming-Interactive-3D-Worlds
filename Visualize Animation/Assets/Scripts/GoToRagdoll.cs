using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToRagdoll : MonoBehaviour
{
    // Start is called before the first frame update
    public Collider[] AllColliders;
    void Awake()
    {
        AllColliders = GetComponentsInChildren<Collider>();
        changeRagdoll(false);
    }

    public void changeRagdoll(bool isRagdoll) {

        foreach (var col in AllColliders) {
            col.enabled = isRagdoll;
        }
        GetComponent < Rigidbody>().useGravity = !isRagdoll;
        GetComponent<Animator>().enabled = !isRagdoll;

    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)) {

            changeRagdoll(true);


        }
    }
}
