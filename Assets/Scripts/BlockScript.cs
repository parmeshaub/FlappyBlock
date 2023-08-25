using System.Collections;
using System.Collections.Generic;
using System.Security.Authentication.ExtendedProtection;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SocialPlatforms.Impl;

public class BlockScript : MonoBehaviour
{
    [Header("References")]
    public GameObject block;
    private Rigidbody rb;
    private InterfaceManager ui;

    [Header("Variables")]
    public float jumpForce;
    private int score = 0;
    public bool isAlive = true;

    [Header("Audio")]
    public AudioSource audioSource;
    public AudioClip point;
    public AudioClip death;
    public AudioClip jump;

    //Boolean so that death effects only play once.
    private bool deathOnce = false;
   
    private void Start()
    {
        //Get reference for rigid body
        rb = block.GetComponent<Rigidbody>();

        //Get reference to the active interface manager (singleton reference)
        ui = InterfaceManager.instance;
    }

    void Update()
    {
        
    }

    //Check anything has entered our object's trigger
    private void OnTriggerEnter(Collider other)
    {
        //check if trigger has tag "Score"
        if (other.CompareTag("Score"))
        {
            //Add score
            score++;
            //Update the UI
            ui.score.text = score.ToString();
            //Play Audio
            audioSource.PlayOneShot(point);
        }
    }

    //Check if anything has collided with our object
    private void OnCollisionEnter(Collision collision)
    {
        //check if collided gameobject has tag "Death"
        if (collision.gameObject.CompareTag("Death"))
        {
            //Block Death
            isAlive = false;
            //Check if death effects has already played once
            if (!deathOnce)
            {
                //Death Effects
                //Launch the block backwards
                rb.AddForce(-10, 2, 3, ForceMode.Impulse);
                //Plays death audio
                audioSource.PlayOneShot(death);
                //Changes deathOnce to true so that this code will not run again if block hits another pipe while falling.
                deathOnce = true;
            }
            
        }
        
    }

    //On jump using unity input
    void OnJump()
    {
        //Checks to see if block is alive
        if (isAlive)
        {
            //Reset velocity so that jump can be consistent 
            rb.velocity = Vector3.zero;
            //Add jumping force.
            rb.AddForce(0, jumpForce, 0, ForceMode.Impulse);
            //Play jump sound
            audioSource.PlayOneShot(jump);
        }
        

    }
}
