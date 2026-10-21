using System.Collections.Generic;
using UnityEngine;

public class Model
{
    internal List<Vector3Int> faces = new List<Vector3Int>();
    internal List<Vector3> vertices = new List<Vector3>();
    List<Vector2> texture_coordinates = new List<Vector2>();
    List<Vector3Int> texture_index_list = new List<Vector3Int>();
    List<Vector3> normals = new List<Vector3>();

    public Model()
    {
        addVertices();
        addTextureCoords();
        addFaces();
        addTextureIndex();
        addNormals();
    }

    private List<Vector2> normaliseTextureVerts(float r)
    {
        List<Vector2> hold = new List<Vector2>();
        foreach (Vector2 v in texture_coordinates)
        {
            hold.Add(new Vector2(v.x / r, 1f - v.y / r));
        }
        return hold;
    }

    private void addNormals()
    {
        // ---------- Front faces (0..10) — near side of the slab, +z ----------
        normals.Add(new Vector3(0, 0, 1)); // 0
        normals.Add(new Vector3(0, 0, 1)); // 1
        normals.Add(new Vector3(0, 0, 1)); // 2
        normals.Add(new Vector3(0, 0, 1)); // 3
        normals.Add(new Vector3(0, 0, 1)); // 4
        normals.Add(new Vector3(0, 0, 1)); // 5
        normals.Add(new Vector3(0, 0, 1)); // 6
        normals.Add(new Vector3(0, 0, 1)); // 7
        normals.Add(new Vector3(0, 0, 1)); // 8
        normals.Add(new Vector3(0, 0, 1)); // 9
        normals.Add(new Vector3(0, 0, 1)); // 10

        // ---------- Back faces (11..21) — far side of the slab, -z ----------
        normals.Add(new Vector3(0, 0, -1)); // 11
        normals.Add(new Vector3(0, 0, -1)); // 12
        normals.Add(new Vector3(0, 0, -1)); // 13
        normals.Add(new Vector3(0, 0, -1)); // 14
        normals.Add(new Vector3(0, 0, -1)); // 15
        normals.Add(new Vector3(0, 0, -1)); // 16
        normals.Add(new Vector3(0, 0, -1)); // 17
        normals.Add(new Vector3(0, 0, -1)); // 18
        normals.Add(new Vector3(0, 0, -1)); // 19
        normals.Add(new Vector3(0, 0, -1)); // 20
        normals.Add(new Vector3(0, 0, -1)); // 21

        // ---------- Bottom faces (22..27) — horizontal caps, -y ----------
        normals.Add(new Vector3(0, -1, 0)); // 22
        normals.Add(new Vector3(0, -1, 0)); // 23
        normals.Add(new Vector3(0, -1, 0)); // 24
        normals.Add(new Vector3(0, -1, 0)); // 25
        normals.Add(new Vector3(0, -1, 0)); // 26
        normals.Add(new Vector3(0, -1, 0)); // 27

        // ---------- Top faces (28..33) — horizontal caps, +y ----------
        normals.Add(new Vector3(0, 1, 0));  // 28
        normals.Add(new Vector3(0, 1, 0));  // 29
        normals.Add(new Vector3(0, 1, 0));  // 30
        normals.Add(new Vector3(0, 1, 0));  // 31
        normals.Add(new Vector3(0, 1, 0));  // 32
        normals.Add(new Vector3(0, 1, 0));  // 33

        // ---------- Left side faces (34..37) — vertical walls, -x ----------
        normals.Add(new Vector3(-1, 0, 0)); // 34
        normals.Add(new Vector3(-1, 0, 0)); // 35
        normals.Add(new Vector3(-1, 0, 0)); // 36
        normals.Add(new Vector3(-1, 0, 0)); // 37

        // ---------- Right side faces (38..41) — vertical walls, +x ----------
        normals.Add(new Vector3(1, 0, 0));  // 38
        normals.Add(new Vector3(1, 0, 0));  // 39
        normals.Add(new Vector3(1, 0, 0));  // 40
        normals.Add(new Vector3(1, 0, 0));  // 41

        // ---------- Left slance faces (42..47) — 45° chamfers on the left ----------
        normals.Add(new Vector3(-1, 1, 0).normalized); // 42
        normals.Add(new Vector3(-1, 1, 0).normalized); // 43
        normals.Add(new Vector3(-1, 1, 0).normalized); // 44
        normals.Add(new Vector3(-1, 1, 0).normalized); // 45
        normals.Add(new Vector3(-1, 1, 0).normalized); // 46
        normals.Add(new Vector3(-1, 1, 0).normalized); // 47

        // ---------- Right slance faces (48..53) — 45° chamfers on the right ----------
        normals.Add(new Vector3(1, 1, 0).normalized);  // 48
        normals.Add(new Vector3(1, 1, 0).normalized);  // 49
        normals.Add(new Vector3(1, 1, 0).normalized);  // 50
        normals.Add(new Vector3(1, 1, 0).normalized);  // 51
        normals.Add(new Vector3(1, 1, 0).normalized);  // 52
        normals.Add(new Vector3(1, 1, 0).normalized);  // 53
    }

