using UnityEngine;

public class MeshDeformerInput : MonoBehaviour{

    public float force = 10f;

    void Update(){
        if(Input.GetMouseButton(0)){
            HandleInput();
        }
    }

    void HandleInput(){
        Ray inputRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if(physics.Raycast(inputRay, out hit)){
            MeshDeformer deformer = hit.collider.GetComponent<MeshDeformer>();
        }
    }
}