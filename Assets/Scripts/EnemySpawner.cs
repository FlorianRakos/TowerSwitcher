using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] float spawnTime = 2f;
    [SerializeField] EnemyMovement Enemy;
    
    void Start()
    {
        StartCoroutine(SpawnEnemys());
    }

    
    IEnumerator SpawnEnemys ()
    {
        while (true) // forever
        {
            Instantiate(Enemy, transform.position, Quaternion.identity);
            //print("done");
            yield return new WaitForSeconds(spawnTime);
        }
        
    }
}
