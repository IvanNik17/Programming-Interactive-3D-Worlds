using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFollow : MonoBehaviour
{
    public GameObject follower;
    public int maxNum = 50;
    int counter = 0;
    void Start()
    {
        
        StartCoroutine("Spawn");
    }
    IEnumerator Spawn()
    {
        while (counter < maxNum)
        {
            //Debug.Log(follower.transform.position);
            Instantiate(follower, Vector3.zero, Random.rotation);
            
            counter++;
            yield return new WaitForSeconds(1f);
        }
    }
}
