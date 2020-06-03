using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransistion : MonoBehaviour
{
    public void ChangeScene(string Scene)
    {
        SceneManager.LoadScene(Scene);
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
