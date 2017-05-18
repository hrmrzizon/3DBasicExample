using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Rigger
{
    public static float defaultUnitSize = 0.125f;
    public static Vector3[] defaultBodyPosArray =
        new Vector3[] { new Vector3(0, 12f, 0), new Vector3(0, 12f, 0), new Vector3(-3f, 12f - 1f, 0), new Vector3(3f, 12f - 1f, 0), new Vector3(-1, 6f, 0), new Vector3(1f, 6f, 0), };

    public static Transform[] GetBoneTransform(GameObject rootObject, Vector3[] bodyPosArray = null)
    {
        bodyPosArray = defaultBodyPosArray;
        Transform[] bodyArray = new Transform[bodyPosArray.Length];

        for (int i = 0; i < bodyPosArray.Length; i++)
        {
            GameObject bone = new GameObject(string.Format("Bone{0}", i));

            bone.transform.parent = rootObject.transform;
            bone.transform.localPosition = bodyPosArray[i] * defaultUnitSize;

            bodyArray[i] = bone.transform;
        }

        return bodyArray;
    }

    public static void GetBindPoses(ref Matrix4x4[] bindPoses, Transform root, Transform[] bones)
    {
        if (bindPoses == null)
            bindPoses = new Matrix4x4[bones.Length];
        else if (bindPoses.Length < bones.Length)
            Array.Resize(ref bindPoses, bones.Length);

        for (int i = 0; i < bones.Length; i++)
            bindPoses[i] = bones[i].worldToLocalMatrix * root.localToWorldMatrix;
    }

}