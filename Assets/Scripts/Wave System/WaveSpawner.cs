using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class WaveSpawner : MonoBehaviour
{
    [SerializeField]
    Transform[] spawnPositions; 

    [SerializeField]
    WaveGroup[] waveGroups;

    public bool IsSpawnning;

    WaveGroup _currentWaveGroup;
    EnemyGroup _currentEnemyGroup;

    //Should either Sub to LevelManager -> or report themeselves and then do nothing "of their own accord"
    private void Start()
    {
        LevelManager.Instance.RegisterWaveSpawner(this);
    }

    //public void CallSpawnRandomWave()
    //{
    //    //StartCoroutine(nameof(SpawnRandomWaveGroup));

    //}
    public void CallSpawnRandomWave()
    {
        Debug.Log($"{name} began spawning.");
        IsSpawnning = true;

        _currentWaveGroup = Helper.GetRandomElementFromArray(waveGroups);

        TEMP_TIME.OnGameTimeTick += OnTick_SpawnCurrentWaveGroup;
    }

    IEnumerator SpawnRandomWaveGroup()
    {
        Debug.Log($"{name} began spawning.");
        IsSpawnning = true;

        _currentWaveGroup = Helper.GetRandomElementFromArray(waveGroups);

        foreach (var enemyGroup in _currentWaveGroup.enemyGroups)
        {
            for (int i = 0; i < enemyGroup.spawnRate.x; i++)
            {
                GameObject go = Instantiate(enemyGroup.prefab, Helper.GetRandomElementFromArray(spawnPositions));
                yield return new WaitForSeconds(enemyGroup.spawnRate.y); //TBF - INSTEAD OF THIS - SUB TO TICK!
            }
        }
        Debug.Log($"{name} has finished spawning.");
        IsSpawnning = false;
        _currentWaveGroup = null;
    }

    //happens every game-tick
    void OnTick_SpawnCurrentWaveGroup()
    {
        //_currentWaveGroup.TickAllGroups();
        int doneCount = 0;
        foreach (var enemyGroup in _currentWaveGroup.enemyGroups)
        {
            if (enemyGroup.spawnRate.x <= 0f)
            {
                doneCount++;
                continue;
            }
            enemyGroup.tick++;
            if(enemyGroup.tick >= enemyGroup.spawnRate.y)
            {
                enemyGroup.tick = 0f;
                GameObject go = Instantiate(enemyGroup.prefab, Helper.GetRandomElementFromArray(spawnPositions));
                enemyGroup.spawnRate.x--; //to reduce the remaining enemies to spawn - likely temp. TBF
            }
        }
        if (doneCount == _currentWaveGroup.enemyGroups.Length)
        {
            Debug.Log($"{name} completed spawning and is unsubbing from tick");
            IsSpawnning = false;
            TEMP_TIME.OnGameTimeTick -= OnTick_SpawnCurrentWaveGroup;
        }
    }


}
