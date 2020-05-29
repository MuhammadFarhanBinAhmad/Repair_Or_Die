using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnManager : MonoBehaviour
{
    [System.Serializable]
    public class WaveComponents
    {
        //EnemyType
        //0 = BaseEnemy
        //1 = HeavyEnemy
        //3 = FastEnemy
        //4 = FlyingEnemy
        public List<int> enemy_Type_To_Spawn = new List<int>();
        public List<GameObject> enemy_Type = new List<GameObject>();
    }
    [Header("Enemy Pool")]
    //wave Stats
    public int current_Wave;
    //Pool
    public int pool_Amount;
    List<GameObject> enemy_Prefab_Pool = new List<GameObject>();
    public List<GameObject> enemy_Prefab = new List<GameObject>();
    //Waves
    [Header("Wave Component")]
    public List<WaveComponents> current_Amount_Of_Enemy_Spawn = new List<WaveComponents>();
    public Transform spawn_Pos;
    public int total_Enemy_Left;
    int enemy_Left_To_Spawn;

    private void Start()
    {
        CountTotalEnemy();
        StartCoroutine("StartSpawningEnemy");
    }
    IEnumerator StartSpawningEnemy()
    {
        yield return new WaitForSeconds(2);
        if (enemy_Left_To_Spawn > 0)
        {
            RandomValue();
            print("SpawningEnemy");
        }
    }
    void RandomValue()
    {
        int R = Random.Range(0, current_Amount_Of_Enemy_Spawn[current_Wave].enemy_Type.Count);
        if (current_Amount_Of_Enemy_Spawn[current_Wave].enemy_Type_To_Spawn[R] > 0)
        {
            SpawningEnemy(R);
            print("GiveRandomValue");
        }
        else
        {
            RandomValue();
        }

    }
    void SpawningEnemy(int RV)
    {
        Instantiate(current_Amount_Of_Enemy_Spawn[current_Wave].enemy_Type[RV], spawn_Pos.transform.position, spawn_Pos.transform.rotation);
        current_Amount_Of_Enemy_Spawn[current_Wave].enemy_Type_To_Spawn[RV]--;
        enemy_Left_To_Spawn--;
        print("EnemySpawn");
        StartCoroutine("StartSpawningEnemy");
    }
    IEnumerator WaveEnded()
    {
        if (total_Enemy_Left == 0)
        {
            yield return new WaitForSeconds(5);
            current_Wave++;
            CountTotalEnemy();
            print("StartNewWave");
            StartCoroutine("StartSpawningEnemy");
        }
    }
    void CountTotalEnemy()
    {
        total_Enemy_Left =
current_Amount_Of_Enemy_Spawn[current_Wave].enemy_Type_To_Spawn[0]
+ current_Amount_Of_Enemy_Spawn[current_Wave].enemy_Type_To_Spawn[1]
+ current_Amount_Of_Enemy_Spawn[current_Wave].enemy_Type_To_Spawn[2]
+ current_Amount_Of_Enemy_Spawn[current_Wave].enemy_Type_To_Spawn[3];
        enemy_Left_To_Spawn = total_Enemy_Left;
    }


}
