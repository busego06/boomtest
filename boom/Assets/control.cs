using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class control : MonoBehaviour
{
    public GameObject explosion;
    public float explosionDistance;
    public Rigidbody2D thisrb;
    public Vector3 mousePos;
    public Vector3 mousePosDelta;
    public Vector3 objectPos;
    public float boomForce;
    public float recoilForce;
    public float reloadTime;
    float reloadCounter;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = Input.mousePosition;
        //pixel position of the player on the screen
        objectPos = Camera.main.WorldToScreenPoint(transform.position);
        //direction of the mouse relative to the player
        mousePosDelta = Vector3.Normalize(mousePos - objectPos);
        //when Fire1 is pressed. Fire1 defaults to Mouse1 (left mouse button) iirc
        if(Input.GetButtonDown("Fire1")&&reloadCounter<=0){
            /*Debug.Log(mousePosDelta); debug code, shows mousePosDelta in the debugger*/
            //raycast
            RaycastHit2D surfacePoint = Physics2D.Raycast(transform.position + mousePosDelta*explosionDistance, mousePosDelta); 
            //creates an explosion on the nearest surface in the direction of the mouse as seen from the player.
            if(surfacePoint.collider != null){
            GameObject.Instantiate(explosion, new Vector3(surfacePoint.point.x, surfacePoint.point.y, transform.position.z), new Quaternion(0,0,0,0));}
            //recoil
            thisrb.AddForce(-1*mousePosDelta*recoilForce, ForceMode2D.Impulse);
            reloadCounter = reloadTime;
        }
        reloadCounter-=Time.deltaTime;
    }
    // is called whenever the player overlaps with a collider that has "IsTrigger" set to true
    void OnTriggerEnter2D(Collider2D Collider){
    //if the trigger is an explosion
        if(Collider.tag=="Boom"){
        //add an impulse force away from the player
            thisrb.AddForce((transform.position-Collider.gameObject.transform.position)*boomForce, ForceMode2D.Impulse);
        }
    }
}
