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
    public float StrictFollowTreshold;
    public float StrictFollowMultiplier;
    float zPosInit;
    //the camera zoom position; locked in at runtime
    void Start()
    {
        zPosInit = transform.position.z;
    }

    
    void FixedUpdate()
    {
        {
            float dampMult = 1f;
            Vector2 objectPos = Camera.main.WorldToScreenPoint(playerLoc.position);
            if(objectPos.x>=StrictFollowTreshold*Screen.width || objectPos.x<=StrictFollowTreshold*Screen.width*-1 || objectPos.y>=StrictFollowTreshold*Screen.height || objectPos.y<=StrictFollowTreshold*Screen.height*-1 ){dampMult = StrictFollowMultiplier; Debug.Log("strict follow");}
            transform.position = Vector3.Lerp(transform.position, 
                                            new Vector3(playerLoc.position.x, playerLoc.position.y, 
                                            zPosInit - velocityScalingFactor*Mathf.Sqrt(playerRB.velocity.x*playerRB.velocity.x + playerRB.velocity.y*playerRB.velocity.y)), 
                                            Time.fixedDeltaTime * damping * dampMult);
        }

    }
}