
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{
    Dictionary<Vector2Int, Waypoint> grid = new Dictionary<Vector2Int, Waypoint>();

    Queue<Waypoint> queue = new Queue<Waypoint>();

    [SerializeField] Waypoint start, end;

    bool isRunning = true;
    bool pathCalculated = false;
    Waypoint searchCenter;

    List<Waypoint> path = new List<Waypoint>();

    Vector2Int[] directions =
    {
        Vector2Int.up,
        Vector2Int.right,
        Vector2Int.down,
        Vector2Int.left
    };
    
    public List<Waypoint> GetPath()
    {
        if (path.Count == 0)
        {
            CalculatePath();  
        }
        return path;
    }

    private void CalculatePath()
    {
        LoadBlocks();
        BreadthFirstSearch();
        CreatePath();
        
        pathCalculated = false;
    }

    private void CreatePath()
    {
        path.Add(end);
        Waypoint previous = end.exploredFrom;

        while (previous != start)
        {
            path.Add(previous);
            previous = previous.exploredFrom;
        }

        path.Add(start);
        path.Reverse();

        


        

    }

    private void BreadthFirstSearch()
    {
        
        queue.Enqueue(start);

        while(queue.Count > 0 && isRunning)
        {
             searchCenter = queue.Dequeue();
            
            
            
            HaltIfEndFound();
        ExploreNeighbours();
        searchCenter.isExplored = true;
        }
        print("Finished pathfinding");
        
        
    }

    private void HaltIfEndFound()
    {
        if (searchCenter == end)
        {
            print("End found");
            isRunning = false;
        }
    }

    private void ExploreNeighbours()
    {
        if (!isRunning) { return; }

        foreach(Vector2Int direction in directions)
        {
            
            Vector2Int neighbourCoordinates = searchCenter.GetGridPos() + direction;
            if (grid.ContainsKey(neighbourCoordinates))
            {
                QueueNewNeighbours(neighbourCoordinates);
            }

        }
    }

    private void QueueNewNeighbours(Vector2Int neighbourCoordinates)
    {

        Waypoint neighbour = grid[neighbourCoordinates];
        if (neighbour.isExplored || queue.Contains(neighbour))
        {
            //print("already explored " + neighbour);
        } else
        {
            
            neighbour.exploredFrom = searchCenter;
            queue.Enqueue(neighbour);
            //print("queueing " + neighbour);
        }
        
    }

    

    private void LoadBlocks()
    {
        var waypoints = FindObjectsOfType<Waypoint>();
        foreach (Waypoint waypoint in waypoints)
        {
            var gridPos = waypoint.GetGridPos();

            if (grid.ContainsKey(gridPos))
            {
                Debug.LogWarning("Skipping overlapping block" + waypoint);
            }
            else
            {
                grid.Add(gridPos, waypoint);
            }
            
        }

        
    }

}
