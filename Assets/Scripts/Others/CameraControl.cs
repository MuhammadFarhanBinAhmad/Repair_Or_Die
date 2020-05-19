using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public Transform the_Player;

    private void FixedUpdate()
    {
        this.transform.position = new Vector3(the_Player.transform.position.x, transform.localPosition.y,transform.localPosition.z);
    }
}
