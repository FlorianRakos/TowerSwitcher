using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] float movementPeriod = .5f;
    [SerializeField] ParticleSystem goalParticle;
    [SerializeField] float speed = 1f;


    int next = 1;

    EnemyDamage enemyDamage;


    void Start()
    {
        Pathfinder pathfinder = FindObjectOfType<Pathfinder>();
        var path = pathfinder.GetPath();
        transform.position = path[0].transform.position;
        // StartCoroutine(FollowPath(path));
    }
    
    // IEnumerator FollowPath(List<Waypoint> path)
    // {
    //     //print("Starting Patrol");

    //     foreach (Waypoint wayPoint in path)
    //     {
            
    //         transform.position = wayPoint.transform.position;
           
    //         yield return new WaitForSeconds(movementPeriod);            
    //     }
    //    SelfDestruct();

    // }

    void Update() {
        Pathfinder pathfinder = FindObjectOfType<Pathfinder>();   
        var path = pathfinder.GetPath();
        FollowPath(path);
    }

    private void FollowPath (List<Waypoint> path) {
        
        Vector3 nextWaypoint = path[next].transform.position;
        Vector3 lastWaypoint = path[path.Count - 1].transform.position;

        
        var step = speed * Time.deltaTime;
        
        transform.position = Vector3.MoveTowards(transform.position, nextWaypoint, step);
        

        if (Vector3.Distance(transform.position, nextWaypoint) == 0f) {
            next ++;
        }

        if (Vector3.Distance(transform.position, lastWaypoint) == 0f) {
            SelfDestruct();
        }
        

        
    }

 private void SelfDestruct()
    {
        ParticleSystem vfx = Instantiate(goalParticle, transform.position, Quaternion.identity);
        vfx.Play();
        
        Destroy(vfx.gameObject, vfx.main.duration);

        Destroy(gameObject);
    }

    
}
