using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// UV order in plane is bottom, left, top, right
/// Plane order in cube is  top, bottom, front, behind, right, left
/// Parts order is head, torso, larm, rarm, lleg, rleg, 
///                helm, torso2, larm2, rarm2, lleg2, rleg2
/// </summary>
public static class UVMapper
{
    public const int uvCountPart = 24;
    public const int uvPosCount = 24 * 6;

    public const float unitUVSize = 0.0625f;
    public static Vector2[] uvStartArray =
        new Vector2[] {
                new Vector2(0f, 0.75f),     new Vector2(0.25f, 0.5f),   new Vector2(0.5f, 0f),  new Vector2(0.625f, 0.5f),  new Vector2(0.25f, 0f), new Vector2(0f, 0.5f),
                new Vector2(0.5f, 0.75f),   new Vector2(0.25f, 0.25f),  new Vector2(0.75f, 0f), new Vector2(0.625f, 0.25f), new Vector2(0f, 0f),    new Vector2(0f, 0.25f),
        };
    public static Vector3[] uvSizeArray =
        new Vector3[] {
                new Vector3(2f, 2f, 2f), new Vector3(2f, 3f, 1f), new Vector3(1f, 3f, 1f), new Vector3(1f, 3f, 1f), new Vector3(1f, 3f, 1f), new Vector3(1f, 3f, 1f),
                new Vector3(2f, 2f, 2f), new Vector3(2f, 3f, 1f), new Vector3(1f, 3f, 1f), new Vector3(1f, 3f, 1f), new Vector3(1f, 3f, 1f), new Vector3(1f, 3f, 1f),
        };

    private static void SetCubeUVs(Vector2[] uvArray, int startIndex, Vector2 partCoord, Vector3 partSize)
    {
        // Top
        uvArray[startIndex + 0] = new Vector2(partCoord.x + partSize.z * unitUVSize, partCoord.y + partSize.z * unitUVSize);
        uvArray[startIndex + 1] = new Vector2(partCoord.x + partSize.z * unitUVSize, partCoord.y + partSize.z * unitUVSize * 2);
        uvArray[startIndex + 2] = new Vector2(partCoord.x + partSize.z * unitUVSize + partSize.x * unitUVSize, partCoord.y + partSize.z * unitUVSize * 2);
        uvArray[startIndex + 3] = new Vector2(partCoord.x + partSize.z * unitUVSize + partSize.x * unitUVSize, partCoord.y + partSize.z * unitUVSize);

        // Bottom
        uvArray[startIndex + 4] = new Vector2(partCoord.x + partSize.x * unitUVSize + partSize.z * unitUVSize, partCoord.y + partSize.z * unitUVSize);
        uvArray[startIndex + 5] = new Vector2(partCoord.x + partSize.x * unitUVSize + partSize.z * unitUVSize, partCoord.y + partSize.z * unitUVSize);
        uvArray[startIndex + 6] = new Vector2(partCoord.x + partSize.x * unitUVSize + partSize.z * unitUVSize * 2, partCoord.y + partSize.z * unitUVSize * 2);
        uvArray[startIndex + 7] = new Vector2(partCoord.x + partSize.x * unitUVSize + partSize.z * unitUVSize * 2, partCoord.y + partSize.z * unitUVSize * 2);

        // Front
        uvArray[startIndex + 8] = new Vector2(partCoord.x + partSize.x * unitUVSize + partSize.z * unitUVSize * 2, partCoord.y);
        uvArray[startIndex + 9] = new Vector2(partCoord.x + partSize.x * unitUVSize + partSize.z * unitUVSize * 2, partCoord.y + partSize.y * unitUVSize);
        uvArray[startIndex + 10] = new Vector2(partCoord.x + partSize.x * unitUVSize * 2 + partSize.z * unitUVSize * 2, partCoord.y + partSize.y * unitUVSize);
        uvArray[startIndex + 11] = new Vector2(partCoord.x + partSize.x * unitUVSize * 2 + partSize.z * unitUVSize * 2, partCoord.y);

        // Back
        uvArray[startIndex + 12] = new Vector2(partCoord.x + partSize.z * unitUVSize, partCoord.y);
        uvArray[startIndex + 13] = new Vector2(partCoord.x + partSize.z * unitUVSize, partCoord.y + partSize.y * unitUVSize);
        uvArray[startIndex + 14] = new Vector2(partCoord.x + partSize.z * unitUVSize + partSize.x * unitUVSize, partCoord.y + partSize.y * unitUVSize);
        uvArray[startIndex + 15] = new Vector2(partCoord.x + partSize.z * unitUVSize + partSize.x * unitUVSize, partCoord.y);

        // Right
        uvArray[startIndex + 16] = new Vector2(partCoord.x, partCoord.y);
        uvArray[startIndex + 17] = new Vector2(partCoord.x, partCoord.y + partSize.y * unitUVSize);
        uvArray[startIndex + 18] = new Vector2(partCoord.x + partSize.z * unitUVSize, partCoord.y + partSize.y * unitUVSize);
        uvArray[startIndex + 19] = new Vector2(partCoord.x + partSize.z * unitUVSize, partCoord.y);

        // Left
        uvArray[startIndex + 20] = new Vector2(partCoord.x + partSize.z * unitUVSize + partSize.x * unitUVSize, partCoord.y);
        uvArray[startIndex + 21] = new Vector2(partCoord.x + partSize.z * unitUVSize + partSize.x * unitUVSize, partCoord.y + partSize.y * unitUVSize);
        uvArray[startIndex + 22] = new Vector2(partCoord.x + partSize.z * unitUVSize * 2 + partSize.x * unitUVSize, partCoord.y + partSize.y * unitUVSize);
        uvArray[startIndex + 23] = new Vector2(partCoord.x + partSize.z * unitUVSize * 2 + partSize.x * unitUVSize, partCoord.y);
    }

    public static Vector2[] GetUV()
    {
        Vector2[] uvArray = null;

        GetUV(ref uvArray);

        return uvArray;
    }

    public static void GetUV(ref Vector2[] uvArray)
    {
        if (uvArray == null)
            uvArray = new Vector2[uvPosCount];
        else if (uvArray.Length < uvPosCount)
            Array.Resize(ref uvArray, uvPosCount);

        for (int i = 0; i < 6; i++)
            SetCubeUVs(uvArray, UVMapper.uvCountPart * i, uvStartArray[i], uvSizeArray[i]);
    }
}