using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SkinnedMeshRenderer))]
public class Character : MonoBehaviour
{
    [SerializeField]
    private Shader shader;

    [SerializeField]
    private CharacterData data;

    [SerializeField]
    private RuntimeAnimatorController animatorController;

    SkinnedMeshRenderer skinnedMeshRenderer;
    Animator animator;

    void Awake()
    {
        skinnedMeshRenderer = GetComponent<SkinnedMeshRenderer>();

        if (skinnedMeshRenderer == null)
            skinnedMeshRenderer = gameObject.AddComponent<SkinnedMeshRenderer>();

        animator = GetComponent<Animator>();

        if (animator == null)
            animator = gameObject.AddComponent<Animator>();

        Material material = new Material(shader);
        material.SetTexture("_MainTex", data.bodyTex);

        Mesh mesh = new Mesh();

        Vector3[] vertices = null;
        int[] indices = null;

        VertexMapper.GetVertices(ref vertices, data.GetBodyPoses(), data.GetBodySizes());
        VertexMapper.GetIndices(ref indices);

        mesh.vertices = vertices;
        mesh.triangles = indices;

        Vector2[] uvs = null;
        UVMapper.GetUV(ref uvs, data.GetUVPoses(), data.GetUVSizes());
        mesh.uv = uvs;

        Transform[] boneArray = 
            Array.ConvertAll(
                data.GetBonePoses(),
                (poses) =>
                {
                    Transform bone = new GameObject(string.Format("Bone{0}", transform.childCount)).transform;

                    bone.parent = transform;
                    bone.localPosition = poses;

                    return bone;
                }
                );

        Matrix4x4[] bindPoses = null;
        BoneWeight[] weight = null;

        SkinMapper.GetBoneWieghts(ref weight);
        Rigger.GetBindPoses(ref bindPoses, transform, boneArray);

        mesh.boneWeights = weight;
        mesh.bindposes = bindPoses;

        skinnedMeshRenderer.sharedMesh = mesh;
        skinnedMeshRenderer.material = material;
        skinnedMeshRenderer.bones = boneArray;
        skinnedMeshRenderer.rootBone = transform;

        animator.runtimeAnimatorController = animatorController;
    }
}
