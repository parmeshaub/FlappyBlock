using System.Collections;
using System.Collections.Generic;
using System.Security.Authentication.ExtendedProtection;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SocialPlatforms.Impl;

public class BlockScript : MonoBehaviour
{
    public GameObject block;
    private Rigidbody rb;
    public float jumpForce;
    private InterfaceManager ui;
    private int score = 0;
    public bool isAlive = true;
   
    private void Start()
    {
        rb = block.GetComponent<Rigidbody>();
        ui = InterfaceManager.instance;
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Score"))
        {
            score++;
            ui.score.text = score.ToString();
            
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Death"))
        {
            isAlive = false;
            rb.AddForce(-10, 2, 0, ForceMode.Impulse);
        }
        
    }

    void OnJump()
    {
        if (isAlive)
        {
            rb.velocity = Vector3.zero;
            rb.AddForce(0, jumpForce, 0, ForceMode.Impulse);
        }
        

    }
}
