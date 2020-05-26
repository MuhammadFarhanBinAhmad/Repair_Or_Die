using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerUI : MonoBehaviour
{
    PlayerManager the_Player_Manager;
    //health
    [Header("Health")]
    public Image player_Health_Bar;
    //Ammo
    [Header("Ammo")]
    public TextMeshProUGUI Ammo;
    //Money
    [Header("Money")]
    public TextMeshProUGUI Money;

    private void Start()
    {
        the_Player_Manager = FindObjectOfType<PlayerManager>();
    }
    public void UpdateHealthUI()
    {
        player_Health_Bar.fillAmount = the_Player_Manager.entity_Health / the_Player_Manager.entity_BasicStates.health;
    }
    public void UpdateMoneyUI()
    {
        Money.text = "$"+the_Player_Manager.total_Money.ToString();
    }
    public void UpdateAmmoUI()
    {

    }
}
