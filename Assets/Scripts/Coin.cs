using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : Chest
{
    protected override void OnCollect()
    {
        base.OnCollect();
        Destroy(gameObject);
    }
}
