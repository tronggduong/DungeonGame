using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    private Animator pauseAnimator;
    private AudioSource audioSource;
    private float musicVolume = 1f;
    private void Start()
    {
        pauseAnimator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }
    private void Update()
    {
        audioSource.volume = musicVolume;
    }
    public void SetVolume(float volume)
    {
        musicVolume = volume;
    }
    public void GamePause()
    {
        Time.timeScale = 0;
        pauseAnimator.SetTrigger("Pause");
    }
    public void GameUnpause()
    {
        Time.timeScale = 1;
        pauseAnimator.SetTrigger("Unpause");
    }
    public void Exit()
    {
        Application.Quit();
        Debug.Log("quit");
    }
}
