using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private Vector3[] spawnPoints;


    // Start is called before the first frame update
    void Start()
    {
        Instantiate(player, spawnPoints[UnityEngine.Random.Range(0, spawnPoints.Length)], Quaternion.identity);
    }

}
