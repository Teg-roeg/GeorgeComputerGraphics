using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Model
{

    internal List<Vector3Int> faces = new List<Vector3Int>();
    internal List<Vector3Int> texture_index_list = new List<Vector3Int>();
    internal List<Vector3> vertices = new List<Vector3>();
    internal List<Vector2> texture_coordinates = new List<Vector2>();
    internal List<Vector3> normals = new List<Vector3>();


    public Model()
    {
        addVertices();
        addFaces();
        addTextureCoords();
        addTexttureIndex();
        addNormals();

        texture_coordinates = normaliseTextureVerts(1024f);

    }

    private List<Vector2> normaliseTextureVerts(float r)
    {
        List<Vector2> hold = new List<Vector2>();
        foreach (Vector2 v in texture_coordinates)
        {
            hold.Add(new Vector2(v.x / r, 1 - v.y / r));
        }

        return hold;
    }

    private void addNormals()
    {
        normals.Add(new Vector3(0, 0, -1)); //0
        normals.Add(new Vector3(0, 0, -1)); //1
        normals.Add(new Vector3(0, 0, -1)); //2
        normals.Add(new Vector3(0, 0, -1)); //3
        normals.Add(new Vector3(0, 0, -1)); //4
        normals.Add(new Vector3(0, 0, -1)); //5
        normals.Add(new Vector3(0, 0, -1)); //6
        normals.Add(new Vector3(0, 0, -1)); //7
        normals.Add(new Vector3(0, 0, 1)); //8
        normals.Add(new Vector3(0, 0, 1)); //9
        normals.Add(new Vector3(0, 0, 1)); //10
        normals.Add(new Vector3(0, 0, 1)); //11
        normals.Add(new Vector3(0, 0, 1)); //12
        normals.Add(new Vector3(0, 0, 1)); //13
        normals.Add(new Vector3(0, 0, 1)); //14
        normals.Add(new Vector3(0, 0, 1)); //15

    }

    private void addTexttureIndex()
    {
        texture_index_list.Add(new Vector3Int(4, 0, 12)); //0
        texture_index_list.Add(new Vector3Int(12, 0, 20)); //1
        texture_index_list.Add(new Vector3Int(16, 12, 20)); //2
        texture_index_list.Add(new Vector3Int(8, 12, 9)); //3
        texture_index_list.Add(new Vector3Int(13, 9, 12)); //4
        texture_index_list.Add(new Vector3Int(5, 13, 1)); //5
        texture_index_list.Add(new Vector3Int(13, 21, 1)); //6
        texture_index_list.Add(new Vector3Int(17, 21, 13)); //7
        texture_index_list.Add(new Vector3Int(6, 2, 14)); //8
        texture_index_list.Add(new Vector3Int(14, 2, 22)); //9
        texture_index_list.Add(new Vector3Int(18, 14, 22)); //10
        texture_index_list.Add(new Vector3Int(10, 14, 11)); //11
        texture_index_list.Add(new Vector3Int(15, 11, 14)); //12
        texture_index_list.Add(new Vector3Int(7, 15, 3)); //13
        texture_index_list.Add(new Vector3Int(15, 3, 23)); //14
        texture_index_list.Add(new Vector3Int(19, 15, 23)); //15
        texture_index_list.Add(new Vector3Int(3, 23, 0)); //16
        texture_index_list.Add(new Vector3Int(20, 0, 23)); //17
        texture_index_list.Add(new Vector3Int(1, 21, 2)); //18
        texture_index_list.Add(new Vector3Int(22, 2, 21)); //19
        texture_index_list.Add(new Vector3Int(11, 8, 10)); //20
        texture_index_list.Add(new Vector3Int(9, 10, 8)); //21
        texture_index_list.Add(new Vector3Int(12, 15, 13)); //22
        texture_index_list.Add(new Vector3Int(14, 13, 15)); //23
        texture_index_list.Add(new Vector3Int(0, 4, 3)); //24
        texture_index_list.Add(new Vector3Int(7, 4, 3)); //25
        texture_index_list.Add(new Vector3Int(2, 6, 1)); //26
        texture_index_list.Add(new Vector3Int(5, 6, 1)); //27
        texture_index_list.Add(new Vector3Int(16, 20, 19)); //28
        texture_index_list.Add(new Vector3Int(23, 20, 19)); //29
        texture_index_list.Add(new Vector3Int(18, 22, 17)); //30
        texture_index_list.Add(new Vector3Int(21, 22, 17)); //31
        texture_index_list.Add(new Vector3Int(6, 10, 5)); //32
        texture_index_list.Add(new Vector3Int(9, 10, 5)); //33
        texture_index_list.Add(new Vector3Int(4, 8, 7)); //34
        texture_index_list.Add(new Vector3Int(11, 8, 7)); //35
        texture_index_list.Add(new Vector3Int(14, 18, 13)); //36
        texture_index_list.Add(new Vector3Int(17, 18, 13)); //37
        texture_index_list.Add(new Vector3Int(12, 16, 15)); //38
        texture_index_list.Add(new Vector3Int(19, 16, 15)); //39

    }
            /*
            62, 28 // 0
            184, 28 // 1
            307, 28 // 2
            427, 28 // 3

            32, 54 // 4
            62, 54 // 5
            214, 54 // 6
            276, 54 // 7
            428, 54 // 8
            458, 54 // 9

            124, 81 // 10
            184, 81 // 11
            307, 81 // 12
            369, 81 // 13

            92, 107 // 14
            184, 107 // 15
            214, 107 // 16
            276, 107 // 17
            307, 107 // 18
            401, 107 // 19

            32, 160 // 20
            62, 160 // 21
            184, 160 // 22
            214, 160 // 23
            276, 160 // 24
            307, 160 // 25
            428, 160 // 26
            458, 160 // 27

            62, 184 // 28
            184, 184 // 29
            307, 184 // 30
            428, 184 // 31

            Top / Bottom

            62, 278 // 32
            184, 278 // 33
            62, 305 // 34
            184, 305 // 35
            62, 337 // 36
            214, 337 // 37
            62, 364 // 38
            214, 364 // 39


            Slance

            247, 278
            278, 278




            */
    private void addTextureCoords()
    {
        texture_coordinates.Add(new Vector2(62, 28)); //0
        texture_coordinates.Add(new Vector2(184, 28)); //1
        texture_coordinates.Add(new Vector2(307, 28)); //2
        texture_coordinates.Add(new Vector2(427, 28)); //3
        texture_coordinates.Add(new Vector2(32, 54)); //4
        texture_coordinates.Add(new Vector2(62, 54)); //5
        texture_coordinates.Add(new Vector2(214, 54)); //6
        texture_coordinates.Add(new Vector2(276, 54)); //7
        texture_coordinates.Add(new Vector2(428, 54)); //8
        texture_coordinates.Add(new Vector2(458, 54)); //9
        texture_coordinates.Add(new Vector2(124, 81)); //10
        texture_coordinates.Add(new Vector2(184, 81)); //11
        texture_coordinates.Add(new Vector2(307, 81)); //12
        texture_coordinates.Add(new Vector2(369, 81)); //13
        texture_coordinates.Add(new Vector2(92, 107)); //14
        texture_coordinates.Add(new Vector2(184, 107)); //15
        texture_coordinates.Add(new Vector2(214, 107)); //16
        texture_coordinates.Add(new Vector2(276, 107)); //17
        texture_coordinates.Add(new Vector2(307, 107)); //18
        texture_coordinates.Add(new Vector2(401, 107)); //19
        texture_coordinates.Add(new Vector2(32, 160)); //20
        texture_coordinates.Add(new Vector2(62, 160)); //21
        texture_coordinates.Add(new Vector2(184, 160)); //22
        texture_coordinates.Add(new Vector2(214, 160)); //23
        texture_coordinates.Add(new Vector3(276, 160)); //24
        texture_coordinates.Add(new Vector3(307, 160)); //25
        texture_coordinates.Add(new Vector3(428, 160)); //26
        texture_coordinates.Add(new Vector3(458, 160)); //27
        texture_coordinates.Add(new Vector3(62, 184)); //28
        texture_coordinates.Add(new Vector3(184, 184)); //29
        texture_coordinates.Add(new Vector3(307, 184)); //30
        texture_coordinates.Add(new Vector3(428, 184)); //31
        texture_coordinates.Add(new Vector3(62, 278)); //32
        texture_coordinates.Add(new Vector3(184, 278)); //33
        texture_coordinates.Add(new Vector3(62, 305)); //34
        texture_coordinates.Add(new Vector3(184, 305)); //35
        texture_coordinates.Add(new Vector3(62, 337)); //36
        texture_coordinates.Add(new Vector3(214, 337)); //37
        texture_coordinates.Add(new Vector3(62, 364)); //38
        texture_coordinates.Add(new Vector3(214, 364)); //39

    }

    private void addFaces()
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

    private void addVertices()
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