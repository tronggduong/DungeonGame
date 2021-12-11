using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpPotion : Collectable
{
    public int expAmount;
    protected override void OnCollect()
    {
        // increase exp for player
        Destroy(gameObject);
        GameManager.instance.CheckLevelUp(expAmount);
        GameManager.instance.experience += expAmount;
        GameManager.instance.ShowText("+ " + expAmount + " exp", 40, Color.cyan, transform.position, Vector3.up * 100, 1.0f);
    }
}
