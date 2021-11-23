using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : Collidable
{
    protected bool check = false;
    protected SpriteRenderer items;

    protected override void Start()
    {
        base.Start();
        items = GetComponent<SpriteRenderer>();
    }
    protected override void OnCollide(Collider2D col)
    {
        if (col.name == "Player")
        {
            OnCollect();
        }
    }
    protected virtual void OnCollect() { }
}
