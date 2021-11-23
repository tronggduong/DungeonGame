using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : EnemyHitbox
{
    protected override void Start()
    {
        base.Start(); 
        dmgPoint = 1;
        pushBack = 1;
    }
}
