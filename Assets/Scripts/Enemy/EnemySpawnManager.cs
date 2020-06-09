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
    public static int current_Wave = 0;
    public bool wave_Ended;
    //Pool
    //public int pool_Amount;
    List<GameObject> enemy_Prefab_Pool = new List<GameObject>();
    public List<GameObject> enemy_Prefab = new List<GameObject>();
    //Waves
    [Header("Wave Component")]
    public List<WaveComponents> current_Amount_Of_Enemy_Spawn = new List<WaveComponents>();
    public Transform spawn_Pos;
    internal int total_Enemy_Left;
    internal int enemy_Left_To_Spawn;
    public static int total_Enemy_Kill;
    [Header("Wave UI")]
    public TextMeshProUGUI enemy_Left_UI;
    public TextMeshProUGUI current_Wave_UI;
    public Animator current_Wave_Anim;

    private void Start()
    {
        CurrentWaveUI();
        CountTotalEnemy();
        StartCoroutine("StartSpawningEnemy");
        print(current_Amount_Of_Enemy_Spawn[current_Wave].enemy_Type.Count);
    }
    IEnumerator StartSpawningEnemy()
    {
        yield return new WaitForSeconds(2);
        wave_Ended = false;
        FindObjectOfType<ShopManager>().OpeningStore();//open store
        current_Wave_Anim.SetBool("WaveStarting", false);
        // Check list if there is no more enemt left to spawn in current wave
        if (enemy_Left_To_Spawn > 0)
        {
            RandomValue();
        }
    }
    void RandomValue()
    {
        //spawn random enemy in the current list of current wave
        int R = Random.Range(0, current_Amount_Of_Enemy_Spawn[current_Wave].enemy_Type.Count);
        if (current_Amount_Of_Enemy_Spawn[current_Wave].enemy_Type_To_Spawn[R] > 0)
        {
            SpawningEnemy(R);
        }
        else
        {
            RandomValue();//calling itself a again if value given has no more enemy left to spawn
        }
    }
    //Spawn enemy
    void SpawningEnemy(int RV)
    {
        Instantiate(current_Amount_Of_Enemy_Spawn[current_Wave].enemy_Type[RV], spawn_Pos.transform.position, spawn_Pos.transform.rotation);
        current_Amount_Of_Enemy_Spawn[current_Wave].enemy_Type_To_Spawn[RV]--;
        enemy_Left_To_Spawn--;
        StartCoroutine("StartSpawningEnemy");//counter before next enemy spawn
    }
    IEnumerator WaveEnded()
    {
        //check if all enemy are dead
        if (total_Enemy_Left == 0)
        {
            ////start rest time
            current_Wave_Anim.SetBool("WaveEnded", true);
            wave_Ended = true;
            FindObjectOfType<ShopManager>().OpeningStore();//open store
            yield return new WaitForSeconds(2);
            current_Wave_Anim.SetBool("WaveEnded", false);
            yield return new WaitForSeconds(5);
            wave_Ended = false;
            current_Wave_Anim.SetBool("WaveStarting", true);
            current_Wave++;
            ////rest time ended
            //check if current wave is more then 10
            // If more, then script will start to create more wave randomly
            if (current_Wave >= 9)
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
        //Notice:Ensure that there is an extra empty component in spawn manager for code to work
        //creating new wave of random amount but of all type
        for (int i = 0; i <= 7; i++)
        {
            current_Amount_Of_Enemy_Spawn[current_Wave+1].enemy_Type.Add(enemy_Prefab[i]);
            current_Amount_Of_Enemy_Spawn[current_Wave+1].enemy_Type_To_Spawn.Add(Random.Range(5,10));
        }
    }
    void CountTotalEnemy()
    {
        //countint total amount of enemy are there in the wave(both spawn and unspawn enemy)
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
