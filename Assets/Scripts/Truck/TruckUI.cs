using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class TruckUI : MonoBehaviour
{
    public Image truck_Repair;
    public TextMeshProUGUI the_Current_Percentage;

    TruckManager the_Truck_Manager;

    private void Start()
    {
        the_Truck_Manager = FindObjectOfType<TruckManager>();
    }

    internal void TruckCurrentRepairUI()
    {
        truck_Repair.fillAmount = the_Truck_Manager.truck_Health / 100;
        the_Current_Percentage.text = the_Truck_Manager.truck_Health.ToString("0.00") + "%" + "/" + "100%";
    }
}
