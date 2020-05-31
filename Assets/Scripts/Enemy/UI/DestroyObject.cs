using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("Destroy", .5f);   
    }
    private void FixedUpdate()
    {
        transform.Translate(Vector2.up * .1f);
    }
    private void Destroy()
    {
        Destroy(gameObject);
    }
}
