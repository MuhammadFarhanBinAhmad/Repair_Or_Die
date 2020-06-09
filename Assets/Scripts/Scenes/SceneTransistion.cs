using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransistion : MonoBehaviour
{
    public virtual void ChangeScene(string Scene)
    {
        SceneManager.LoadScene(Scene);
        PlayerManager.total_Money_Collected = 0;
        EnemySpawnManager.total_Enemy_Kill = 0;
        EnemySpawnManager.current_Wave = 0;
        Time.timeScale = 1;
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
