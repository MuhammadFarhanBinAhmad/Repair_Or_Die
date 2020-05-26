using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EnemyUI : MonoBehaviour
{
    public Image entity_Health_Bar;
    Canvas entity_Canvas;
    public GameObject damage_UI;

    BaseAI the_Base_AI;

    private void Start()
    {
        entity_Canvas = GetComponentInChildren<Canvas>();
        the_Base_AI = GetComponent<BaseAI>();
    }

    private void FixedUpdate()
    {
        entity_Health_Bar.fillAmount = the_Base_AI.entity_Health / the_Base_AI.entity_BasicStates.health;
    }
    public void TakeDamageUI(float i)
    {
        GameObject UI = Instantiate(damage_UI, transform.position, transform.rotation);
        UI.transform.parent = entity_Canvas.transform;
        UI.GetComponent<TextMeshProUGUI>().text = "-"+i.ToString();
    }
}
