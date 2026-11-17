using UnityEngine;
using System.Collections.Generic;
using System;


public class GrapchicsPipeline : MonoBehaviour
{
    Texture2D screen;
    public GameObject screenGo;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        screen = new Texture2D(1024, 1024);

        Model myModel = new Model();
        myModel.CreateUnityGameObject();

        List<Vector4> verts = Homog(myModel.vertices);

        //   Display(verts);

        // First Transforamation
        // ------- Rotation --------
        // Rotation by 41 degrees about (21, -3, -3).normilized

        Vector3 axis = new Vector3(21, -3, -3).normalized;

        Matrix4x4 rotationMatrix = Matrix4x4.TRS(Vector3.zero, Quaternion.AngleAxis(41, axis), Vector3.one);

        //  Display(rotationMatrix);
        // ------- Image after Rotation --------

        List<Vector4> imageAfterRotation = MatrixTransform(rotationMatrix, verts);

        // Display(imageAfterRotation);


        // Second Transformation
        // ------- Scale --------

        Matrix4x4 scaleMatrix = Matrix4x4.TRS(Vector3.zero, Quaternion.identity, new Vector3(3, 3, 3));

        //   Display(scaleMatrix);
        // ------- Image after Scale --------

        List<Vector4> imageAfterScale = MatrixTransform(scaleMatrix, imageAfterRotation);

        //  Display(imageAfterScale);
        // ------- Translation --------

        Matrix4x4 translationMatrix = Matrix4x4.TRS(new Vector3(-4, 4, -2), Quaternion.identity, Vector3.one);

        // Display(translationMatrix);
        // ------- Image after Translation --------

        List<Vector4> imageAfterTranslation = MatrixTransform(translationMatrix, imageAfterScale);

        //  Display(imageAfterTranslation);
        // ------- Single Transformation --------

        Matrix4x4 singleMatrixOfTransformation = translationMatrix * scaleMatrix * rotationMatrix;

        // Display(singleMatrixOfTransformation);
        // ------- View Matrix --------

        Vector3 camPosition = new Vector3(23, 0, 47);
        Vector3 camLookAt = new Vector3(-3, 3, 3);
        Vector3 camUp = new Vector3(-2, -3, 21);

        Matrix4x4 viewingMatrix = Matrix4x4.LookAt(camPosition, camLookAt, Vector3.up);

        // Display(viewingMatrix);
        // ------- Image after Viewing--------

        List<Vector4> imageAfterViewingMatrix = MatrixTransform(viewingMatrix, imageAfterTranslation);

        // Display(imageAfterViewingMatrix);
        // ------- Image after Single Transformation --------

        List<Vector4> imageAfterSingleMatrix = MatrixTransform(singleMatrixOfTransformation, verts);

        // Display(imageAfterSingleMatrix);



        // ------- Perspective --------

        Matrix4x4 perspectiveMatrix = Matrix4x4.Perspective(100, 1, 1, 1000);
        
        //Display(perspectiveMatrix);
        // ------- Image after Perspective --------

        List<Vector4> imageAfterPerspective = MatrixTransform(perspectiveMatrix, imageAfterViewingMatrix);

        // Display(imageAfterPerspective);
        // ------- Final --------

        Matrix4x4 finalMatrix = perspectiveMatrix * viewingMatrix * singleMatrixOfTransformation;

        // Display(finalMatrix);
        // ------- Image after Final --------

        List<Vector4> imageAfterFinal = MatrixTransform(finalMatrix, verts);

        // Display(imageAfterFinal);



        Vector2 clippedStart = new Vector2(-0.5f, 0.5f); // Example clipped float point
        Vector2 clippedEnd = new Vector2(0.5f, -0.5f);   // Example clipped float point

        // --- PUT THE CONVERSION CODE HERE ---
        int screenWidth = 800;
        int screenHeight = 600;

        Vector2Int pixelStart = new Vector2Int(
            Mathf.RoundToInt((clippedStart.x + 1f) * 0.5f * screenWidth),
            Mathf.RoundToInt((clippedStart.y + 1f) * 0.5f * screenHeight)
        );

