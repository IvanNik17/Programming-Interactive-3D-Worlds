using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Generate3DWithNoise : MonoBehaviour
{

    [SerializeField] GameObject buildingBlock;

    [SerializeField] Vector3 playfield;

    [SerializeField] Vector2 offset;

    [SerializeField] float frequency;

    [SerializeField] float threhold = 0.5f;


    enum Noises { perlin, simplex, cellular };

    [SerializeField] Noises currNoise;

    GameObject[,,] blockWorld;

    // Start is called before the first frame update
    void Start()
    {
        blockWorld = new GameObject[(int)playfield.x, (int)playfield.y, (int)playfield.z];

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


    float getNoise(float x, float y, float z,  float seed, float scale = 1)
    {
        float noiseValue = 0;
        if (currNoise == Noises.perlin)
        {
            noiseValue = noise.cnoise(new Vector3(x * scale + seed, y * scale + seed, z * scale + seed));
            
        }
        else if (currNoise == Noises.simplex)
        {
            noiseValue = noise.snoise(new Vector3(x * scale + seed, y * scale + seed, z * scale + seed));
        }
        else if (currNoise == Noises.cellular)
        {
            noiseValue = noise.cellular(new Vector3(x * scale + seed, y * scale + seed, z * scale + seed)).x;
        }

        return noiseValue;


    }

    void recalculateWorld()
    {
        float newSeed = UnityEngine.Random.Range(0, 10000);
        for (int xCoord = 0; xCoord < playfield.x; xCoord++)
        {
            for (int yCoord = 0; yCoord < playfield.y; yCoord++)

            {
                for (int zCoord = 0; zCoord < playfield.y; zCoord++)

                {
                    
                    float newNoise = getNoise(((float)xCoord / playfield.x), ((float)yCoord / playfield.y), ((float)zCoord / playfield.z), newSeed, frequency);


                    if (newNoise < threhold)
                    {
                        blockWorld[xCoord, yCoord, zCoord].SetActive(false);

                    }
                    else 
                    {
                        blockWorld[xCoord, yCoord, zCoord].SetActive(true);
                    }

                }
                
            }
        }
    }

    void buildWorld()
    {
        for (int xCoord = 0; xCoord < playfield.x; xCoord++)
        {
            for (int yCoord = 0; yCoord < playfield.y; yCoord++)

            {
                for (int zCoord = 0; zCoord < playfield.y; zCoord++)

                {
                    Vector3 currPos = new Vector3(xCoord * offset.x, yCoord * offset.x, zCoord * offset.y);
                    GameObject currObj = Instantiate(buildingBlock, currPos, Quaternion.identity);
                    blockWorld[xCoord, yCoord, zCoord] = currObj;

                }

            }
        }
    }
}
