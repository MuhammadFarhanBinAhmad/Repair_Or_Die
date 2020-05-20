using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject bullet;

    public Transform spawn_Point;

    public float fire_Rate;
    float next_Time_To_Fire = 0;

    private void Update()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 5;

        Vector3 objectPos = Camera.main.WorldToScreenPoint(FindObjectOfType<PlayerManager>().transform.position);
        mousePos.x = mousePos.x - objectPos.x;
        mousePos.y = mousePos.y - objectPos.y;

        float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
        transform.localRotation = Quaternion.Euler(new Vector3(0, 0, angle));

        transform.position = FindObjectOfType<PlayerManager>().transform.position;

        if (Input.GetMouseButtonDown(0) && Time.time >= next_Time_To_Fire)
        {
            Shooting();
        }
    }

    void Shooting()
    {
        Instantiate(bullet, spawn_Point.position, spawn_Point.rotation);
        next_Time_To_Fire = Time.time + 1f / fire_Rate;
    }
}
