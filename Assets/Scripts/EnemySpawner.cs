using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemySpawner : MonoBehaviour
{
    WaveConfigSO currentWave;
    [SerializeField] List<WaveConfigSO> waveConfigs;
    [SerializeField] float timeBetweenWaves = 0f;
    [SerializeField] bool isLooping;
    private int waveSpawned;

    int countEnemySpawned = 0;

    void Start()
    {
        countEnemySpawned = 0;
        waveSpawned = 0;
        StartCoroutine(SpawnEnemyWaves());
    }

    void Update()
    {
        LevelManager.instance.FinishLevel(countEnemySpawned);
    }


    IEnumerator SpawnEnemyWaves()
    {
        do
        {
            foreach (WaveConfigSO wave in waveConfigs)
            {
                ++waveSpawned;
                Debug.Log("Wave " + waveSpawned);

                currentWave = wave;
                for (int i = 0; i < currentWave.GetEnemyCount(); i++)
                {
                    Instantiate(currentWave.GetEnemyPrefabs(i),
                    currentWave.GetStartingWaypoint().position, Quaternion.identity, transform);

                    countEnemySpawned++;
                    Debug.Log("Enemey Spawned: " + countEnemySpawned);

                    yield return new WaitForSeconds(currentWave.GetRandomSpawnTime());
                }
                yield return new WaitForSeconds(timeBetweenWaves);
            }
        } while (isLooping);
    }

    public WaveConfigSO GetCurrentWave()
    {
        return currentWave;
    }

    public int GetWaveCount()
    {
        return waveConfigs.Count;
    }

    public int GetWaveSpawned()
    {
        return waveSpawned;
    }
}
