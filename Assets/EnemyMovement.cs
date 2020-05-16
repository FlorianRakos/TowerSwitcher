using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] List<Waypoint> path;

    void Start()
    {
        //StartCoroutine(FollowPath());
    }

    IEnumerator FollowPath()
    {
        print("Starting Patrol");

        foreach (Waypoint wayPoint in path)
        {
            print("Visiting" + wayPoint);
            transform.position = wayPoint.transform.position;
            yield return new WaitForSeconds(1f);
        }
        print("Ending Patrol");

    }

    
}
