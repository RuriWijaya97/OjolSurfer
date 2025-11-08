using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
public class SceneController : MonoBehaviour
{
    AudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    public void ChangeScene(string SceneName)
    {
        audioManager.muteBGM();
        audioManager.setSFXVolume(1.0f);
        audioManager.PlaySFX(audioManager.coinCollect);
        StartCoroutine(LoadSceneAfterSound(SceneName, audioManager.coinCollect.length));
        //SceneManager.LoadScene(SceneName);
    }

    private IEnumerator LoadSceneAfterSound(string SceneName,float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(SceneName); // Or nextSceneIndex
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
