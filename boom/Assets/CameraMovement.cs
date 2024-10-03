using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform playerLoc;
    //used for tracking the player's position
    public Rigidbody2D playerRB;
    //used for tracking the player's velocity
    public float damping = 5f;
    //used for smooth camera movement. lower number causes camera to lag behind player more
    public float velocityScalingFactor = 0.2f;
    //used for zooming out when the player is moving fast
    float zPosInit;
    //the camera zoom position; locked in at runtime
    void Start()
    {
        zPosInit = transform.position.z;
    }

    
    void FixedUpdate()
    {
        {
            transform.position = Vector3.Lerp(transform.position, 
                                            new Vector3(playerLoc.position.x, playerLoc.position.y, 
                                            zPosInit + velocityScalingFactor*Mathf.Sqrt(playerRB.velocity.x*playerRB.velocity.x + playerRB.velocity.y*playerRB.velocity.y)), 
                                            Time.fixedDeltaTime * damping);
        }

    }
}