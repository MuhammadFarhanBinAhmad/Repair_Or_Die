using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolBullet : MonoBehaviour
{
    public GameObject bullet;
    public int pooled_Amount = 15;
    internal List<GameObject> bullet_List = new List<GameObject>();

    private void Start()
    {
        for (int i = 0; i <= pooled_Amount; i++)
        {
            GameObject O = (GameObject)Instantiate(bullet);
            bullet_List.Add(O);
            O.SetActive(false);
            GameObject.DontDestroyOnLoad(O);
        }
    }
}
