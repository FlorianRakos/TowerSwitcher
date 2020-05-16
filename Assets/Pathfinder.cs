using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{
    Dictionary<Vector2Int, Waypoint> grid = new Dictionary<Vector2Int, Waypoint>();

    Queue<Waypoint> queue = new Queue<Waypoint>();

    [SerializeField] Waypoint start, end;

    [SerializeField] bool isRunning = true;

    Vector2Int[] directions =
    {
        Vector2Int.up,
        Vector2Int.right,
        Vector2Int.down,
        Vector2Int.left
    };


    void Start()
    {
        LoadBlocks();
        ColorStartAndEnd();
        Pathfind();
        //ExploreNeighbours();
    }

    private void Pathfind()
    {
        
        queue.Enqueue(start);

        while(queue.Count > 0 && isRunning)
        {
            Waypoint searchCenter = queue.Dequeue();
            
            print("Searching from " + searchCenter); // remove
            
            HaltIfEndFound(searchCenter);
        ExploreNeighbours(searchCenter);
        searchCenter.isExplored = true;
        }
        print("Finished pathfinding");
        
        
    }

    private void HaltIfEndFound(Waypoint searchCenter)
    {
        if (searchCenter == end)
        {
            print("End found");
            isRunning = false;
        }
    }

    private void ExploreNeighbours(Waypoint from)
    {
        if (!isRunning) { return; }

        foreach(Vector2Int direction in directions)
        {
            
            Vector2Int neighbourCoordinates = from.GetGridPos() + direction;
            try
            {
                QueueNewNeighbours(neighbourCoordinates);
            }
            catch
            {
                
            }
        }
    }

    private void QueueNewNeighbours(Vector2Int neighbourCoordinates)
    {

        Waypoint neighbour = grid[neighbourCoordinates];
        if (neighbour.isExplored)
        {
            print("already explored " + neighbour);
        } else
        {
            neighbour.SetTopColor(Color.blue); // todo move later
            queue.Enqueue(neighbour);
            print("queueing " + neighbour);
        }
        
    }

    private void ColorStartAndEnd()
    {
        start.SetTopColor(Color.green);
        end.SetTopColor(Color.red);
    }

    private void LoadBlocks()
    {
        var waypoints = FindObjectsOfType<Waypoint>();
        foreach (Waypoint waypoint in waypoints)
        {
            var gridPos = waypoint.GetGridPos();

            if (grid.ContainsKey(gridPos))
            {
                Debug.LogWarning("Skipping verlapping block" + waypoint);
            }
            else
            {
                grid.Add(gridPos, waypoint);
            }
            
        }

        
    }

}
