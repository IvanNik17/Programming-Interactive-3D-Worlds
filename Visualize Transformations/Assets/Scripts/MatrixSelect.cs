using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MatrixSelect : MonoBehaviour
{


    public GameObject matrixHolder;

    public Matrix4x4 translationMat;
    // Start is called before the first frame update
    void Start()
    {
        translationMat = new Matrix4x4();
    }


    public void CalculateMatrix()
    {
        int cellCounter = 0;
        int rowCounter = 0;
        Vector4 currRow = Vector4.zero;
        foreach (Transform cell in matrixHolder.transform)
        {
            string currText = cell.GetComponent<TMP_InputField>().text;

            float cellInput;
            
            

            
            if (float.TryParse(currText, out cellInput))
            {
                //Debug.Log(cellInput);
                currRow[cellCounter] = cellInput;
            }

            cellCounter++;

            if (cellCounter == 4)
            {
                Debug.Log(currRow);
                translationMat.SetRow(rowCounter, currRow);
                cellCounter = 0;
                currRow = Vector4.zero;
                rowCounter++;
            }



        }

        Debug.Log(translationMat);
    }
}
