using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AnimationEnemy : Enemy
{
    private Animator monsterAnimator;
    protected override void Start()
    {
        base.Start();
        monsterAnimator = GetComponent<Animator>();
    }
    private void FixedUpdate()
    {
        //iddle animation when enemy return to old position
        CheckStartPosion();

        //chase after player
        ChasePlayer();

        //collide with player
        CollideWithPlayer();

    }
    private void CheckStartPosion()
    {
        double xPosition = Math.Round(transform.position.x - monsterStartingPosition.x, 1);
        double yPosition = Math.Round(transform.position.y - monsterStartingPosition.y, 1);
        if (xPosition == 0 && yPosition == 0)
        {
            monsterAnimator.SetBool("check", false);
        }
    }

    private void ChasePlayer()
    {
        //if in range
        if (Vector3.Distance(playerTransform.position, monsterStartingPosition) < chaseRange)
        {

            //the range need to trigger the enemy following player
            if (Vector3.Distance(playerTransform.position, monsterStartingPosition) < triggerRange)
            {
                chasing = true;

            }
            if (chasing)
            {
                monsterAnimator.SetBool("check", true);
                if (!collidePlayer)
                {
                    //go to direction of the player
                    UpdateMovement((playerTransform.position - transform.position).normalized);
                }
            }
            else
            {
                //if exit the chase range -> return position
                UpdateMovement(monsterStartingPosition - transform.position);
            }
        }
        //if not in the chase range -> return position
        else
        {
            UpdateMovement(monsterStartingPosition - transform.position);
            chasing = false;
        }

        //Debug.Log(chasing);
        //Debug.Log("collide" + collidePlayer);
    }
}
