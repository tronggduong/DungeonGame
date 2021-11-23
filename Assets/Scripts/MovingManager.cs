using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MovingManager : Fighter
{
    protected Vector3 originalSize;
    protected BoxCollider2D boxCollider;
    protected Vector3 moveDelta;
    protected RaycastHit2D hit;
    protected float verticalSpeed = 1.0f;
    protected float horizontalSpeed = 1.0f;
    protected virtual void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        originalSize = transform.localScale;
    }
    protected virtual void UpdateFaceDirection()
    {
        if (moveDelta.x > 0) transform.localScale = originalSize;
        else if (moveDelta.x < 0) transform.localScale = new Vector3(originalSize.x*-1, originalSize.y* 1, 1);
    }
    protected virtual void UpdateMovement(Vector3 input)
    {
        // change the default speed of fighter
        moveDelta = new Vector3(input.x * horizontalSpeed, input.y * verticalSpeed, 0);

        // face direction (right or left)
        UpdateFaceDirection();

        // add push back
        moveDelta += pushForce;
        // to reduce push force base on push recovery 
        pushForce = Vector3.Lerp(pushForce,Vector3.zero,pushRecovery);

        // make a box in front of player to check first, if no collider -> can move
        hit = Physics2D.BoxCast(transform.position,
                                boxCollider.size,
                                0,
                                new Vector2(moveDelta.x, 0),
                                Mathf.Abs(moveDelta.x * Time.deltaTime),
                                LayerMask.GetMask("Human", "Blocking"));

        if (hit.collider == null)
        {
            // move player horrizontal
            transform.Translate(moveDelta.x * Time.deltaTime, 0, 0);
        }

        // make a box in front of player to check first, if no collider -> can move
        hit = Physics2D.BoxCast(transform.position,
                                boxCollider.size,
                                0,
                                new Vector2(0, moveDelta.y),
                                Mathf.Abs(moveDelta.y * Time.deltaTime),
                                LayerMask.GetMask("Human", "Blocking"));

        if (hit.collider == null)
        {
            // move player vertical
            transform.Translate(0, moveDelta.y * Time.deltaTime, 0);
        }
    }
}
