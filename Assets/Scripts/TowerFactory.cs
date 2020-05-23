using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerFactory : MonoBehaviour
{
    [SerializeField] int towerLimit = 5;
    [SerializeField] GameObject towerPrefab;
    int towerCount = 0;
    
    public void AddTower(Waypoint baseWaypoint) {
        
        if (towerCount < towerLimit)
        {
            InstantiateNewTower(baseWaypoint);
        }
        else
        {
            MoveExistingTower();
        }


    }

    private static void MoveExistingTower()
    {
        print("max towers");
    }

    private void InstantiateNewTower(Waypoint baseWaypoint)
    {
        Instantiate(towerPrefab, baseWaypoint.transform.position, Quaternion.identity);
        baseWaypoint.isPlacable = false;
        towerCount ++;
    }
}
