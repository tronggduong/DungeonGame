using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fighter : MonoBehaviour
{
    public int hitPoint = 3;
    public int maxHitPoint = 3;
    public float pushRecovery = 0.1f;
    public Vector3 pushForce;
    protected float immuneTime;
    protected float immuneRecovery;
    protected bool isDead;
    private void Update()
    {
        isDead = GameManager.instance.deadAnimator.GetBool("check");
    }
    // Player and monster can take damage and die if health = 0
    protected virtual void ReceiveDmg(Damage dmg)
    {
        // if player and monster get hit then they will have some time not taking damage
        if (Time.time - immuneRecovery > immuneTime)
        {
            immuneRecovery = Time.time;
            hitPoint -= dmg.dmgPoint;
            // Calculate angle between the player and the collision point
            Vector3 dir = transform.position - dmg.origin;
            // Normalize it to get direction only and multiply it by push back force
            pushForce = dir.normalized * dmg.pushBack;

            if (!isDead)
            {
                GameManager.instance.ShowText(dmg.dmgPoint.ToString(), 40, Color.red, transform.position, Vector3.up * 100, 1.0f);
            }
            // run out of health 
            if (hitPoint <= 0)
            {
                hitPoint = 0;
                Death();
            }
        }
    }
    protected virtual void Death() { }
}
