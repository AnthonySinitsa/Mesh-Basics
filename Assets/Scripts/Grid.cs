using UnityEngine;
using System.Collections;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class Grid : MonoBehaviour{
    public int xSize, ySize;

    private Vector3[] vertices;

    private void Awake(){
        StartCoroutine(Generate());
    }


    private IEnumerator Generate(){
        WaitForSeconds wait = new WaitForSeconds(0.05f);
        vertices = new Vector3[(xSize + 1) * (ySize + 1)];
        for(int i = 0, y = 0; y <= ySize; y++){
            for(int x = 0; x <= xSize; x++, i++){
                vertices[i] = new Vector3(x, y);
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