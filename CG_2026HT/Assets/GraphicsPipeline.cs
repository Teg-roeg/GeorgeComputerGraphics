using UnityEngine;
using System.Collections.Generic;
using System;

public class GrapchicsPipeline : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Model myModel = new Model();
        myModel.CreateUnityGameObject();

        List<Vector4> verts = Homog(myModel.vertices);

        //   Display(verts);

        // First Transforamation

        // Rotation by 41 degrees about (21, -3, -3).normilized

        Vector3 axis = new Vector3(21, -3, -3).normalized;

        Matrix4x4 rotationMatrix = Matrix4x4.TRS(Vector3.zero, Quaternion.AngleAxis(41, axis), Vector3.one);

        //  Display(rotationMatrix);


        List<Vector4> imageAfterRotation = MatrixTransform(rotationMatrix, verts);

        // Display(imageAfterRotation);


        // Second Transformation
        

        Matrix4x4 scaleMatrix = Matrix4x4.TRS(Vector3.zero, Quaternion.identity, new Vector3(3, 3, 3));
        
        //   Display(scaleMatrix);


        List<Vector4> imageAfterScale = MatrixTransform(scaleMatrix, imageAfterRotation);

        //  Display(imageAfterScale);


        Matrix4x4 translationMatrix = Matrix4x4.TRS(new Vector3(-4, 4, -2), Quaternion.identity, Vector3.one);

        // Display(translationMatrix);

        List<Vector4> imageAfterTranslation = MatrixTransform(translationMatrix, imageAfterScale);

        //  Display(imageAfterTranslation);


        Matrix4x4 singleMatrixOfTransformation = translationMatrix * scaleMatrix * rotationMatrix;

        // Display(singleMatrixOfTransformation);

        Vector3 camPosition = new Vector3(23, 0, 47);
        Vector3 camLookAt = new Vector3(-3, 3, 3);
        Vector3 camUp = new Vector3(-2, -3, 21);

        Matrix4x4 viewingMatrix = Matrix4x4.LookAt(camPosition, camLookAt, Vector3.up);

        // Display(viewingMatrix);

        List<Vector4> imageAfterViewingMatrix = MatrixTransform(viewingMatrix, imageAfterTranslation);

        // Display(imageAfterViewingMatrix);

        List<Vector4> imageAfterSingleMatrix = MatrixTransform(singleMatrixOfTransformation, verts);

        Display(imageAfterSingleMatrix);

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
        foreach (Vector4 v in verts)
        {
            Debug.Log(v);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