    private void addTextureIndex()
    {
        // ---------- Front faces ----------
        texture_index_list.Add(new Vector3Int(1, 6, 5));    // 0
        texture_index_list.Add(new Vector3Int(0, 1, 5));    // 1
        texture_index_list.Add(new Vector3Int(0, 21, 4));   // 2
        texture_index_list.Add(new Vector3Int(4, 21, 20));  // 3
        texture_index_list.Add(new Vector3Int(20, 22, 28)); // 4
        texture_index_list.Add(new Vector3Int(22, 29, 28)); // 5
        texture_index_list.Add(new Vector3Int(15, 23, 29)); // 6
        texture_index_list.Add(new Vector3Int(16, 23, 15)); // 7
        texture_index_list.Add(new Vector3Int(11, 16, 15)); // 8
        texture_index_list.Add(new Vector3Int(11, 15, 10)); // 9
        texture_index_list.Add(new Vector3Int(10, 15, 14)); // 10

        // ---------- Back faces ----------
        texture_index_list.Add(new Vector3Int(2, 8, 7));    // 11
        texture_index_list.Add(new Vector3Int(3, 8, 2));    // 12
        texture_index_list.Add(new Vector3Int(3, 9, 26));   // 13
        texture_index_list.Add(new Vector3Int(9, 27, 26));  // 14
        texture_index_list.Add(new Vector3Int(27, 31, 25)); // 15
        texture_index_list.Add(new Vector3Int(25, 31, 30)); // 16
        texture_index_list.Add(new Vector3Int(18, 30, 24)); // 17
        texture_index_list.Add(new Vector3Int(17, 18, 24)); // 18
        texture_index_list.Add(new Vector3Int(12, 18, 17)); // 19
        texture_index_list.Add(new Vector3Int(13, 18, 12)); // 20
        texture_index_list.Add(new Vector3Int(13, 19, 18)); // 21

        // ---------- Bottom faces ----------
        texture_index_list.Add(new Vector3Int(33, 35, 34)); // 22
        texture_index_list.Add(new Vector3Int(32, 33, 34)); // 23
        texture_index_list.Add(new Vector3Int(45, 47, 46)); // 24
        texture_index_list.Add(new Vector3Int(44, 45, 46)); // 25
        texture_index_list.Add(new Vector3Int(37, 39, 38)); // 26
        texture_index_list.Add(new Vector3Int(36, 37, 38)); // 27

        // ---------- Top faces ----------
        texture_index_list.Add(new Vector3Int(35, 33, 34)); // 28
        texture_index_list.Add(new Vector3Int(34, 33, 32)); // 29
        texture_index_list.Add(new Vector3Int(43, 41, 42)); // 30
        texture_index_list.Add(new Vector3Int(42, 41, 40)); // 31
        texture_index_list.Add(new Vector3Int(35, 33, 34)); // 32
        texture_index_list.Add(new Vector3Int(34, 33, 32)); // 33

        // ---------- Left side faces ----------
        texture_index_list.Add(new Vector3Int(56, 58, 57)); // 34
        texture_index_list.Add(new Vector3Int(57, 58, 59)); // 35
        texture_index_list.Add(new Vector3Int(52, 54, 53)); // 36
        texture_index_list.Add(new Vector3Int(53, 54, 55)); // 37

        // ---------- Right side faces ----------
        texture_index_list.Add(new Vector3Int(57, 59, 56)); // 38
        texture_index_list.Add(new Vector3Int(56, 59, 58)); // 39
        texture_index_list.Add(new Vector3Int(53, 55, 52)); // 40
        texture_index_list.Add(new Vector3Int(52, 55, 54)); // 41

        // ---------- Left slance faces ----------
        texture_index_list.Add(new Vector3Int(50, 51, 48)); // 42
        texture_index_list.Add(new Vector3Int(48, 51, 49)); // 43
        texture_index_list.Add(new Vector3Int(50, 51, 48)); // 44
        texture_index_list.Add(new Vector3Int(48, 51, 49)); // 45
        texture_index_list.Add(new Vector3Int(51, 50, 49)); // 46
        texture_index_list.Add(new Vector3Int(49, 50, 48)); // 47

        // ---------- Right slance faces ----------
        texture_index_list.Add(new Vector3Int(49, 48, 51)); // 48
        texture_index_list.Add(new Vector3Int(51, 48, 50)); // 49
        texture_index_list.Add(new Vector3Int(49, 48, 51)); // 50
        texture_index_list.Add(new Vector3Int(51, 48, 50)); // 51
        texture_index_list.Add(new Vector3Int(48, 49, 50)); // 52
        texture_index_list.Add(new Vector3Int(50, 49, 51)); // 53
    }

