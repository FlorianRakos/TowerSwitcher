using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] int hitPoints = 5;
    [SerializeField] ParticleSystem hitParticlePrefab;
    [SerializeField] ParticleSystem deathParticlePrefab;


    void Start()
    {
        
    }

    private void OnParticleCollision(GameObject other)
    {
        //print("Im hit");
        ProcessHit();
    }

    void ProcessHit ()
    {
        hitPoints = hitPoints - 1;
        //print("Current HP" + hitPoints);
        
        if (hitPoints <= 0)
        {
            KillEnemy();
        } else {
         hitParticlePrefab.Play();   
        }

    }

    private void KillEnemy()
    {
        ParticleSystem vfx = Instantiate(deathParticlePrefab, transform.position, Quaternion.identity);
        vfx.Play();
        Destroy(vfx.gameObject, vfx.main.duration);
        Destroy(gameObject);
    }
}
