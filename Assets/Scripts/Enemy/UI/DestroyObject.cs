using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("Destroy", 2);   
    }
    private void FixedUpdate()
    {
        transform.Translate(Vector2.up * 1);
    }
    private void Destroy()
    {
        Destroy(gameObject);
    }
}
