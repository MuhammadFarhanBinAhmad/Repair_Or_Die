using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EnemyUI : MonoBehaviour
{
    public Image entity_Health_Bar;

    BasicStates the_Base_AI;

    private void Start()
    {
        the_Base_AI = GetComponent<BasicStates>();
    }

    private void FixedUpdate()
    {
        entity_Health_Bar.fillAmount = the_Base_AI.entity_Health / the_Base_AI.entity_BasicStates.health;
    }
}
