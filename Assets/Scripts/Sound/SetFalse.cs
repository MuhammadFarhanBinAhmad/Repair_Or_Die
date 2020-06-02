using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetFalse : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("SetItFalse", GetComponent<AudioSource>().clip.length+0.5f);
    }
    void SetItFalse()
    {
        this.gameObject.SetActive(false);
        InvokeRepeating("Check", 0, 0.5f);
    }
    void Check()
    {
        this.gameObject.SetActive(false);
    }
}