    private void addTextureCoords()
    {
        texture_coordinates.Add(new Vector2(62, 28));   // 0
        texture_coordinates.Add(new Vector2(184, 28));  // 1
        texture_coordinates.Add(new Vector2(307, 28));  // 2
        texture_coordinates.Add(new Vector2(427, 28));  // 3
        texture_coordinates.Add(new Vector2(32, 54));   // 4
        texture_coordinates.Add(new Vector2(62, 54));   // 5
        texture_coordinates.Add(new Vector2(214, 54));  // 6
        texture_coordinates.Add(new Vector2(276, 54));  // 7
        texture_coordinates.Add(new Vector2(428, 54));  // 8
        texture_coordinates.Add(new Vector2(458, 54));  // 9
        texture_coordinates.Add(new Vector2(124, 81));  // 10
        texture_coordinates.Add(new Vector2(184, 81));  // 11
        texture_coordinates.Add(new Vector2(307, 81));  // 12
        texture_coordinates.Add(new Vector2(369, 81));  // 13
        texture_coordinates.Add(new Vector2(92, 107));  // 14
        texture_coordinates.Add(new Vector2(184, 107)); // 15
        texture_coordinates.Add(new Vector2(214, 107)); // 16
        texture_coordinates.Add(new Vector2(276, 107)); // 17
        texture_coordinates.Add(new Vector2(307, 107)); // 18
        texture_coordinates.Add(new Vector2(401, 107)); // 19
        texture_coordinates.Add(new Vector2(32, 160));  // 20
        texture_coordinates.Add(new Vector2(62, 160));  // 21
        texture_coordinates.Add(new Vector2(184, 160)); // 22
        texture_coordinates.Add(new Vector2(214, 160)); // 23
        texture_coordinates.Add(new Vector2(276, 160)); // 24
        texture_coordinates.Add(new Vector2(307, 160)); // 25
        texture_coordinates.Add(new Vector2(428, 160)); // 26
        texture_coordinates.Add(new Vector2(458, 160)); // 27
        texture_coordinates.Add(new Vector2(62, 184));  // 28
        texture_coordinates.Add(new Vector2(184, 184)); // 29
        texture_coordinates.Add(new Vector2(307, 184)); // 30
        texture_coordinates.Add(new Vector2(428, 184)); // 31

        texture_coordinates.Add(new Vector2(66, 281));  // 32 
        texture_coordinates.Add(new Vector2(185, 281)); // 33 
        texture_coordinates.Add(new Vector2(66, 306));  // 34 
        texture_coordinates.Add(new Vector2(185, 306)); // 35 
        texture_coordinates.Add(new Vector2(66, 340));  // 36 
        texture_coordinates.Add(new Vector2(214, 340)); // 37 
        texture_coordinates.Add(new Vector2(66, 364));  // 38 
        texture_coordinates.Add(new Vector2(214, 364)); // 39 
        texture_coordinates.Add(new Vector2(125, 393)); // 40 
        texture_coordinates.Add(new Vector2(185, 393)); // 41 
        texture_coordinates.Add(new Vector2(125, 418)); // 42 
        texture_coordinates.Add(new Vector2(185, 418)); // 43 
        texture_coordinates.Add(new Vector2(95, 444));  // 44 
        texture_coordinates.Add(new Vector2(182, 444)); // 45 
        texture_coordinates.Add(new Vector2(95, 468));  // 46 
        texture_coordinates.Add(new Vector2(182, 468)); // 47 
        texture_coordinates.Add(new Vector2(248, 279)); // 48 
        texture_coordinates.Add(new Vector2(277, 279)); // 49 
        texture_coordinates.Add(new Vector2(248, 307)); // 50 
        texture_coordinates.Add(new Vector2(277, 307)); // 51 
        texture_coordinates.Add(new Vector2(310, 282)); // 52 
        texture_coordinates.Add(new Vector2(336, 282)); // 53 
        texture_coordinates.Add(new Vector2(310, 335)); // 54 
        texture_coordinates.Add(new Vector2(336, 335)); // 55 
        texture_coordinates.Add(new Vector2(369, 284)); // 56 
        texture_coordinates.Add(new Vector2(398, 284)); // 57 
        texture_coordinates.Add(new Vector2(369, 389)); // 58 
        texture_coordinates.Add(new Vector2(398, 389)); // 59 

        texture_coordinates = normaliseTextureVerts(512f);
    }

