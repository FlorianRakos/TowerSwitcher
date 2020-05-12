using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[SelectionBase]



public class CubeEditor : MonoBehaviour
{
    [SerializeField] [Range(1f, 20f)] float gridSize = 10f;
    TextMesh textMesh;

    

    void Update()
    {
        Vector3 snapPos;
        snapPos.x = Mathf.RoundToInt(transform.position.x / gridSize) * gridSize;
        snapPos.z = Mathf.RoundToInt(transform.position.z / gridSize) * gridSize;
        snapPos.y = Mathf.RoundToInt(transform.position.y / gridSize) * gridSize;

        transform.position = new Vector3 (snapPos.x, snapPos.y, snapPos.z) ;

        textMesh = GetComponentInChildren<TextMesh>();
        textMesh.text = snapPos.x/10 + "," + snapPos.z/10;

    }
}
