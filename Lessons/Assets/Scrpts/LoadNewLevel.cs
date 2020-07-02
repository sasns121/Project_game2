using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LoadNewLevel : MonoBehaviour
{
    public int SceneNumber = 0;
    public ActivateButton activateButton;
    public void LoadLevel2()
    {
        SceneNumber = SceneManager.GetActiveScene().buildIndex + 1;
        if (SceneNumber < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(SceneNumber);
        }
        else
        {
            Debug.Log("это последний уровень");
        }
    }

    public void reload()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        PlayerCount.coins = PlayerCount.OnStartCions;
        PlayerCount.hp = 2;
        activateButton.Down = activateButton.StartDown;
    }
}
