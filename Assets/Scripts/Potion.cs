using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potion : Collectable
{
    public int healAmount;
    protected override void OnCollect()
    {
        // if player lost some heal => can heal
        if (GameManager.instance.player.hitPoint != GameManager.instance.player.maxHitPoint) 
        {
            Destroy(gameObject);
            GameManager.instance.player.hitPoint += healAmount;
            GameManager.instance.ShowText("+ " + healAmount + " heal", 40, Color.red, transform.position, Vector3.up * 100, 1.0f);
        }
        
    }
}
