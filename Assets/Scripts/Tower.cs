using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    //Parameters of each tower
    [SerializeField] Transform objectToPan;
    [SerializeField] float attackRange = 100f;
    [SerializeField] ParticleSystem bullets;

    public Waypoint baseWaypoint; 
    
    // state of each tower
     Transform targetEnemy;

    
    void Update()
    {
        SetTargetEnemy();

        if (targetEnemy != null)
        {
            ProcessFiring();
        } else
        {
            fireAtEnemy(false);
        }
        

    }

    private void SetTargetEnemy()
    {
        var enemies = FindObjectsOfType<EnemyDamage>();
        if (enemies.Length == 0) {print("return"); return;}

        else {
          Transform closestEnemy = enemies[0].transform;

          foreach (EnemyDamage enemy in enemies) {
            var distanceCurrent = Vector3.Distance(enemy.transform.position, gameObject.transform.position);
            var distanceClosest = Vector3.Distance(closestEnemy.transform.position, gameObject.transform.position);
            if (distanceCurrent < distanceClosest) {
                closestEnemy = enemy.transform;
                
                //print("enemy changed to" + closestEnemy);
            }          
          }
          targetEnemy = closestEnemy;

        }
        
        
    }

    private void ProcessFiring()
    {
            var distance = Vector3.Distance(targetEnemy.position, gameObject.transform.position);

            if (distance <= attackRange)
            {
                fireAtEnemy(true);
            }
            else
            {
                fireAtEnemy(false);
            }

    }

    private void fireAtEnemy(bool isActive)
    {
        if(isActive) { objectToPan.LookAt(targetEnemy.Find("Body").transform.position);} //string dependent
        var emissionModule = bullets.emission;
        emissionModule.enabled = isActive;
        
    }

    
}
