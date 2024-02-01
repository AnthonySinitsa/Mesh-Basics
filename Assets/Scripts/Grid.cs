using UnityEngine;
using System.Collections;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class Grid : MonoBehaviour{
    public int xSize, ySize;

    private Vector3[] vertices;

    private Mesh mesh;

    private void Awake(){
        StartCoroutine(Generate());
    }

    private IEnumerator Generate(){
        WaitForSeconds wait = new WaitForSeconds(0.05f);

        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;
        mesh.name = "Procedural Grid";

        vertices = new Vector3[(xSize + 1) * (ySize + 1)];
        for(int i = 0, y = 0; y <= ySize; y++){
            for(int x = 0; x <= xSize; x++, i++){
                vertices[i] = new Vector3(x, y);
                yield return wait;
            }
        }

        mesh.vertices = vertices;

        int[] triangles = new int[xSize * ySize * 6];
        for(int ti = 0, vi = 0, y = 0; y < ySize; y++, vi++){
            for(int x = 0; x < xSize; x++, ti += 6, vi++){
                triangles[ti] = vi;
		        triangles[ti + 3] = triangles[ti + 2] = vi + 1;
		        triangles[ti + 4] = triangles[ti + 1] = vi + xSize + 1;
		        triangles[ti + 5] = vi + xSize + 2;
                mesh.triangles = triangles;
                yield return wait;
            }
        }
    }

    // visualize vertices
    private void OnDrawGizmos(){
        // check to make sure we got vertices, if this not here, error is thrown while in edit mode
        if (vertices == null) {
			return;
		}

        Gizmos.color = Color.black;
        for(int i = 0; i < vertices.Length; i++){
            Gizmos.DrawSphere(vertices[i], 0.1f);
        }
    }
}