using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{

    [SerializeField] Transform objectToPan;
    [SerializeField] Transform targetEnemy;
    [SerializeField] float attackRange = 100f;
    [SerializeField] ParticleSystem bullets;
    
    

    
    void Update()
    {
        if (targetEnemy)
        {
            ProcessFiring();
        } else
        {
            fireAtEnemy(false);
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
        objectToPan.LookAt(targetEnemy);
        var emissionModule = bullets.emission;
        emissionModule.enabled = isActive;
        
    }
}
