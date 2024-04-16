using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public string loadgamescene = "Game";

    public void LoadGameScene()
    {
        //load the game scene
        SceneManager.LoadScene(loadgamescene);
    }
}
