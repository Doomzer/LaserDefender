using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] List<WaveConfig> waves;
    [SerializeField] int startingWave = 0;
    [SerializeField] bool looping = false;
    // Start is called before the first frame update
    IEnumerator Start()
    {
        do
        {
            yield return StartCoroutine(SpawnWaves());
        }
        while (looping);
    }

    IEnumerator SpawnWaves()
    {
        for(int i = startingWave; i < waves.Count; i++)
        {
            var currentWave = waves[i];
            yield return StartCoroutine(SpawnEnemys(currentWave));
        }
    }

    IEnumerator SpawnEnemys(WaveConfig wave)
    {
        for (int i = 0; i < wave.GetEnemyNumber(); i++)
        {
            var enemy = Instantiate(wave.GetEnemyPrefab(), wave.GetWaypoints()[0].transform.position, Quaternion.identity);
            enemy.GetComponent<EnemyPathing>().SetWaveConfig(wave);
            yield return new WaitForSeconds(wave.GetSpawnTime());
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
