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
    public Rigidbody rb;
    private InterfaceManager ui;
    private GameManager gameManager;

    [Header("Variables")]
    public float jumpForce;
    private int score = 0;
    public bool isAlive = true;
    private Transform initalTransform;

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

        //Get reference to the active Game Manager
        gameManager = GameManager.instance;
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
                rb.AddForce(-10, 2, 0, ForceMode.Impulse);
                //Plays death audio
                audioSource.PlayOneShot(death);
                //Changes deathOnce to true so that this code will not run again if block hits another pipe while falling.
                deathOnce = true;
                //Run the OnPlayerDeath code in the GameManager
                gameManager.OnPlayerDeath();

                ui.scoreObject.SetActive(false);
                
            }
            
        }
        
    }

    public void ResetGame()
    {
        // Make sure to check if 'block' and 'rb' are properly assigned
        if (block == null || rb == null)
        {
            Debug.LogError("Block or Rigidbody components are not assigned.");
            return;
        }

        // Reset velocity to zero
        rb.velocity = Vector3.zero;

        // Reset other relevant variables if needed
        deathOnce = false;
        isAlive = true;

        // Reset the position to Vector3.zero
        block.transform.position = Vector3.zero;
        ui.score.text = "0";
        score = 0;
    }


    //On jump using unity input
    void OnJump()
    {
        //Checks to see if block is alive
        if (isAlive == true)
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
