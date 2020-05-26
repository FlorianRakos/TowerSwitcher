using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerFactory : MonoBehaviour
{
    [SerializeField] int towerLimit = 5;
    [SerializeField] Tower towerPrefab;
    [SerializeField] Transform parent;
    Queue<Tower> towerQueue = new Queue<Tower>();
    
    int towerCount;
    
    public void AddTower(Waypoint baseWaypoint) {
        towerCount = towerQueue.Count;

        if (towerCount < towerLimit)
        {
            InstantiateNewTower(baseWaypoint);
        }
        else
        {
            MoveExistingTower(baseWaypoint);
        }


    }

    private void InstantiateNewTower(Waypoint baseWaypoint)
    {
        var newTower = Instantiate(towerPrefab, baseWaypoint.transform.position, Quaternion.identity);
        newTower.transform.parent = parent;
        baseWaypoint.isPlacable = false;
        newTower.baseWaypoint = baseWaypoint;

        towerQueue.Enqueue(newTower);
        
        
    }

    private void MoveExistingTower(Waypoint newBaseWaypoint)
    {
        var oldTower = towerQueue.Dequeue();

        oldTower.baseWaypoint.isPlacable = true;
        newBaseWaypoint.isPlacable = false;

        oldTower.baseWaypoint = newBaseWaypoint;
        oldTower.transform.position = newBaseWaypoint.transform.position;

        towerQueue.Enqueue(oldTower);


        print("max towers");
    }


}