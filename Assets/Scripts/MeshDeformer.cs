using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
public class MeshDeformer : MonoBehaviour {

    Mesh deformingMesh;
    Vector3[] originalVertices, displacedVertices;

    Vector3[] vertexVelocities;

    void Start () {
		deformingMesh = GetComponent<MeshFilter>().mesh;
		originalVertices = deformingMesh.vertices;
		displacedVertices = new Vector3[originalVertices.Length];
		for (int i = 0; i < originalVertices.Length; i++) {
			displacedVertices[i] = originalVertices[i];
		}
        vertexVelocities = new Vector3[originalVertices.Length];
	}

    public void AddDeformingForce(Vector3 point, float force){
        for(int i = 0; i < displacedVertices.Length; i++){
            AddForceToVertex(i, point, force);
        }
    }

    void AddForceToVertex(int i, Vector3 point, float force){
        Vector3 pointToVertex = displacedVertices[i] - point;
        float attenuateForce = foarce / (1f + pointToVertex.sqrMagnitude);
        vertexVelocities[i] += pointToVertex.normalized * velocity;
    }

    void Update(){
        for(int i = 0; i < displacedVertices.Length; i++){
            UpdateVertex(i);
        }
        deformingMesh.vertices = displacedVertices;
        deformingMesh.RecalculateNormals();
    }
    
    void UpdateVertex(int i){
        Vector3 velocity = vertexVelocities[i];
        displacedVertices[i] += velocity * Time.deltaTime;
    }
}