using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRandom : MonoBehaviour
{

    public GameObject targetPrefab;

    public GameObject ground;

    float groundSize;

    float spawnTimer = 2f;

    float currTime = 0f;
    // Start is called before the first frame update
    void Start()
    {
        groundSize = ground.transform.localScale.x;
    }

    // Update is called once per frame
    void Update()
    {

        currTime += Time.deltaTime;

        if (currTime >= spawnTimer)
        {
            Vector3 spawnPos = new Vector3(Random.Range(ground.transform.position.x - groundSize / 2f, ground.transform.position.x + groundSize / 2f), 4f,
                                            Random.Range(ground.transform.position.z - groundSize / 2f, ground.transform.position.z + groundSize / 2f));

            Instantiate(targetPrefab, spawnPos, Quaternion.identity);
            currTime = 0;
        }
    }
}
