using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int money;
    public int experience;
    protected bool checkRestart = false;
    
    //Reference
    public Player player;
    public Weapon weapon;
    public FloatTextManager floatTextManager;
    public Canvas menuSystem;
    public Canvas playerDisplay;
    public Canvas pauseSystem;
    public Animator deadAnimator;

    //Resources
    public List<Sprite> playerSprites;
    public List<Sprite> weaponSprites;
    public List<int> weaponPrices;
    public List<int> expList;
    private void Awake()
    {
        //If there is no game manager, create one
        if (GameManager.instance == null)
        {
            instance = this;

            //Calling load position 
            SceneManager.sceneLoaded += LoadPosition;
            DontDestroyScene();
        }
        //If there is one, delete it first => avoid making two game manager
        else
        {
            DestroyScene();
            return;
        }
    }

    //Save game object for when change scenes
    private void DontDestroyScene()
    {
        DontDestroyOnLoad(gameObject);
        DontDestroyOnLoad(player.gameObject);
        DontDestroyOnLoad(floatTextManager.gameObject);
        DontDestroyOnLoad(menuSystem.gameObject);
        DontDestroyOnLoad(playerDisplay.gameObject);
        DontDestroyOnLoad(deadAnimator.gameObject);
        DontDestroyOnLoad(pauseSystem.gameObject);
    }

    private void DestroyScene()
    {
        Destroy(gameObject);
        Destroy(player.gameObject);
        Destroy(deadAnimator.gameObject);
        Destroy(floatTextManager.gameObject);
        Destroy(menuSystem.gameObject);
        Destroy(playerDisplay.gameObject);
        Destroy(pauseSystem.gameObject);
    }

    //Show text
    public void ShowText(string message, int fontSize, Color color, Vector3 position, Vector3 motion, float duration)
    {
        floatTextManager.Show(message, fontSize, color, position, motion, duration);
    }

    //Upgrade weapon
    public bool CheckUpgradeWeapon()
    {
        //Check if the weapon max or not
        if (weaponPrices.Count <= weapon.weaponLevel)
            return false;

        //Check if player have enough money
        if (money >= weaponPrices[weapon.weaponLevel])
        {
            money -= weaponPrices[weapon.weaponLevel];
            weapon.UpgradeWeapon();
            return true;
        }

        return false;
    }

    //Get player's level
    public int GetLevel()
    {
        int currentLevel = 1;
        int nextLevel = expList[currentLevel - 1];

        while (experience >= nextLevel)
        {
            currentLevel++;
            if (currentLevel == expList.Count + 1)
            {
                return currentLevel;
            }
            nextLevel += expList[currentLevel - 1];
        }

        return currentLevel;
    }

    //Get all the experience before that level
    public int GetXPtoLevel(int level)
    {
        int currentLevel = 0;
        int xp = 0;

        while (currentLevel < level)
        {
            xp += expList[currentLevel];
            currentLevel++;
        }
        return xp;
    }

    //Check if we level up
    public void CheckLevelUp(int exp)
    {
        int currLevel = GetLevel();
        experience += exp;
        if (currLevel < GetLevel())
        {
            player.LevelUp();
        }
    }

    //Save your game data (testing with money)
    public void SaveData()
    {
        string s = "";
        s += player.hitPoint.ToString() + "|";
        s += player.maxHitPoint.ToString() + "|";
        s += money.ToString() + "|";
        s += experience.ToString() + "|";
        s += weapon.weaponLevel.ToString();
        PlayerPrefs.SetString("SaveData", s);
    }
    public void LoadPosition(Scene scene, LoadSceneMode mode)
    {
        player.transform.position = GameObject.Find("StartPosition").transform.position;
    }
    public void Retry()
    {
        deadAnimator.SetBool("check", false);
        Restart();
        SceneManager.LoadScene("Main");
    }
    protected void Restart() 
    {
        player.hitPoint = 3;
        player.maxHitPoint = 3;
        money = 0;
        experience = 0;
        weapon.weaponLevel = 0;
        player.pushForce = Vector3.zero;
    }
}
