using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEnemy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("bullet"))
        {
            Hit(); 
            //Maybe add delay till procetile dissappears
            Destroy(col.gameObject);
        }
    }

    private void Hit()
    {
         
    }

    
}
