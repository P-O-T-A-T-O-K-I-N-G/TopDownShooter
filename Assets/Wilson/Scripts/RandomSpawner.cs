using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawner : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject[] enemyPrefabs;
    public float delayTime;

    // Start is called before the first frame update
    void Start()
    {
        GameObject enemy = enemyPrefabs[Random.Range(0,enemyPrefabs.Length)];
        StartCoroutine(spawnEnemy(delayTime, enemy));
        //StartCoroutine(spawnEnemy())
    }

    private IEnumerator spawnEnemy(float interval, GameObject enemy)
    {
        yield return new WaitForSeconds(interval);
        GameObject newEnemy = Instantiate(enemy, new Vector3(Random.Range(-5f, 5), Random.Range(-6f, 6f), 0), Quaternion.identity);
        enemy = enemyPrefabs[Random.Range(0, enemyPrefabs.Length)];
        StartCoroutine(spawnEnemy(interval, enemy));
    }
}
