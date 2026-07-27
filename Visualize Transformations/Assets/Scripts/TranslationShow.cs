using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SpacesOptions
{
    self,
    world,
    parent
};


public enum TranslateDir
{
    up,
    down,
    left,
    right
};

public enum AxisOptions
{
    worldAxis,
    localAxis
};

public enum TranslateFunction
{
    builtIn,
    custom
};


public class TranslationShow : MonoBehaviour
{

    public bool running = false;

    public SpacesOptions optionsRelativeTo = new SpacesOptions();
    public TranslateDir optionsDir = new TranslateDir();
    public AxisOptions optionsAxis = new AxisOptions();

    public TranslateFunction optionsFunction = new TranslateFunction();


    // Update is called once per frame
    void Update()
    {
        if (running)
        {


            Vector3 dir = chooseDir(optionsDir, optionsAxis);
            Space relativeTo = Space.World;

            if (optionsRelativeTo == SpacesOptions.self)
            {
                relativeTo = Space.Self;
            }


            if (optionsFunction == TranslateFunction.builtIn)
            {
                transform.Translate(dir * Time.deltaTime, relativeTo);
            }
            else
            {
                TranslateCustom(dir * Time.deltaTime, optionsRelativeTo);
            }
            
        }
        
    }


    //https://gamedev.stackexchange.com/questions/154368/how-to-move-object-on-local-space-not-object-space-in-unity
    public void TranslateCustom(Vector3 translation, SpacesOptions ralativeTo)
    {
        switch (ralativeTo)
        {
            case SpacesOptions.world:
                transform.position += translation;
                break;
            case SpacesOptions.self:
                transform.position += transform.rotation * translation;
                break;
            case SpacesOptions.parent:
                // Fall back on world space if there's no parent.
                Quaternion rotation = Quaternion.identity;
                if (transform.parent != null)
                    rotation = transform.parent.rotation;
                transform.position += rotation * translation;
                break;
        }
    }



    Vector3 chooseDir(TranslateDir dir, AxisOptions axis)
    {
        Vector3 returnDir = Vector3.zero;
        
        if (axis == AxisOptions.localAxis)
        {
            switch (dir)
            {
                case TranslateDir.up:
                    returnDir = transform.up;
                    break;
                case TranslateDir.down:
                    returnDir = -transform.up;
                    break;
                case TranslateDir.right:
                    returnDir = transform.right;
                    break;
                case TranslateDir.left:
                    returnDir = -transform.right;
                    break;
                default:
                    break;
            }
        }
        else if (axis == AxisOptions.worldAxis)
        {
            switch (dir)
            {
                case TranslateDir.up:
                    returnDir = Vector3.up;
                    break;
                case TranslateDir.down:
                    returnDir = Vector3.down;
                    break;
                case TranslateDir.right:
                    returnDir = Vector3.right;
                    break;
                case TranslateDir.left:
                    returnDir = Vector3.left;
                    break;
                default:
                    break;
            }
        }

        return returnDir;
    }




}
