using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] List<WaveConfig> waveConfigs;
    [SerializeField] EnemyControl EnemyControl;

    int startingWave = 0;
    int numOfEnemies = 0;
    
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    private void FixedUpdate()
    {

        if ((EnemyControl.getStarted() == true) && (startingWave == EnemyControl.getWave()))
        {
                var currentWave = waveConfigs[EnemyControl.getWave()];
                StartCoroutine(SpawnWave(currentWave));
                startingWave++;
            //   EnemyControl.setStarted(false);
        }
    }

    private IEnumerator SpawnWave(WaveConfig waveConfig)
    {
        for (int enemyCount = 0; enemyCount < waveConfig.getNumberOfEnemies(); enemyCount++)
        {
            var newEnemy = Instantiate(waveConfig.getEnemyPrefab(),
            waveConfig.getWaypoints()[0].transform.position, Quaternion.identity);

            newEnemy.GetComponent<EnemyPath>().SetWaveConfig(waveConfig);

            yield return new WaitForSeconds(waveConfig.getTimeBetweenSpawns());
        }

    }




}
