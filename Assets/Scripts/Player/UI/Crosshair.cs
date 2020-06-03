using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crosshair : MonoBehaviour
{
    public GameObject ths_Crosshair;

    private void Start()
    {
        Cursor.visible = false;
    }

    public void FixedUpdate()
    {
        ths_Crosshair.transform.position = Input.mousePosition;

        Vector3 objectPos = Camera.main.WorldToScreenPoint(FindObjectOfType<PlayerManager>().transform.position);
    }
}
