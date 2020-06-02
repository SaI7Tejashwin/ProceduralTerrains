using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(MeshFilter))]  //ensures that we are referencing the meshFilter of the object that contains this script

public class RenderTerrain : MonoBehaviour
{
    Mesh mesh;

    private Vector3[] vertices;
    private int[] triangles;

    public int xVerts = 50;
    public int zVerts = 50;


    void Start()
    {
        mesh = new Mesh();

        GetComponent<MeshFilter>().mesh = mesh;

        StartCoroutine(CreateMesh());
        
    }

    void Update()
    {
        UpdateMesh();
    }

    IEnumerator CreateMesh()
    {
        vertices = new Vector3[(xVerts + 1) * (zVerts + 1)];
        
           for(int i = 0, z = 0; z <= zVerts; z++)
             {
                for(int x = 0; x <= xVerts; x++)
                {

                float y = Mathf.PerlinNoise(x * .4f, z * .4f) * 2f;
                    vertices[i] = new Vector3(x, y, z);
                    i++;
                }
            }


        triangles = new int[xVerts * zVerts * 6];
        int tris = 0;
        int vert = 0;

        for(int z = 0; z < zVerts; z++)
        {
            for (int i = 0; i < xVerts; i++)
            {
                triangles[tris + 0] = vert + 0;
                triangles[tris + 1] = vert + xVerts + 1;
                triangles[tris + 2] = vert + 1;                 //this whole for loop creates a quad mesh.
                triangles[tris + 3] = vert + 1;
                triangles[tris + 4] = vert + xVerts + 1;
                triangles[tris + 5] = vert + xVerts + 2;

                tris += 6;
                vert++;

                yield return new WaitForSeconds(.00001f);
            }
            vert++;
        }
    
        
        
    }

     void UpdateMesh()
    {
        mesh.Clear();

        mesh.vertices = vertices;
        mesh.triangles = triangles;

        mesh.RecalculateNormals();

        MeshCollider meshCollider = gameObject.GetComponent<MeshCollider>();  //adds a mesh collider to your mesh.

        meshCollider.sharedMesh = mesh;

    }

  /*  private void OnDrawGizmos()
    {
        for(int i = 0; i < vertices.Length; i++)        //you can visualize the vertices using gizmos.
        {
            Gizmos.DrawSphere(vertices[i], .1f);
        }
    }*/
}
