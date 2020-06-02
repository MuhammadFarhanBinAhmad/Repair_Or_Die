using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

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
    //public int pool_Amount;
    List<GameObject> enemy_Prefab_Pool = new List<GameObject>();
    public List<GameObject> enemy_Prefab = new List<GameObject>();
    //Waves
    [Header("Wave Component")]
    public List<WaveComponents> current_Amount_Of_Enemy_Spawn = new List<WaveComponents>();
    public List<GameObject> test = new List<GameObject>();
    public Transform spawn_Pos;
    internal int total_Enemy_Left;
    internal int enemy_Left_To_Spawn;
    [Header("Wave UI")]
    public TextMeshProUGUI enemy_Left_UI;
    public TextMeshProUGUI current_Wave_UI;
    public Animator current_Wave_Anim;

    private void Start()
    {
        CurrentWaveUI();
        CountTotalEnemy();
        StartCoroutine("StartSpawningEnemy");
    }
    IEnumerator StartSpawningEnemy()
    {
        yield return new WaitForSeconds(2);
        current_Wave_Anim.SetBool("WaveStarting", false);
        if (enemy_Left_To_Spawn > 0)
        {
            RandomValue();
        }
    }
    void RandomValue()
    {
        int R = Random.Range(0, current_Amount_Of_Enemy_Spawn[current_Wave].enemy_Type.Count);
        if (current_Amount_Of_Enemy_Spawn[current_Wave].enemy_Type_To_Spawn[R] > 0)
        {
            SpawningEnemy(R);
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
        StartCoroutine("StartSpawningEnemy");
    }
    IEnumerator WaveEnded()
    {

        if (total_Enemy_Left == 0)
        {
            yield return new WaitForSeconds(5);
            current_Wave_Anim.SetBool("WaveStarting", true);
            current_Wave++;
            if (current_Wave >= 10)
            {
                current_Amount_Of_Enemy_Spawn.Add(null);
                CreateNewWave();
            }
            CurrentWaveUI();
            CountTotalEnemy();
            StartCoroutine("StartSpawningEnemy");
        }
    }
    void CreateNewWave()
    {
        for (int i = 0; i <= 3; i++)
        {
            current_Amount_Of_Enemy_Spawn[current_Wave].enemy_Type.Add(current_Amount_Of_Enemy_Spawn[1].enemy_Type[i]);
            current_Amount_Of_Enemy_Spawn[current_Wave].enemy_Type_To_Spawn.Add(Random.Range(10,20));
        }
    }
    void CountTotalEnemy()
    {
        for (int i = 0; i <= current_Amount_Of_Enemy_Spawn[current_Wave].enemy_Type_To_Spawn.Count-1; i++)
        {
            total_Enemy_Left += current_Amount_Of_Enemy_Spawn[current_Wave].enemy_Type_To_Spawn[i];
        }
        enemy_Left_To_Spawn = total_Enemy_Left;
        CurentEnemyLeftUI();
    }
    public void CurentEnemyLeftUI()
    {
        enemy_Left_UI.text = "Enemy Left: " + total_Enemy_Left.ToString();
    }

    public void CurrentWaveUI()
    {
        current_Wave_UI.text = "Wave: " + (current_Wave +1).ToString();
    }
}
