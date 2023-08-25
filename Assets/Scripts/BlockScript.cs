using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockScript : MonoBehaviour
{
    public GameObject block;
    private Rigidbody rb;
    public float jumpForce;
   
    private void Start()
    {
        rb = block.GetComponent<Rigidbody>();
    }

    void Update()
    {
        //Jump
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = Vector3.zero;
            rb.AddForce(0,jumpForce,0,ForceMode.Impulse);
        }
    }
}
