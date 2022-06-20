using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class CanvasManager : MonoBehaviour
{
    [Header("Buttons")]
    public Button startButton;
    public Button quitButton;
    public Button goToMenuButton;

    public void StartGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void Quit()
    {
        UnityEditor.EditorApplication.isPlaying = false;
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    // Start is called before the first frame update
    void Start()
    {
        if (quitButton)
            quitButton.onClick.AddListener(() => Quit());
        
        
        if (startButton)
            startButton.onClick.AddListener(() => StartGame());
        
        
        if (goToMenuButton)
            goToMenuButton.onClick.AddListener(() => MainMenu());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
