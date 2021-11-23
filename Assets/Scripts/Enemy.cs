using UnityEngine;

public class Enemy : MovingManager
{
    /* if the distance between player and enemy
     * are equal or less than trigger range
     * then enemy will chase you,
     * if u exit the chase range then enemy will stop 
     * chasing you and return to starting position 
     */
    public float triggerRange = 0.3f; //triggerRange 
    public float chaseRange = 1.5f; //chaseRange

    public int experience = 1;
    protected bool chasing = false;
    protected bool collidePlayer = false;
    protected Transform playerTransform;
    protected Vector3 monsterStartingPosition;

    //hitbox (similar to collidable script)
    public ContactFilter2D filter;
    //private BoxCollider2D hitbox;
    private readonly Collider2D[] hits = new Collider2D[10];
    protected override void Start()
    {
        base.Start();
        immuneTime = 0.5f;
        playerTransform = GameManager.instance.player.transform;
        monsterStartingPosition = transform.position;
    }
    protected void FixedUpdate()
    {
        if (!isDead)
        {
            //chase after player
            ChasePlayer();

            //collide with player
            CollideWithPlayer();
        }
    }

    protected void CollideWithPlayer()
    {
        //check collide
        collidePlayer = false;
        boxCollider.OverlapCollider(filter, hits);
        for (int i = 0; i < hits.Length; i++)
        {
            //if not collision with anything then continue
            if (hits[i] == null)
            {
                continue;
            }
            if (hits[i].CompareTag("Fighter") && hits[i].name == "Player")
            {
                collidePlayer = true;
            }
            //clean up the collision one
            hits[i] = null;
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
                //animator.SetBool("check", true);
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

    protected override void Death()
    {
        Destroy(gameObject);
        GameManager.instance.CheckLevelUp(experience);
        GameManager.instance.ShowText("+ " + experience + " exp", 40, Color.cyan, transform.position, Vector3.up * 50, 1.5f);
    }
}
