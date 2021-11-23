using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collidable : MonoBehaviour
{
    private ContactFilter2D filter;
    private BoxCollider2D boxCollider;
    private readonly Collider2D[] hits = new Collider2D[10];
    protected virtual void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        //find collision through the filter and put the result in hits
        boxCollider.OverlapCollider(filter, hits);
        for (int i = 0; i < hits.Length; i++)
        {
            //if not collision with anything then continue
            if (hits[i] == null)
            {
                continue;
            }
            OnCollide(hits[i]);
            //clean up the collision one
            hits[i] = null;
        }
    }

    protected virtual void OnCollide(Collider2D col)
    {
        Debug.Log("Not implemented for" + this.name);
    }
}
