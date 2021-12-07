using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneWithButton : MonoBehaviour
{

    // Switches from Main Menu to MainScene
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

}