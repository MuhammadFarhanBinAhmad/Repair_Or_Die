using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunSound : MonoBehaviour
{
    public GameObject the_Gun_Sound;
    public GameObject the_Sound_Manager;
    public int pooled_Amount;
    internal List<GameObject> sound_Pool_List = new List<GameObject>();

    private void Start()
    {
        for (int i = 0; i <= pooled_Amount; i++)
        {
            GameObject GS = (GameObject)Instantiate(the_Gun_Sound);
            sound_Pool_List.Add(GS);
            GS.SetActive(false);
            GameObject.DontDestroyOnLoad(GS);
            GS.transform.parent = the_Sound_Manager.transform;
        }
    }
    public void ShootingGun(AudioClip GS)
    {
        for (int i = 0; i < sound_Pool_List.Count; i++)
        {
            if (!sound_Pool_List[i].activeInHierarchy)
            {
                sound_Pool_List[i].GetComponent<AudioSource>().clip = GS;
                sound_Pool_List[i].SetActive(true);
                break;
            }
        }
    }

}
