using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : Collidable
{
    public Animator changeScene;
    protected override void OnCollide(Collider2D col)
    {
        //GameManager.instance.SaveState();
        if (col.name == "Player")
        {
            GameManager.instance.SaveData();
            // load the map
            LoadNextLevel();
        }
    }
    public void LoadNextLevel()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }
    IEnumerator LoadLevel(int level)
    {
        changeScene.SetTrigger("change");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(level);
    }
    public void Quit()
    {
        Debug.Log("quit");
        Application.Quit();
    }
}