        Vector2Int pixelEnd = new Vector2Int(
            Mathf.RoundToInt((clippedEnd.x + 1f) * 0.5f * screenWidth),
            Mathf.RoundToInt((clippedEnd.y + 1f) * 0.5f * screenHeight)
        );

        // Now pass the Vector2Ints straight into your bresh algorithm
        List<Vector2Int> linePixels = bresh(pixelStart, pixelEnd);

        // Loop through the pixels to draw them or print them
        foreach (Vector2Int p in linePixels)
        {
            Debug.Log("Pixel to draw at: " + p);
        }

        Draw(bresh((new Vector2Int(0, 0)), new Vector2Int(512,512)));
        screenGo.GetComponent<Renderer>().material.mainTexture = screen;
        screen.Apply();

    }

    private void Draw(List<Vector2Int> vector2Ints)
    {
        foreach (Vector2Int v in vector2Ints)
        {
            screen.SetPixel(v.x, v.y, Color.blue);
        }
    }

    private List<Vector2Int> bresh(Vector2Int s, Vector2Int e)
    {
        int dx = e.x - s.x;
        int dy = e.y - s.y;

        if (dx < 0)
        { 
            return bresh(e, s);
        }

        if (dy < 0)
        {
            return NegateY(bresh(NegateY(s), NegateY(e)));
        }

        int D = dy - dx;
        int N = 2 * D; // Negative adjustment 
        int P = 2 * dy; // Positive adjustment
        int p0 = 2 * dy - dx;

        int x = s.x;
        int y = s.y;

        List<Vector2Int> pixels = new List<Vector2Int>();

        if (dy > dx)
        {
            return SwapXY(bresh(SwapXY(s), SwapXY(e)));
        }

        pixels.Add(new Vector2Int(x, y));

        while (x < e.x) // x<i + 1> = xi + 1 i.e. increase x by 1 everytime until you get to xi = ex
        {
            x++;
            if (p0 <= 0)
            {
                p0 += P;
            }
            else // if p0 <= 0 then leave y alone and add the positive adjustment(P) to p. Otherwise p > 0 we increase y and add the negative adjustment(N) to p.
            {
                y++;
                p0 += N;
            }
            pixels.Add(new Vector2Int(x, y));
        }

        return pixels;
    }

    private List<Vector4> Homog(List<Vector3> vertices)
    {
        List<Vector4> result = new List<Vector4>();

        foreach (Vector3 v in vertices)
        {
            result.Add(new Vector4(v.x, v.y, v.z, 1));
        }

        return result;

    }

    private List<Vector4> MatrixTransform(Matrix4x4 matrix, List<Vector4> verts)
    {
        List<Vector4> hold = new List<Vector4>();
        foreach (Vector4 v in verts)
        {

            hold.Add(matrix * v);
        }
        return hold;
    }

    private void Display(Matrix4x4 matrix)
    {
        for (int i = 0; i < 4; i++)
        {
            Debug.Log(matrix.GetRow(i));
        }
    }

    void Display(List<Vector4> verts)
    {
        foreach (Vector3 v in verts)
        {
            Debug.Log(v);
        }
    }

    private Vector2Int NegateY(Vector2Int point)
    {
        return new Vector2Int(point.x, -point.y);
    }

    private List<Vector2Int> NegateY(List<Vector2Int> points)
    {
        List<Vector2Int> result = new List<Vector2Int>(points.Count);
        foreach (Vector2Int pt in points)
        {
            result.Add(NegateY(pt));
        }

        return result;

    }

    private Vector2Int SwapXY(Vector2Int point)
    {
        return new Vector2Int(point.y, point.x);
    }

    private List<Vector2Int> SwapXY(List<Vector2Int> points)
    {
        List<Vector2Int> result = new List<Vector2Int>(points.Count);
        foreach (Vector2Int pt in points)
        {
            result.Add(SwapXY(pt));
        }
        return result;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
