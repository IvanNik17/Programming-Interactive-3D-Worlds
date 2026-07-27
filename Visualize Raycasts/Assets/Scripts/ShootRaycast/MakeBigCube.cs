using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeBigCube : MonoBehaviour
{
    public GameObject partPrefab;


    public void CreateBroken(Transform target)
    {
        float partSize = partPrefab.transform.localScale.x;
        GameObject holder = new GameObject("targetPartHolder");

        holder.transform.position = Vector3.one * partSize * 7f / 2f;

        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                for (int k = 0; k < 8; k++)
                {
                    Vector3 position = new Vector3(i * partSize, j * partSize, k * partSize);
                    GameObject partObj = Instantiate(partPrefab, position, Quaternion.identity);
                    partObj.transform.parent = holder.transform;

                }
                
            }
        }

        holder.transform.position = target.position;
        holder.transform.rotation = target.rotation;
    }
}
