using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Model
{

    internal List<Vector3Int> faces;
    List<Vector3Int> texture_index_list;
    internal List<Vector3> vertices;
    List<Vector2> texture_coordinates;
    List<Vector3> normals;


    public Model()
    {
        vertices = new List<Vector3>();
        addvertices();
        faces = new List<Vector3Int>();
        addfaces();

    }

    private void addfaces()
    {
        //Front faces
        faces.Add(new Vector3Int(1, 3, 4)); // 0
        faces.Add(new Vector3Int(0, 3, 1)); // 1
        faces.Add(new Vector3Int(0, 2, 11)); // 2 
        faces.Add(new Vector3Int(2, 10, 11)); // 3
        faces.Add(new Vector3Int(10, 14, 12)); // 4
        faces.Add(new Vector3Int(12, 14, 15)); // 5
        faces.Add(new Vector3Int(8, 15, 13)); // 6
        faces.Add(new Vector3Int(9, 8, 13)); // 7
        faces.Add(new Vector3Int(6, 8, 9)); // 8
        faces.Add(new Vector3Int(6, 5, 8)); // 9
        faces.Add(new Vector3Int(5, 7, 8)); // 10
        
        //Back faces
        faces.Add(new Vector3Int(17, 20, 19)); // 11
        faces.Add(new Vector3Int(16, 17, 19)); // 12
        faces.Add(new Vector3Int(16, 27, 18)); // 13 
        faces.Add(new Vector3Int(18, 27, 26)); // 14
        faces.Add(new Vector3Int(26, 28, 30)); // 15
        faces.Add(new Vector3Int(28, 31, 30)); // 16
        faces.Add(new Vector3Int(24, 29, 31)); // 17
        faces.Add(new Vector3Int(25, 29, 24)); // 18
        faces.Add(new Vector3Int(22, 25, 24)); // 19
        faces.Add(new Vector3Int(21, 22, 24)); // 20
        faces.Add(new Vector3Int(21, 24, 23)); // 21

        //Bottom faces
        faces.Add(new Vector3Int(15, 30, 31)); // 1
        faces.Add(new Vector3Int(14, 30, 15)); // 2
        faces.Add(new Vector3Int(8, 23, 24)); // 3
        faces.Add(new Vector3Int(7, 23, 8)); // 4
        faces.Add(new Vector3Int(4, 19, 20)); // 5
        faces.Add(new Vector3Int(3, 19, 4)); // 6

        //Top faces
        faces.Add(new Vector3Int(17, 16, 1)); // 1
        faces.Add(new Vector3Int(16, 0, 1)); // 2
        faces.Add(new Vector3Int(22, 21, 6)); // 3
        faces.Add(new Vector3Int(21, 5, 6)); // 4
        faces.Add(new Vector3Int(28, 27, 12)); // 5
        faces.Add(new Vector3Int(27, 11, 12)); // 6

        //Left side faces
        faces.Add(new Vector3Int(2, 18, 10)); // 1
        faces.Add(new Vector3Int(18, 26, 10)); // 2
        faces.Add(new Vector3Int(8, 24, 12)); // 3
        faces.Add(new Vector3Int(24, 28, 12)); // 4

        //Right side faces
        faces.Add(new Vector3Int(19, 3, 27)); // 1
        faces.Add(new Vector3Int(3, 11, 27)); // 2
        faces.Add(new Vector3Int(25, 9, 29)); // 3
        faces.Add(new Vector3Int(9, 13, 29)); // 4

        //Left Slances faces
        faces.Add(new Vector3Int(17, 1, 20)); // 1
        faces.Add(new Vector3Int(1, 4, 20)); // 2
        faces.Add(new Vector3Int(22, 6, 25)); // 3
        faces.Add(new Vector3Int(6, 9, 25)); // 4
        faces.Add(new Vector3Int(29, 13, 31)); // 5
        faces.Add(new Vector3Int(13, 15, 31)); // 6

        //Right Slances faces
        faces.Add(new Vector3Int(0, 16, 2)); // 1
        faces.Add(new Vector3Int(16, 18, 2)); // 2
        faces.Add(new Vector3Int(5, 21, 7)); // 3
        faces.Add(new Vector3Int(21, 23, 7)); // 4
        faces.Add(new Vector3Int(10, 26, 14)); // 5
        faces.Add(new Vector3Int(26, 30, 14)); // 6




    }

    private void addvertices()
    {
        vertices.Add(new Vector3(-2, 3, -1)); // 0
        vertices.Add(new Vector3(2, 3, -1)); // 1
        vertices.Add(new Vector3(-3, 2, -1)); // 2
        vertices.Add(new Vector3(-2, 2, -1)); // 3
        vertices.Add(new Vector3(3, 2, -1)); // 4
        vertices.Add(new Vector3(0, 1, -1)); // 5
        vertices.Add(new Vector3(2, 1, -1)); // 6
        vertices.Add(new Vector3(-1, 0, -1)); // 7
        vertices.Add(new Vector3(2, 0, -1)); // 8
        vertices.Add(new Vector3(3, 0, -1)); // 9
        vertices.Add(new Vector3(-3, -2, -1)); // 10
        vertices.Add(new Vector3(-2, -2, -1)); // 11
        vertices.Add(new Vector3(2, -2, -1)); // 12
        vertices.Add(new Vector3(3, -2, -1)); // 13
        vertices.Add(new Vector3(-2, -3, -1)); // 14
        vertices.Add(new Vector3(2, -3, -1)); // 15

        vertices.Add(new Vector3(-2, 3, 1));  // 16
        vertices.Add(new Vector3(2, 3, 1));   // 17
        vertices.Add(new Vector3(-3, 2, 1));  // 18
        vertices.Add(new Vector3(-2, 2, 1));  // 19
        vertices.Add(new Vector3(3, 2, 1));   // 20
        vertices.Add(new Vector3(0, 1, 1));   // 21
        vertices.Add(new Vector3(2, 1, 1));   // 22
        vertices.Add(new Vector3(-1, 0, 1));  // 23
        vertices.Add(new Vector3(2, 0, 1));   // 24
        vertices.Add(new Vector3(3, 0, 1));   // 25
        vertices.Add(new Vector3(-3, -2, 1)); // 26
        vertices.Add(new Vector3(-2, -2, 1)); // 27
        vertices.Add(new Vector3(2, -2, 1));  // 28
        vertices.Add(new Vector3(3, -2, 1));  // 29
        vertices.Add(new Vector3(-2, -3, 1)); // 30
        vertices.Add(new Vector3(2, -3, 1));  // 31






    }

    public GameObject CreateUnityGameObject()
    {
        Mesh mesh = new Mesh();
        GameObject newGO = new GameObject();

        MeshFilter mesh_filter = newGO.AddComponent<MeshFilter>();
        MeshRenderer mesh_renderer = newGO.AddComponent<MeshRenderer>();

        List<Vector3> coords = new List<Vector3>();
        List<int> dummy_indices = new List<int>();
        /*List<Vector2> text_coords = new List<Vector2>();
        List<Vector3> normalz = new List<Vector3>();*/

        for (int i = 0; i < faces.Count; i++)
        {
            //Vector3 normal_for_face = normals[i];

            //normal_for_face = new Vector3(normal_for_face.x, normal_for_face.y, -normal_for_face.z);

            coords.Add(vertices[faces[i].x]); dummy_indices.Add(i * 3); //text_coords.Add(texture_coordinates[texture_index_list[i].x]); normalz.Add(normal_for_face);

            coords.Add(vertices[faces[i].y]); dummy_indices.Add(i * 3 + 2); //text_coords.Add(texture_coordinates[texture_index_list[i].y]); normalz.Add(normal_for_face);

            coords.Add(vertices[faces[i].z]); dummy_indices.Add(i * 3 + 1); //text_coords.Add(texture_coordinates[texture_index_list[i].z]); normalz.Add(normal_for_face);
        }

        mesh.vertices = coords.ToArray();
        mesh.triangles = dummy_indices.ToArray();
        /*mesh.uv = text_coords.ToArray();
        mesh.normals = normalz.ToArray();*/
        mesh_filter.mesh = mesh;

        return newGO;
    }


}