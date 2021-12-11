using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishGame : Collidable
{
    public Animator finishGameAnimator;
    // Update is called once per frame
    protected override void OnCollide(Collider2D col)
    {
        //GameManager.instance.SaveState();
        if (col.name == "Player")
        {
            finishGameAnimator.SetBool("check", true);

            // to stop collider
            transform.position = Vector3.one;
            Time.timeScale = 0;
        }
    }
    public void Retry()
    {
        Time.timeScale = 1;
        finishGameAnimator.SetBool("check", false);
        Restart();
        SceneManager.LoadScene("Main");
    }
    protected void Restart()
    {
        GameManager.instance.player.hitPoint = 3;
        GameManager.instance.player.maxHitPoint = 3;
        GameManager.instance.money = 0;
        GameManager.instance.experience = 0;
        GameManager.instance.weapon.weaponLevel = 0;
        GameManager.instance.player.pushForce = Vector3.zero;
    }
    public void Exit()
    {
        Application.Quit();
        Debug.Log("quit");
    }
}
