using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] int hitPoints = 5;

    void Start()
    {
        
    }

    private void OnParticleCollision(GameObject other)
    {
        print("Im hit");
        ProcessHit();
    }

    void ProcessHit ()
    {
        hitPoints = hitPoints - 1;
        print("Current HP" + hitPoints);
        if (hitPoints <= 0)
        {
            KillEnemy();
        }

    }

    private void KillEnemy()
    {
        Destroy(gameObject);
    }
}
