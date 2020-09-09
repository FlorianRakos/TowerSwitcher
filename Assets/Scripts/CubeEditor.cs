using UnityEngine;

[ExecuteInEditMode]
[SelectionBase]
[RequireComponent(typeof(Waypoint))]


public class CubeEditor : MonoBehaviour
{
    Waypoint waypoint;

    private void Awake()
    {
        waypoint = GetComponent<Waypoint>();       
    }

    void Update()
    {
        SnapToGrid();
        UpdateLabel();
    }

    private void SnapToGrid()
    {
        int gridSize = waypoint.GetGridSize();
        Vector2 gridPos = waypoint.GetGridPos() * gridSize;       
        transform.position = new Vector3(gridPos.x, 0f, gridPos.y);
    }

    private void UpdateLabel()
    {       
        Vector2 gridPos = waypoint.GetGridPos();
        TextMesh textMesh = GetComponentInChildren<TextMesh>();
        textMesh.text = gridPos.x + "," + gridPos.y ;
        gameObject.name = gridPos.x + "," + gridPos.y ;
    }
}
