using UnityEngine;
using System.Collections;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class Grid : MonoBehaviour{
    public int xSize, ySize;

    private void Awake(){
        Generate();
    }

    private Vector3[] vertices;

    private void Generate(){
        vertices = new Vector3[(xSize + 1) * (ySize + 1)];
    }

    // visualize veritces
    private void OnDrawGizmos(){
        Gizmos.color = Color.black;
        for(int i = 0; i < vertices.Length; i++){
            Gizmos.DrawSphere(vertices[i], 0.1f);
        }
    }
}