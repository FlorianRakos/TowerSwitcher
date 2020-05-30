using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] float spawnTime = 2f;
    [SerializeField] EnemyMovement Enemy;
    [SerializeField] Transform parent;
    [SerializeField] Text spawnedEnemys;
    [SerializeField] AudioClip spawnedEnemySFX;

    int score;

    
    void Start()
    {
        StartCoroutine(SpawnEnemys());
    }

    
    IEnumerator SpawnEnemys ()
    {
        while (true) // forever
        {
            EnemyMovement enemy = Instantiate(Enemy, transform.position, Quaternion.identity);
            enemy.transform.parent = parent;
            //print("done");
            AddScore();
            GetComponent<AudioSource>().PlayOneShot(spawnedEnemySFX);
            yield return new WaitForSeconds(spawnTime);
        }

    }

    private void AddScore()
    {
        score++;
        spawnedEnemys.text = score.ToString();
    }
}
