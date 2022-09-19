using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    [SerializeField] List<WavePath> wavePaths;
    [SerializeField] float timeBetweenWaves = 0f;
    [SerializeField] WavePath currentWave;
    [SerializeField] bool isLooping;

    void Start()
    {
        StartCoroutine(SpawnEnemyWaves());
    }

    public WavePath GetCurrentWave()
    {
        return currentWave;
    }

    IEnumerator SpawnEnemyWaves()
    {
        do
        {
            foreach (WavePath wave in wavePaths)
            {
                currentWave = wave;
                for (int i = 0; i < currentWave.GetEnemyCount(); i++)
                {
                    Instantiate(currentWave.GetEnemyPrefab(i),
                             currentWave.GetStartingWayPoint().position,
                             Quaternion.Euler(0, 0, 180), transform);
                    yield return new WaitForSeconds(currentWave.GetRandomSpawnTime());
                }
                yield return new WaitForSeconds(timeBetweenWaves);
            }
        }
        while (isLooping);


    }
}
