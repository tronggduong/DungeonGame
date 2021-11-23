using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUp : MonoBehaviour
{
    private GameObject player;
    protected Vector3 originalSize;
    private void Start()
    {
        originalSize = transform.localScale;
        player = GameObject.Find("Player");
    }
    private void FixedUpdate()
    {
        if(player.transform.localScale.x > 0)
        {
            transform.localScale = originalSize;
        }
        else if(player.transform.localScale.x < 0)
        {
            transform.localScale = new Vector3(originalSize.x * -1, originalSize.y * 1, 1);
        }
    }
}
