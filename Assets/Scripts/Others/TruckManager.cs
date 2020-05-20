using UnityEngine;

public class TruckManager : MonoBehaviour
{
    public float truck_Health;

    public bool EndGame()
    {
        if (truck_Health > 100)
        {
            print("hit");
            return true;
        }
        else
        return false;
    }

    public void CurrentTruckHealth()
    {
        truck_Health += 0.01f;
    }
}
