using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using static Unity.Mathematics.noise;

public class GenerateWithNoise : MonoBehaviour
{
    [SerializeField] GameObject buildingBlock;

    [SerializeField] Vector2 playfield;

    [SerializeField] Vector2 offset;

    [SerializeField] float frequency;


    enum Noises { perlinBuildIn, perlin, simplex, cellular };

    [SerializeField] Noises currNoise;

    GameObject[,] blockWorld;
    // Start is called before the first frame update
    void Start()
    {
        blockWorld = new GameObject[(int)playfield.x, (int)playfield.y];

        buildWorld();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            recalculateWorld();

        }

        
    }

    float getNoise(float x, float y, float seed, float scale = 1)
    {
        float noiseValue = 0;
        if (currNoise == Noises.perlinBuildIn)
        {
            noiseValue = Mathf.PerlinNoise(x * scale + seed, y * scale + seed);
        }
        else if (currNoise == Noises.perlin) {
            noiseValue = noise.cnoise(new Vector2(x * scale + seed, y * scale + seed));
        }
        else if (currNoise == Noises.simplex)
        {
            noiseValue = noise.snoise(new Vector2(x * scale + seed, y * scale + seed));
        }
        else if (currNoise == Noises.cellular)
        {
            noiseValue = noise.cellular(new Vector2(x * scale + seed, y * scale + seed)).x;
        }


        


        return noiseValue;

        
    }



    void ChangeMaterial(MeshRenderer blockRenderer, float colorNoise)
    {
        Color color = new Color(colorNoise, colorNoise, colorNoise, 1);
        blockRenderer.material.color = color;
    }

    void ChangeHeight(GameObject thisObj, float newY, float additionalScale = 1)
    {
        Vector3 newPos = thisObj.transform.position;

        newPos.y = newY * additionalScale;

        thisObj.transform.position = newPos;
    }

    void recalculateWorld()
    {
        float newNoise = UnityEngine.Random.Range(0, 10000);
        for (int i = 0; i < playfield.x; i++)
        {
            for (int j = 0; j < playfield.y; j++)
            {
                
                float newColor = getNoise( ((float)i/ playfield.x), ((float)j / playfield.y), newNoise, frequency);
                Debug.Log(newColor);
                ChangeMaterial(blockWorld[i, j].transform.GetComponent<MeshRenderer>(), newColor);

                ChangeHeight(blockWorld[i, j], newColor);

            }
        }
    }

    void buildWorld()
    {
        for (int i = 0; i < playfield.x; i++)
        {
            for (int j = 0; j < playfield.y; j++)

            {
                Vector3 currPos = new Vector3(i*offset.x, 1, j*offset.y);
                GameObject currObj = Instantiate(buildingBlock, currPos, Quaternion.identity);
                blockWorld[i, j] = currObj;
            }
        }
    }
}
