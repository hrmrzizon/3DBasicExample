using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Parts order is head, torso, larm, rarm, lleg, rleg, 
/// </summary>
public static class VertexMapper
{
    public const int verticesCount = 4 * 6 * 6;
    public const int indicesCount = 6 * 6 * 6;
    public const float unitSize = 0.125f;

    public static Vector3[] bodyPosArray = new Vector3[] { new Vector3(0, 14f, 0), new Vector3(0, 9f, 0), new Vector3(-3f, 9f, 0), new Vector3(3f, 9f, 0), new Vector3(-1, 3f, 0), new Vector3(1f, 3f, 0), };
    public static Vector3[] bodySizeArray = new Vector3[] { new Vector3(2f, 2f, 2f), new Vector3(2f, 3f, 1f), new Vector3(1f, 3f, 1f), new Vector3(1f, 3f, 1f), new Vector3(1f, 3f, 1f), new Vector3(1f, 3f, 1f), };

    public static void GetVertices(ref Vector3[] vertices)
    {
        if (vertices == null)
            vertices = new Vector3[verticesCount];
        else if (vertices.Length < verticesCount)
            Array.Resize(ref vertices, verticesCount);

        for (int i = 0; i < 6; i++)
            GetCubeVertices(ref vertices, i * 24, bodyPosArray[i], bodySizeArray[i]);
    }

    public static void GetIndices(ref int[] indeces)
    {
        if (indeces == null)
            indeces = new int[indicesCount];
        else if (indeces.Length < verticesCount)
            Array.Resize(ref indeces, indicesCount);

        for (int i = 0; i < 6; i++)
        {
            GetCubeTriangles(ref indeces, i * 36, i * 24);
        }
    }

    private static void GetCubeVertices(ref Vector3[] vertices, int startIndex, Vector3 centerPosition, Vector3 cubeSize)
    {
        // Cube Top
        vertices[startIndex + 0] = new Vector3(centerPosition.x - cubeSize.x, centerPosition.y + cubeSize.y, centerPosition.z - cubeSize.z) * unitSize;
        vertices[startIndex + 1] = new Vector3(centerPosition.x - cubeSize.x, centerPosition.y + cubeSize.y, centerPosition.z + cubeSize.z) * unitSize;
        vertices[startIndex + 2] = new Vector3(centerPosition.x + cubeSize.x, centerPosition.y + cubeSize.y, centerPosition.z + cubeSize.z) * unitSize;
        vertices[startIndex + 3] = new Vector3(centerPosition.x + cubeSize.x, centerPosition.y + cubeSize.y, centerPosition.z - cubeSize.z) * unitSize;

        // Cube Bottom
        vertices[startIndex + 4] = new Vector3(centerPosition.x - cubeSize.x, centerPosition.y - cubeSize.y, centerPosition.z - cubeSize.z) * unitSize;
        vertices[startIndex + 5] = new Vector3(centerPosition.x + cubeSize.x, centerPosition.y - cubeSize.y, centerPosition.z - cubeSize.z) * unitSize;
        vertices[startIndex + 6] = new Vector3(centerPosition.x + cubeSize.x, centerPosition.y - cubeSize.y, centerPosition.z + cubeSize.z) * unitSize;
        vertices[startIndex + 7] = new Vector3(centerPosition.x - cubeSize.x, centerPosition.y - cubeSize.y, centerPosition.z + cubeSize.z) * unitSize;

        // Cube Front
        vertices[startIndex + 8] = new Vector3(centerPosition.x - cubeSize.x, centerPosition.y - cubeSize.y, centerPosition.z - cubeSize.z) * unitSize;
        vertices[startIndex + 9] = new Vector3(centerPosition.x - cubeSize.x, centerPosition.y + cubeSize.y, centerPosition.z - cubeSize.z) * unitSize;
        vertices[startIndex + 10] = new Vector3(centerPosition.x + cubeSize.x, centerPosition.y + cubeSize.y, centerPosition.z - cubeSize.z) * unitSize;
        vertices[startIndex + 11] = new Vector3(centerPosition.x + cubeSize.x, centerPosition.y - cubeSize.y, centerPosition.z - cubeSize.z) * unitSize;

        // Cube Back
        vertices[startIndex + 12] = new Vector3(centerPosition.x + cubeSize.x, centerPosition.y - cubeSize.y, centerPosition.z + cubeSize.z) * unitSize;
        vertices[startIndex + 13] = new Vector3(centerPosition.x + cubeSize.x, centerPosition.y + cubeSize.y, centerPosition.z + cubeSize.z) * unitSize;
        vertices[startIndex + 14] = new Vector3(centerPosition.x - cubeSize.x, centerPosition.y + cubeSize.y, centerPosition.z + cubeSize.z) * unitSize;
        vertices[startIndex + 15] = new Vector3(centerPosition.x - cubeSize.x, centerPosition.y - cubeSize.y, centerPosition.z + cubeSize.z) * unitSize;

        // Cube Right
        vertices[startIndex + 16] = new Vector3(centerPosition.x + cubeSize.x, centerPosition.y - cubeSize.y, centerPosition.z - cubeSize.z) * unitSize;
        vertices[startIndex + 17] = new Vector3(centerPosition.x + cubeSize.x, centerPosition.y + cubeSize.y, centerPosition.z - cubeSize.z) * unitSize;
        vertices[startIndex + 18] = new Vector3(centerPosition.x + cubeSize.x, centerPosition.y + cubeSize.y, centerPosition.z + cubeSize.z) * unitSize;
        vertices[startIndex + 19] = new Vector3(centerPosition.x + cubeSize.x, centerPosition.y - cubeSize.y, centerPosition.z + cubeSize.z) * unitSize;

        // Cube Left
        vertices[startIndex + 20] = new Vector3(centerPosition.x - cubeSize.x, centerPosition.y - cubeSize.y, centerPosition.z + cubeSize.z) * unitSize;
        vertices[startIndex + 21] = new Vector3(centerPosition.x - cubeSize.x, centerPosition.y + cubeSize.y, centerPosition.z + cubeSize.z) * unitSize;
        vertices[startIndex + 22] = new Vector3(centerPosition.x - cubeSize.x, centerPosition.y + cubeSize.y, centerPosition.z - cubeSize.z) * unitSize;
        vertices[startIndex + 23] = new Vector3(centerPosition.x - cubeSize.x, centerPosition.y - cubeSize.y, centerPosition.z - cubeSize.z) * unitSize;
    }

    private static void GetCubeTriangles(ref int[] indices, int arrayStartIndex, int vertexStartIndex)
    {
        // Cube Top, Bottom, Front, Back, Right, Left

        for (int offset = 0; offset < 6; offset++)
        {
            indices[arrayStartIndex + 0 + offset * 6] = vertexStartIndex + 0 + offset * 4;
            indices[arrayStartIndex + 1 + offset * 6] = vertexStartIndex + 1 + offset * 4;
            indices[arrayStartIndex + 2 + offset * 6] = vertexStartIndex + 2 + offset * 4;
            indices[arrayStartIndex + 3 + offset * 6] = vertexStartIndex + 0 + offset * 4;
            indices[arrayStartIndex + 4 + offset * 6] = vertexStartIndex + 2 + offset * 4;
            indices[arrayStartIndex + 5 + offset * 6] = vertexStartIndex + 3 + offset * 4;
        }
    }
}
