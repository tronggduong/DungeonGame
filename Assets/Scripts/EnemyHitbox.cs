using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHitbox : Collidable
{
    public int dmgPoint = 1;
    public float pushBack = 5;
    protected override void OnCollide(Collider2D col)
    {
        if (col.CompareTag("Fighter") && col.name == "Player")
        {
            Damage dmg = new Damage()
            {
                dmgPoint = this.dmgPoint,
                origin = transform.position,
                pushBack = this.pushBack
            };
            col.SendMessage("ReceiveDmg", dmg);
        }
    }
}
