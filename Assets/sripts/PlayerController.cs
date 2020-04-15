﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float maxSpeed = 5f;
    public float speed = 2f;
    public bool grounded;
    private Rigidbody2D rb2d;
    private Animator anim;
    public float jumpower = 6.5f;
    private bool jump;
    private bool doblesalto;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetFloat("speed", Mathf.Abs(rb2d.velocity.x));
        anim.SetBool("grounded",grounded);
        if (grounded == true){
            doblesalto = true;
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (grounded)
            {
                jump = true;
                doblesalto = true;
            }
            else if(doblesalto)
            {
                jump = true;
                doblesalto = false;
            }
            
        }
    }
    void FixedUpdate()
    {
        Vector3 fixedVelocity = rb2d.velocity;
        fixedVelocity.x *= 0.75f;

        if (grounded)
        {
            rb2d.velocity = fixedVelocity; 
        }

        float h = Input.GetAxis("Horizontal");

        rb2d.AddForce(Vector2.right * speed * h);
        

        float limitSpeed = Mathf.Clamp(rb2d.velocity.x, -maxSpeed, maxSpeed);
        rb2d.velocity = new Vector2(limitSpeed, rb2d.velocity.y);
        if (h > 0.1f)
        {
            transform.localScale = new Vector3(1f,1f,1f); 
        }
        if (h < -0.1f)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        if (jump == true)
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x,0);
            rb2d.AddForce(Vector2.up* jumpower,ForceMode2D.Impulse);
            jump = false;
        }

        Debug.Log(rb2d.velocity.x);
    }
    void OnBecameInvisible()
    {
        transform.position = new Vector3(-3.63f, -1.97f, 0f);
    }
}
    