    private void addFaces()
    {
        // Front faces
        faces.Add(new Vector3Int(1, 4, 3));   // 0
        faces.Add(new Vector3Int(0, 1, 3));   // 1
        faces.Add(new Vector3Int(0, 11, 2));  // 2
        faces.Add(new Vector3Int(2, 11, 10)); // 3
        faces.Add(new Vector3Int(10, 12, 14));// 4
        faces.Add(new Vector3Int(12, 15, 14));// 5
        faces.Add(new Vector3Int(8, 13, 15)); // 6
        faces.Add(new Vector3Int(9, 13, 8));  // 7
        faces.Add(new Vector3Int(6, 9, 8));   // 8
        faces.Add(new Vector3Int(6, 8, 5));   // 9
        faces.Add(new Vector3Int(5, 8, 7));   // 10

        // Back faces
        faces.Add(new Vector3Int(17, 19, 20));// 11
        faces.Add(new Vector3Int(16, 19, 17));// 12
        faces.Add(new Vector3Int(16, 18, 27));// 13
        faces.Add(new Vector3Int(18, 26, 27));// 14
        faces.Add(new Vector3Int(26, 30, 28));// 15
        faces.Add(new Vector3Int(28, 30, 31));// 16
        faces.Add(new Vector3Int(24, 31, 29));// 17
        faces.Add(new Vector3Int(25, 24, 29));// 18
        faces.Add(new Vector3Int(22, 24, 25));// 19
        faces.Add(new Vector3Int(21, 24, 22));// 20
        faces.Add(new Vector3Int(21, 23, 24));// 21

        // Bottom faces
        faces.Add(new Vector3Int(15, 31, 30));// 22
        faces.Add(new Vector3Int(14, 15, 30));// 23
        faces.Add(new Vector3Int(8, 24, 23)); // 24
        faces.Add(new Vector3Int(7, 8, 23));  // 25
        faces.Add(new Vector3Int(4, 20, 19)); // 26
        faces.Add(new Vector3Int(3, 4, 19));  // 27

        // Top faces
        faces.Add(new Vector3Int(17, 1, 16)); // 28
        faces.Add(new Vector3Int(16, 1, 0));  // 29
        faces.Add(new Vector3Int(22, 6, 21)); // 30
        faces.Add(new Vector3Int(21, 6, 5));  // 31
        faces.Add(new Vector3Int(28, 12, 27));// 32
        faces.Add(new Vector3Int(27, 12, 11));// 33

        // Left side faces
        faces.Add(new Vector3Int(2, 10, 18)); // 34
        faces.Add(new Vector3Int(18, 10, 26));// 35
        faces.Add(new Vector3Int(8, 12, 24)); // 36
        faces.Add(new Vector3Int(24, 12, 28));// 37

        // Right side faces
        faces.Add(new Vector3Int(19, 27, 3)); // 38
        faces.Add(new Vector3Int(3, 27, 11)); // 39
        faces.Add(new Vector3Int(25, 29, 9)); // 40
        faces.Add(new Vector3Int(9, 29, 13)); // 41

        // Left Slances faces
        faces.Add(new Vector3Int(17, 20, 1)); // 42
        faces.Add(new Vector3Int(1, 20, 4));  // 43
        faces.Add(new Vector3Int(22, 25, 6)); // 44
        faces.Add(new Vector3Int(6, 25, 9));  // 45
        faces.Add(new Vector3Int(29, 31, 13));// 46
        faces.Add(new Vector3Int(13, 31, 15));// 47

        // Right Slances faces
        faces.Add(new Vector3Int(0, 2, 16));  // 48
        faces.Add(new Vector3Int(16, 2, 18)); // 49
        faces.Add(new Vector3Int(5, 7, 21));  // 50
        faces.Add(new Vector3Int(21, 7, 23)); // 51
        faces.Add(new Vector3Int(10, 14, 26));// 52
        faces.Add(new Vector3Int(26, 14, 30));// 53
    }

