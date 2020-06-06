using UnityEngine;

public class TruckManager : MonoBehaviour
{
    public float truck_Health;

    TruckUI the_Truck_UI;

    public bool end_Game;

    public GameObject end_Game_Canvas;
    public Animator end_Game_Anim;

    private void Start()
    {
        the_Truck_UI = FindObjectOfType<TruckUI>();
    }
    public void CurrentTruckHealth()
    {
        truck_Health += 0.01f;
        the_Truck_UI.TruckCurrentRepairUI();
        if(truck_Health >= 100)
        {
            end_Game = true;
            truck_Health = 100;
            end_Game_Canvas.SetActive(true);
            end_Game_Anim.SetTrigger("TruckRepaired");
        }
    }
}
