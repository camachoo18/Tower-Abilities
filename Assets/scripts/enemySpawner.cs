using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawner : MonoBehaviour
{
    [SerializeField] GameObject prefab;
    [SerializeField] List<Transform> spawnPoints;
    Transform player;
    bool playerIsDead = false;
    [SerializeField] Transform playerTransform;
    float speed;

    void Start()
    {
        StartCoroutine(SpawnerEnemies());
        GameEvents.PlayerDied.AddListener(OnPlayerDeath);
    }

    void OnPlayerDeath()
    {
        playerIsDead = true;
        Vector3 directionToPlayer = playerTransform.position - transform.position;
        directionToPlayer = directionToPlayer.normalized;
        transform.position -= directionToPlayer * speed * Time.deltaTime;
    }

    IEnumerator SpawnerEnemies()
    {
        while (!playerIsDead) 
        {
            Vector3 spawnPos = spawnPoints[Random.Range(0, spawnPoints.Count)].position;
            GameObject.Instantiate(prefab, spawnPos, Quaternion.identity);
            yield return new WaitForSeconds(1f);
        }
    }
}
