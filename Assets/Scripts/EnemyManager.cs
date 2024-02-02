
using Abstract.Scripts;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public event Action OnStartNewWawe;
    public static Action OnEnemyStriked;
    public static Action OnEnemyMegaStriked;

    public static EnemyManager Instance;
    int enemycounter = 0;
    int waveindex = -1;

    [SerializeField] private GameMenager _gameMenager;
    [SerializeField] private Transform _destinationTarget;
    [SerializeField] private bool _started = false;
    [SerializeField] private List<WaveInfo> waveSettings = new List<WaveInfo>();

    private List<Enemy> enemies = new List<Enemy>();
    public List<Enemy> Enemies { get => enemies; set => enemies = value; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnEnable()
    {
        _gameMenager.OnGameStart += OnGameStart;
        OnStartNewWawe += EnemyManagerOnStartNewWawe;
    }

    private void OnDisable()
    {
        _gameMenager.OnGameStart -= OnGameStart;
        OnStartNewWawe -= EnemyManagerOnStartNewWawe;
    }

    private void OnGameStart()
    {
        _started = true;
        StartCoroutine(CreateWave(waveSettings));
    }
    
    private void EnemyManagerOnStartNewWawe()
    {
        _started = true;
        StartCoroutine(CreateWave(waveSettings));
    }
    
    private void Update()
    {
        
        if (enemies.Count > 0 && enemies.All(x => x.gameObject.activeSelf == false) && !_started)
        {
            OnStartNewWawe?.Invoke();
        }


        if (enemycounter == 10)
        {
            OnEnemyStriked?.Invoke();
        }
        else if (enemycounter == 49)
        {
            OnEnemyMegaStriked?.Invoke();
        }
    }

    public IEnumerator CreateWave(List<WaveInfo> waves)
    {
        waveindex++;

        yield return new WaitForSeconds(waves[waveindex].WaveDelay);

        if (enemies.Count > 0)
        {
            foreach (Enemy enemy in enemies)
            {
                Destroy(enemy.gameObject);
            }
        }

        var wave = GetNextWave(waveindex);
        enemies = new List<Enemy>();

        for (int i = 0; i < wave.EnemyCount; i++)
        {
            Enemy enemy = CreateEnemy(wave.EnemyData);
            enemy.WaveCost = wave.CostPerUnit;
            enemy.SetDestination(_destinationTarget.position);
            enemy.OnEnemyKilled += OnEnemyKilled;
            enemies.Add((Enemy)enemy);

            yield return new WaitForSeconds(2f);
        }
        _started = false;
    }


    public WaveInfo GetNextWave(int index)
    {
        try
        {
            return waveSettings[index];
        }
        catch (Exception e)
        {
            Debug.LogError(e.Message);
            return null;
        }
    }

    private Enemy CreateEnemy(EnemyData data)
    {
        switch (data.Type)
        {
            case EnemyType.GoblinUsual:
                Factory goblinFactorU = new GoblinSoliderFactory();
                return goblinFactorU.CreateUsualEnemyClass(data);
            case EnemyType.GoblinSpecial:
                Factory goblinFactorS = new GoblinSoliderFactory();
                return goblinFactorS.CreateSpecialEnemyClass(data);
            case EnemyType.OrcTankUsual:
                Factory tankFactorU = new OrcTankFactory();
                return tankFactorU.CreateUsualEnemyClass(data);
            case EnemyType.OrcTankSpecial:
                Factory tankFactorS = new OrcTankFactory();
                return tankFactorS.CreateSpecialEnemyClass(data);
            case EnemyType.FlyMigoUsual:
                Factory flyFactorU = new MigoFlyFactory();
                return flyFactorU.CreateUsualEnemyClass(data);
            case EnemyType.FlyMigoSpecial:
                Factory flyFactorS = new MigoFlyFactory();
                return flyFactorS.CreateSpecialEnemyClass(data);
            default:
                return null;
        }
    }

    private void OnEnemyKilled(float money)
    {
        _gameMenager.PlayerMoney += money;
        _gameMenager.UpdatePlayerMoney();
        enemycounter++;
    }

    [Serializable]
    public class WaveInfo
    {
        public int EnemyCount;
        public float WaveDelay;
        public float CostPerUnit;
        public EnemyData EnemyData;
    }
}