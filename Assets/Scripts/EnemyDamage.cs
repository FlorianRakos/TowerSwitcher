using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] int hitPoints = 5;
    [SerializeField] ParticleSystem hitParticlePrefab;
    [SerializeField] ParticleSystem deathParticlePrefab;
    [SerializeField] AudioClip enemyDamagedSFX;
    [SerializeField] AudioClip enemyKilledSFX;

    AudioSource myAudiosource;

    void Start () {
        myAudiosource = GetComponent<AudioSource>();
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
         myAudiosource.PlayOneShot(enemyDamagedSFX);
        }

    }

    private void KillEnemy()
    {
        ParticleSystem vfx = Instantiate(deathParticlePrefab, transform.position, Quaternion.identity);
        vfx.Play();
        Destroy(vfx.gameObject, vfx.main.duration);

        AudioSource .PlayClipAtPoint(enemyKilledSFX, Camera.main.transform.position);

        Destroy(gameObject);
    }
}
