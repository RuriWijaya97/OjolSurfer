using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
public class InGameSceneController : MonoBehaviour
{

    public GameObject PauseMenu;
    private bool pauseOn;

    void Start()
    {
        pauseOn = false;
    }

    public void ChangeScene(string SceneName)
    {
        SceneManager.LoadScene(SceneName);
    }

    public void retryScene()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        string currentSceneName = currentScene.name;
        SceneManager.LoadScene(currentSceneName);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!pauseOn)
            {
                Time.timeScale = 0;
                PauseMenu.SetActive(true);
                pauseOn = true;
            }
            else
            {
                Time.timeScale = 1;
                PauseMenu.SetActive(false);
                pauseOn = false;
            }
        }
    }
}
