﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public Transform the_Player;
    Camera cam;
    public float clamp_Value;

    private void Start()
    {
        cam = GetComponent<Camera>();
    }

    private void FixedUpdate()
    {
        //transform.position = new Vector3(the_Player.transform.position.x, transform.localPosition.y,transform.localPosition.z);
        transform.position = new Vector3(Mathf.Clamp(the_Player.position.x, -clamp_Value, clamp_Value), transform.localPosition.y, transform.localPosition.z);
        cam.transparencySortMode = TransparencySortMode.Orthographic;//stop clipping
    }
}
