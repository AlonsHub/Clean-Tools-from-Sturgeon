using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;

    List<WaveSpawner> _waveSpawners;

    //Temp TBF
    [SerializeField]
    float _levelStartDelay = 0.2f;

    private void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        _waveSpawners = new List<WaveSpawner>();
    }

    public void RegisterWaveSpawner(WaveSpawner ws)
    {
        _waveSpawners.Add(ws);
    }

    void Start()
    {
        Invoke(nameof(StartLevel), _levelStartDelay);
    }

    void StartLevel()
    {
        int rnd = Random.Range(0, _waveSpawners.Count);
        _waveSpawners[rnd].CallSpawnRandomWave();
    }
}
