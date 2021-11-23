using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    private Animator pauseAnimator;
    private void Start()
    {
        pauseAnimator = GetComponent<Animator>();
    }
    public void Pause()
    {
        Time.timeScale = 0;
        pauseAnimator.SetTrigger("Pause");
    }
    public void Unpause()
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
