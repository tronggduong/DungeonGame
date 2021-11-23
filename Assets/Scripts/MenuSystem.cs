using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuSystem : MonoBehaviour
{
    public Text levelText, hitpoinText, moneyText, upgradeText, expText;
    public Image characterSelectionSprite;
    public Image weaponSprite;
    public RectTransform expBar;
    private int characterSelection = 0;
    private Animator playerDisplayAnimator;
    private bool invenCheck = false;

    //Start is called before the first frame update
    private void Start()
    {
        playerDisplayAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
        //Press E to open inventory
        if (!GameManager.instance.deadAnimator.GetBool("check"))
        {
            ShowInven();
        }
    }
    private void ShowInven()
    {
        //Open and close inventory
        if (Input.GetKeyUp(KeyCode.E))
        {
            UpdateMenu();
            invenCheck = !invenCheck;
            playerDisplayAnimator.SetBool("check", invenCheck);
        }
    }

    //Choose characters
    public void ChangeCharacters(bool change)
    {
        if (change)
        {
            characterSelection++;
            //Check out of bound player sprite
            if (characterSelection == GameManager.instance.playerSprites.Count)
            {
                characterSelection = 0;
            }
        }
        else
        {
            characterSelection--;
            //Check out of bound player sprite
            if (characterSelection < 0)
            {
                characterSelection = GameManager.instance.playerSprites.Count - 1;
            }
        }

        //Set sprite for the character in main menu
        characterSelectionSprite.sprite = GameManager.instance.playerSprites[characterSelection];
        //Set sprite for the character in game
        GameManager.instance.player.SwapPlayerSkin(characterSelection);
    }

    //Upgrade weapons
    public void OnClickUpgrade()
    {
        if (GameManager.instance.CheckUpgradeWeapon())
            UpdateMenu();
    }

    //Update the menu UI
    public void UpdateMenu()
    {
        //Player resources
        string hitPoint = GameManager.instance.player.hitPoint.ToString();
        string money = GameManager.instance.money.ToString();
        int experience = GameManager.instance.experience;

        //Weapon resources
        int weaponLevel = GameManager.instance.weapon.weaponLevel;
        List<int> weaponPrices = GameManager.instance.weaponPrices;
        List<Sprite> weaponSprites = GameManager.instance.weaponSprites;

        //Exp resources
        int currLevel = GameManager.instance.GetLevel();
        int prevLevelExp = GameManager.instance.GetXPtoLevel(currLevel - 1);
        List<int> expList = GameManager.instance.expList;

        //Weapon information
        weaponSprite.sprite = weaponSprites[weaponLevel];
        if (weaponLevel == weaponPrices.Count)
        {
            upgradeText.text = "MAX";
        }
        else
        {
            upgradeText.text = weaponPrices[weaponLevel].ToString();
        }

        //Player information
        hitpoinText.text = hitPoint;
        levelText.text = currLevel.ToString();
        moneyText.text = money;

        //Exp bar
        if (currLevel == expList.Count + 1) //Check max level
        {
            expText.text = experience + " total experience";
            expBar.localScale = Vector3.one;
        }
        else
        {
            int nextLevelExp = expList[currLevel - 1];
            int exp = experience - prevLevelExp;
            float scaleBar = (float) exp / (float) nextLevelExp;
            expText.text = exp + "/" + nextLevelExp;
            expBar.localScale = new Vector3(scaleBar, 1, 1);
        }
    }
}
