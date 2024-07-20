using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpeningToGameplay : MonoBehaviour
{
    public string gameplayPath;

    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            ChangeToGameplay();
        }

    }

    public void ChangeToGameplay()
    {
        SceneManager.LoadScene(gameplayPath);
    }
}
