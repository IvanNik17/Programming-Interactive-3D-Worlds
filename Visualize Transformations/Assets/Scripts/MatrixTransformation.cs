using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatrixTransformation : MonoBehaviour
{
    private MatrixSelect selectMatrix;

    // Start is called before the first frame update
    void Start()
    {
        selectMatrix = transform.GetComponent<MatrixSelect>();
    }

    // Update is called once per frame
    void Update()
    {

        Matrix4x4 currTransform = selectMatrix.translationMat;

        if (Input.GetKey(KeyCode.A))
        {
           
            Vector3 translate = ExtractPosition(currTransform);
            transform.Translate(translate * Time.deltaTime, Space.World);
        }


        if (Input.GetKey(KeyCode.S))
        {

            Vector3 scale = ExtractScale(currTransform);
            transform.localScale += scale * Time.deltaTime;
        }


        //0 -1 0   1 0 0   0 0 1 Rz
        if (Input.GetKey(KeyCode.D))
        {

            Quaternion rotation = ExtractRotation(currTransform);

            transform.rotation = Quaternion.RotateTowards(transform.rotation, transform.rotation * rotation, Time.deltaTime * 10);
            
        }
    }


    private Vector3 ExtractPosition(Matrix4x4 matrix)
    {
        Vector3 position;
        position.x = matrix.m03;
        position.y = matrix.m13;
        position.z = matrix.m23;
        return position;
    }

    private Vector3 ExtractScale(Matrix4x4 matrix)
    {
        Vector3 scale;
        scale.x = new Vector4(matrix.m00, matrix.m10, matrix.m20, matrix.m30).magnitude;
        scale.y = new Vector4(matrix.m01, matrix.m11, matrix.m21, matrix.m31).magnitude;
        scale.z = new Vector4(matrix.m02, matrix.m12, matrix.m22, matrix.m32).magnitude;
        return scale;
    }

    public Quaternion ExtractRotation(Matrix4x4 matrix)
    {
        float w = Mathf.Sqrt(1.0f + matrix.m00 + matrix.m11 + matrix.m22) / 2.0f;
        float w4 = (4.0f * w);
        float x = (matrix.m21 - matrix.m12) / w4;
        float y = (matrix.m02 - matrix.m20) / w4;
        float z = (matrix.m10 - matrix.m01) / w4;

        Quaternion rotation = new Quaternion(x, y, z, w);

        return rotation;
    }

}
