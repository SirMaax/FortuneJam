using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Movement_Controller_RB_Topdown_2D : MonoBehaviour
{
    [Header("Behavior of Controller")] 
    public bool useAcceleration;
    public bool instantSpeed;
    
    
    
    [Header("Attributes")] 
    private Rigidbody2D rb;

    
    [Header("Refs")] 
    public InputHandler ip;

    
    [Header("Status")]
    private bool inputSwitched = false;
    private int[] lastInput;
    
    
    [Header("Movement Attributes")]
    [SerializeField] private float speed;

    
    [Header("Acceleration Variables")]
    [SerializeField] private float speedIncrease;
    [SerializeField] private float maxSpeed;
    private float startSpeed;
    

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;

        if (useAcceleration)
        {
            startSpeed = speed;
            lastInput = new int[4] { 0, 0, 0, 0 };
        }
        
    }

    // Update is called once per frame 
    void Update()
    {
        if (useAcceleration)
        {
            if (lastInput[0] == 1 && ip.move.x < 0) inputSwitched = true;
            else if (lastInput[1] == 1 && ip.move.x > 0) inputSwitched = true;
            else if (lastInput[2] == 1 && ip.move.y > 0) inputSwitched = true;
            else if (lastInput[3] == 1 && ip.move.y < 0) inputSwitched = true;
            else inputSwitched = false;
            
            lastInput[0] = ip.move.x > 0 ? 1 : 0;
            lastInput[1] = ip.move.x < 0 ? 1 : 0;
            lastInput[2] = ip.move.y < 0 ? 1 : 0;
            lastInput[3] = ip.move.y > 0 ? 1 : 0;
        }
    }

    private void FixedUpdate()
    {
        if (useAcceleration) IncreaseMovementValues();
        Movement();
    }

    void Movement()
    {
        rb.AddForce(ip.move * speed);
        // Mathf.Clamp()
            
    }


    /**
     * Increases the values necessary for Acceleration and keeps them in check
     */
    void IncreaseMovementValues()
    {
        if(!inputSwitched && ip.move.x != 0) speed = Mathf.Clamp(speed + speedIncrease, 0, maxSpeed);
        else speed = startSpeed;
    }
}