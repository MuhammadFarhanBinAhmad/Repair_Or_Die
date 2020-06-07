using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollingBG : MonoBehaviour
{
    public RawImage scrolling_BG;

    public float speed;
    float x;
    void FixedUpdate()
    {
        x += Time.fixedDeltaTime*speed;
        scrolling_BG.uvRect = new Rect(x, 0,1,1);
    }
}
