using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CowSpawner : MonoBehaviour
{
    public GameObject[] Prefabs;
    public float SpawnRate = 1.0f; 

    void Start()
    {
        int cowCount = Random.Range(20, 31); 

        for (int i = 0; i < cowCount; i++)
        {
            SpawnCow();
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SpawnCow();
        }
    }

    void SpawnCow()
    {
        if (Prefabs.Length == 0) return; 

        int randomIndex = Random.Range(0, Prefabs.Length);
        Vector3 randomSpawnPosition = new Vector3(
            Random.Range(-15f, 8.7f), 
            Random.Range(-14f, 7.8f), 
            -1f
        );

        Instantiate(Prefabs[randomIndex], randomSpawnPosition, Quaternion.identity);
    }
}
