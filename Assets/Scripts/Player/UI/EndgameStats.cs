using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EndgameStats : MonoBehaviour
{

    public TextMeshProUGUI wave_Survive;
    public TextMeshProUGUI total_Money;
    public TextMeshProUGUI total_Enemy;

    private void Start()
    {
        wave_Survive.text = "Wave Survive: " + EnemySpawnManager.current_Wave.ToString();
        total_Money.text = "Total Money Earn:  " + PlayerManager.total_Money_Collected.ToString();
        total_Enemy.text = "Total Enemy Kill:  " + EnemySpawnManager.total_Enemy_Kill.ToString();
    }
}
