using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshTest : MonoBehaviour
{
    public void ModifyMesh(Mesh mesh)
    {
        /*

            (0,0,1) 2   3 (1,0,1)
                    * - *
                    | / |
                    * - *
            (0,0,0) 0   1 (1,0,0)

        */
        mesh.vertices =
                    new Vector3[]
                    {
                        new Vector3(0f, 0f, 0f),
                        new Vector3(1f, 0f, 0f),
                        new Vector3(0f, 0f, 1f),
                        new Vector3(1f, 0f, 1f)
                    };


        mesh.triangles = new int[]
                            {
                                0, 2, 3,
                                0, 3, 1,
                            };
    }
}
