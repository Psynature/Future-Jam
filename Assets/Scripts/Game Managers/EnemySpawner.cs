using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] List<WaveConfigurator> waveConfigurators;
    [SerializeField] int startingWave = 0;
   // [SerializeField] bool spawnsActive = true;
  //  [SerializeField] private int endLevelCounter = 0;

    void Start()
    {
        StartCoroutine(SpawnAllWavesInLevel());
    }

    private IEnumerator SpawnAllWavesInLevel()
    {
        for (int waveIndex = startingWave; waveIndex < waveConfigurators.Count ; waveIndex++)
        {
            var currentWave = waveConfigurators[waveIndex];
            if (currentWave.GetDoubleWave() == true)
            {
                yield return new WaitForSeconds(currentWave.GetStaggerTime());
                waveIndex++;
                currentWave = waveConfigurators[waveIndex];
                yield return StartCoroutine(SpawnAllEnemiesInWave(currentWave));
            }
            else
            {
                yield return StartCoroutine(SpawnAllEnemiesInWave(currentWave));
            }
        }
    }

    private IEnumerator SpawnAllEnemiesInWave(WaveConfigurator waveConfigurator)
    {
        var numberOfEnemiesInWave = waveConfigurator.GetNumberOfEnemies();
        for (int i = 0; i < numberOfEnemiesInWave; i++)
        {
            var newEnemy = Instantiate(
                waveConfigurator.GetEnemyPrefab(),
                waveConfigurator.GetWaypoints()[0].transform.position,
                waveConfigurator.GetEnemyPrefab().transform.rotation);
            newEnemy.GetComponent<EnemyPathing>().SetWaveConfig(waveConfigurator);
            yield return new WaitForSeconds(waveConfigurator.GetTimeBetweenSpawns());        
        }
    }
}
