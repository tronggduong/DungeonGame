using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : Collectable
{
    public Sprite empty;
    protected int moneyAmount;
    public int minMoney;
    public int maxMoney;

    protected override void Start()
    {
        base.Start();
        moneyAmount = Random.Range(minMoney, maxMoney);
    }
    protected override void OnCollect()
    {
        if (!check)
        {
            check = true;
            //render new sprite after interact with player
            items.sprite = empty;
            GameManager.instance.money += moneyAmount;
            GameManager.instance.ShowText("+ " + moneyAmount + " money", 40, Color.yellow, transform.position, Vector3.up * 100, 1.0f);
        }
    }
}
