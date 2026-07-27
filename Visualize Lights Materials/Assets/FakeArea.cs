using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FakeArea : MonoBehaviour
{
    [SerializeField]
    private GameObject pointLight;

    [SerializeField]
    private Vector2 numLights;


    // Start is called before the first frame update
    void Start()
    {

        Vector3 transformSize = transform.localScale;
        Vector3 transformPos = transform.position;

        float xSize = Mathf.Ceil(transformSize.x);
        float ySize = transformSize.y;


        float deltaX = transformSize.x / numLights[0];
        float deltaY = transformSize.y / numLights[1];

        float newIntensity = 1 / (numLights[0] * numLights[1]);

        for (float y = 0; y <= ySize; y+= deltaY)
        {
            for (float x = 0; x <= xSize; x+= deltaX)
            {
                float z = 0f;
                Vector3 pos = transformPos +  new Vector3(x, y, z) - transformSize/2;
                GameObject currLightObj = Instantiate(pointLight, pos, Quaternion.identity);

                currLightObj.GetComponent<Light>().intensity = newIntensity;
                currLightObj.transform.parent = transform;
            }
        }


        


    }

    
}
