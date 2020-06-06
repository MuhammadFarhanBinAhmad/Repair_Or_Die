using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RocketCutSceneAnim : MonoBehaviour
{
    public GameObject black_Out_Screen;

    Animator the_Anim;
    Rigidbody2D the_RB;

    private void Start()
    {
        the_Anim = GetComponentInParent<Animator>();
        StartCoroutine("StartIdleAnim");
    }

    public void StartBlackOutAnim()
    {
        StartCoroutine("BlackOut");
        black_Out_Screen.SetActive(true);
        the_Anim.SetTrigger("BlackOut");
    }
    IEnumerator StartIdleAnim()
    {
        yield return new WaitForSeconds(the_Anim.GetCurrentAnimatorStateInfo(0).length);
        the_Anim.SetTrigger("Idleing");
    }
    IEnumerator BlackOut()
    {
        yield return new WaitForSeconds(the_Anim.GetCurrentAnimatorStateInfo(0).length);
        SceneManager.LoadScene("PlayingScene");
    }

}
