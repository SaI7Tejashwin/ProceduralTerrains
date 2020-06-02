using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateVoxels : MonoBehaviour
{
    public GameObject blockType;


    public float amp = 10f;



    //Creating an inefficient but assuring way of creating a voxelated terrain usin 1X1X1 unit boxes.
    void Start()
    {
        for (int i = 0; i < 100; i++)
        {
            for (int j = 0; j < 100; j++)
            {

                float y = Mathf.PerlinNoise(i / 10f , j / 10f ) * amp;
                y = Mathf.Floor(y);
                Instantiate(blockType, new Vector3(i, y, j), Quaternion.identity);
            }
        }
    }
}


       
