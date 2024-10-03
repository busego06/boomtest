using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExistTimer : MonoBehaviour
{
    public float lifetime;
    public float timer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer+=Time.deltaTime;
        if(timer>=lifetime){
            Destroy(gameObject);
        }
    }
}
