using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject enemy;
    [SerializeField] private Vector3[] spawnPoints;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    IEnumerator SpawnEnemies()
    {
        for (int i = 0; i < 10; i++)
        {
            yield return new WaitForSeconds(2f);
            Instantiate(enemy, spawnPoints[UnityEngine.Random.Range(0, spawnPoints.Length)], Quaternion.identity);
        }
    }

}
