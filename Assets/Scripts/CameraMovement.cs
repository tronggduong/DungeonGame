using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private Transform lookAt; //Player position
    public float boundaryX = 0.3f;
    public float boundaryY = 0.5f;
    private void Start()
    {
        lookAt = GameObject.Find("Player").transform;
    }
    void LateUpdate()
    {
        Vector3 delta = Vector3.zero;

        // distance between Player and Camera
        float deltaX = lookAt.position.x - transform.position.x;
        float deltaY = lookAt.position.y - transform.position.y;

        // check to see Player go left or right
        if (deltaX > boundaryX || deltaX < -boundaryX)
        {
            // Player on the left of the camera
            if (lookAt.position.x < transform.position.x)
            {
                delta.x = deltaX + boundaryX;
            }
            // Player on the right of the camera
            else delta.x = deltaX - boundaryX;
        }

        // check to see Player go up or down
        if (deltaY > boundaryY || deltaY < -boundaryY)
        {
            // Player under the camera
            if (lookAt.position.y < transform.position.y)
            {
                delta.y = deltaY + boundaryY;
            }
            // Player on top of camera
            else delta.y = deltaY - boundaryY;
        }

        // move camera
        transform.position += new Vector3(delta.x, delta.y, 0);
    }
}
