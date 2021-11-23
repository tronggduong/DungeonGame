using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MovingManager
{
    private Animator levelUpAnimator;
    private SpriteRenderer playerSkin;

    protected override void Start()
    {
        base.Start();
        //hitPoint = 10;
        //maxHitPoint = 15;
        immuneTime = 1.0f;
        playerSkin = GetComponent<SpriteRenderer>();
        levelUpAnimator = GetComponent<Animator>();
    }
    private void FixedUpdate()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        if (!isDead)
        {
            UpdateMovement(new Vector3(x, y, 0));
        }
    }
    public void SwapPlayerSkin(int skin)
    {
        playerSkin.sprite = GameManager.instance.playerSprites[skin];
    }

    //Increase max health
    public void LevelUp()
    {
        levelUpAnimator.SetTrigger("LevelUp");
        for (int i = 0; i < GameManager.instance.GetLevel() - 1; i++)
        {
            maxHitPoint++;
        }
        hitPoint = maxHitPoint;
    }
    protected override void Death()
    {
        GameManager.instance.deadAnimator.SetBool("check", true);

    }
    /*
    //Save your health when you reopen the game 
    public void SetLevel(int level)
    {
        for (int i = 0; i < level; i++)
        {
            LevelUp();
        }
    }
    public void Heal(int heal)
    {
        hitPoint += heal;
    }
    */
}
