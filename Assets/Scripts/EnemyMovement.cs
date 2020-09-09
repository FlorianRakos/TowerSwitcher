using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] float movementPeriod = .5f;
    [SerializeField] float speed = 1f;
    [SerializeField] float spinnSpeed = 1;
    [SerializeField] float bounceHeight = 10;
    [SerializeField] float bounceSpeed = .05f;

    [SerializeField] ParticleSystem goalParticle;

    float spinn;
    float initHeight;
    float risingNumber;
    float yVal;

    int next = 1;

    EnemyDamage enemyDamage;

    void Start()
    {
        Pathfinder pathfinder = FindObjectOfType<Pathfinder>();
        var path = pathfinder.GetPath();
        transform.position = path[0].transform.position;
        initHeight = transform.position.y;
    }

    void Update()
    {
        Pathfinder pathfinder = FindObjectOfType<Pathfinder>();
        var path = pathfinder.GetPath();
        FollowPath(path);
        SpinIt();
    }

    private void BounceIt()
    {
        risingNumber += bounceSpeed;
        float sinVal = Mathf.Sin(risingNumber);
        float sinValCorected = sinVal * bounceHeight;
        yVal = initHeight + sinValCorected;
        transform.position = new Vector3(transform.position.x, initHeight + sinValCorected, transform.position.z);
    }

    private void SpinIt()
    {
        spinn = spinn + spinnSpeed;
        transform.localRotation = Quaternion.Euler(0f, spinn, 0f);
    }

    private void FollowPath(List<Waypoint> path)
    {
        Vector3 nextWaypoint = path[next].transform.position;
        Vector3 lastWaypoint = path[path.Count - 1].transform.position;

        var step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, nextWaypoint, step);
        var yCorrectedTrans = new Vector3(transform.position.x, 0f, transform.position.z);

        if (Vector3.Distance(yCorrectedTrans, nextWaypoint) <= 0.2f)
        {
            next++;
            print("nexting");
        }

        if (Vector3.Distance(yCorrectedTrans, lastWaypoint) <= 0.2f)
        {
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
