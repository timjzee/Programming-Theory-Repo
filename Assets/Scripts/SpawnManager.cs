using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private MainManager MainManager;
    [SerializeField] List<GameObject> enemyPrefabs;
    public int enemyCount;
    public int waveNumber = 1;
    private float spawnRange = 9;
    // Start is called before the first frame update
    void Start()
    {
        MainManager = GameObject.Find("Main Manager").GetComponent<MainManager>();
        SpawnEnemyWave(waveNumber);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        enemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;

        if (enemyCount == 0)
        {
            waveNumber++;
            SpawnEnemyWave(waveNumber);
        }
    }

    void SpawnEnemyWave(int enemiesToSpawn)
    {
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            int prefabIndex = Random.Range(0, enemyPrefabs.Count);
            GameObject enemyPrefab = enemyPrefabs[prefabIndex];
            Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);
        }
    }

    private Vector3 GenerateSpawnPosition()
    {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);
        Vector3 randomPos = new Vector3(spawnPosX, 2, spawnPosZ);
        return randomPos;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (MainManager.gameOver)
        {
            Destroy(other.gameObject);
            return;
        }
        if (other.CompareTag("Player"))
        {
            MainManager.GameOver();
        }
        else
        {
            GameManager.Instance.currentScore += 1;
        }
        Destroy(other.gameObject);
    }
}
