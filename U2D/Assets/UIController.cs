using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{

    public Button startButton;
    public Button exitButton;

    // Start is called before the first frame update
    void Start()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;

        startButton = root.Q<Button>("start-button");
        exitButton = root.Q<Button>("exit-button");

        startButton.clicked += StartButtonPressed;
        exitButton.clicked += ExitButtonPressed;
    }

    void StartButtonPressed()
    {
        SceneManager.LoadScene("SampleScene");
    }

    void ExitButtonPressed()
    {
        Application.Quit();
    }
}
