using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject enemy;
    [SerializeField] private Vector3[] spawnPoints;
    private bool gameOver;

    // Start is called before the first frame update
    void Start()
    {
        UIManager.Instance.gameStarted += GenerateEnemies;
        UIManager.Instance.gameOver += GameFinished;
    }
    void GenerateEnemies()
    {
        StartCoroutine(SpawnEnemies());
    }

    private void GameFinished()
    {
        Destroy(gameObject);
    }

    IEnumerator SpawnEnemies()
    {
        for (int i = 0; i < 10; i++)
        {
            yield return new WaitForSeconds(2f);
            Instantiate(enemy, spawnPoints[UnityEngine.Random.Range(0, spawnPoints.Length)], Quaternion.identity);

            if (gameOver)
                yield break;
        }
    }



}