    private void addVertices()
    {
        vertices.Add(new Vector3(-2, 3,1)); // 0
        vertices.Add(new Vector3(2, 3, 1));  // 1
        vertices.Add(new Vector3(-3, 2, 1)); // 2
        vertices.Add(new Vector3(-2, 2, 1)); // 3
        vertices.Add(new Vector3(3, 2, 1));  // 4
        vertices.Add(new Vector3(0, 1, 1));  // 5
        vertices.Add(new Vector3(2, 1, 1));  // 6
        vertices.Add(new Vector3(-1, 0, 1)); // 7
        vertices.Add(new Vector3(2, 0, 1));  // 8
        vertices.Add(new Vector3(3, 0, 1));  // 9
        vertices.Add(new Vector3(-3, -2, 1));// 10
        vertices.Add(new Vector3(-2, -2, 1));// 11
        vertices.Add(new Vector3(2, -2, 1)); // 12
        vertices.Add(new Vector3(3, -2, 1)); // 13
        vertices.Add(new Vector3(-2, -3, 1));// 14
        vertices.Add(new Vector3(2, -3, 1)); // 15

        vertices.Add(new Vector3(-2, 3, -1));  // 16
        vertices.Add(new Vector3(2, 3, -1));   // 17
        vertices.Add(new Vector3(-3, 2, -1));  // 18
        vertices.Add(new Vector3(-2, 2, -1));  // 19
        vertices.Add(new Vector3(3, 2, -1));   // 20
        vertices.Add(new Vector3(0, 1, -1));   // 21
        vertices.Add(new Vector3(2, 1, -1));   // 22
        vertices.Add(new Vector3(-1, 0, -1));  // 23
        vertices.Add(new Vector3(2, 0, -1));   // 24
        vertices.Add(new Vector3(3, 0, -1));   // 25
        vertices.Add(new Vector3(-3, -2, -1)); // 26
        vertices.Add(new Vector3(-2, -2, -1)); // 27
        vertices.Add(new Vector3(2, -2, -1));  // 28
        vertices.Add(new Vector3(3, -2, -1));  // 29
        vertices.Add(new Vector3(-2, -3, -1)); // 30
        vertices.Add(new Vector3(2, -3, -1));  // 31
    }

    public GameObject CreateUnityGameObject()
    {
        Mesh mesh = new Mesh();
        GameObject newGO = new GameObject();

        MeshFilter mesh_filter = newGO.AddComponent<MeshFilter>();
        MeshRenderer mesh_renderer = newGO.AddComponent<MeshRenderer>();

        List<Vector3> coords = new List<Vector3>();
        List<int> dummy_indices = new List<int>();
        List<Vector2> text_coords = new List<Vector2>();
        List<Vector3> normalz = new List<Vector3>();

        for (int i = 0; i < faces.Count; i++)
        {
            Vector3 normal_for_face = normals[i];

            normal_for_face = new Vector3(normal_for_face.x, normal_for_face.y, -normal_for_face.z);

            coords.Add(vertices[faces[i].x]); dummy_indices.Add(i * 3); text_coords.Add(texture_coordinates[texture_index_list[i].x]); normalz.Add(normal_for_face);

            coords.Add(vertices[faces[i].y]); dummy_indices.Add(i * 3 + 2); text_coords.Add(texture_coordinates[texture_index_list[i].y]); normalz.Add(normal_for_face);

            coords.Add(vertices[faces[i].z]); dummy_indices.Add(i * 3 + 1); text_coords.Add(texture_coordinates[texture_index_list[i].z]); normalz.Add(normal_for_face);
        }

        mesh.vertices = coords.ToArray();
        mesh.triangles = dummy_indices.ToArray();
        mesh.uv = text_coords.ToArray();
        mesh.normals = normalz.ToArray();
        mesh_filter.mesh = mesh;

        return newGO;
    }
}
