using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : Collidable
{
    // damage to the monster
    public int[] dmgPoint = { 1, 2, 3 };
    public float[] pushBack = { 5.0f, 5.1f, 5.2f };

    // upgrade weapon
    public int weaponLevel = 0;
    private SpriteRenderer spriteRenderer;

    // swing
    private Animator animator;
    private float cooldown = 0.5f;
    private float lastSwing;
    protected override void Start()
    {
        base.Start();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    protected override void Update()
    {
        base.Update();
        if (GameManager.instance.deadAnimator.GetBool("check"))
        {
            weaponLevel = 0;
        }
        SetWeaponRender();
        // press space to swing
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (Time.time - lastSwing > cooldown)
            {
                lastSwing = Time.time;
                Swing();
            }
        }
    }
    protected override void OnCollide(Collider2D col)
    {
        // check tag for monster and player so they can fight each other
        if (col.CompareTag("Fighter"))
        {
            // so that sword not collide with player
            if (col.name != "Player")
            {
                Damage dmg = new Damage()
                {
                    dmgPoint = this.dmgPoint[weaponLevel],
                    origin = transform.position,
                    pushBack = this.pushBack[weaponLevel]
                };
                col.SendMessage("ReceiveDmg", dmg);
            }
        }
    }

    //trigger swing animator
    private void Swing()
    {
        animator.SetTrigger("Swing");
    }

    //Upgrade weapons
    public void UpgradeWeapon()
    {
        weaponLevel++;
        //Debug.Log(weaponLevel);
    }

    //Weapon sprite
    public void SetWeaponRender()
    {
        spriteRenderer.sprite = GameManager.instance.weaponSprites[weaponLevel];
    }
}
