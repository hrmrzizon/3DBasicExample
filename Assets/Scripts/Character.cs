using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SkinnedMeshRenderer))]
public class Character : MonoBehaviour
{
    [SerializeField]
    private Material material;

    SkinnedMeshRenderer skinnedMeshRenderer;

    void Awake()
    {
        skinnedMeshRenderer = GetComponent<SkinnedMeshRenderer>();

        if (skinnedMeshRenderer == null)
            skinnedMeshRenderer = gameObject.AddComponent<SkinnedMeshRenderer>();

        Mesh mesh = new Mesh();

        Vector3[] vertices = null;
        int[] indices = null;

        VertexMapper.GetVertices(ref vertices);
        VertexMapper.GetIndices(ref indices);

        mesh.vertices = vertices;
        mesh.triangles = indices;

        Vector2[] uvs = null;
        UVMapper.GetUV(ref uvs);
        mesh.uv = uvs;

        Transform[] boneArray = Rigger.GetBoneTransform(gameObject);

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
    }
}
