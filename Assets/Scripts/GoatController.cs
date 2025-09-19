using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class GoatController : MonoBehaviour
{
    [Header("Movement Settings")]
    public float acceleration;
    public float groundSpeed;
    public float jumpSpeed;
    [Range(0f, 1f)]
    public float groundDecay;

    [Header("Components")]
    public Rigidbody2D body;
    public BoxCollider2D groundCheck;
    public LayerMask groundMask;

    [Header("Logic")]
    public bool isAlive = true;
    public int saltCollected = 0;
    public LogicManager logicManager;

    float xInput;
    float yInput;
    public bool grounded;

    private AudioSource audioSource;

    public AudioClip saltCollectionSound;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        GetInput();
        HandleJump();
    }

    private void FixedUpdate()
    {
        //Stop all movement when dead
        if (!isAlive) return;
        
        CheckGround();
        ApplyFriction();
        MoveWithInput();
    }

    void GetInput()
    {
        xInput = Input.GetAxis("Horizontal");
        yInput = Input.GetAxis("Vertical");
    }

    void MoveWithInput()
    {
        if (Mathf.Abs(xInput) > 0)
        {
            float increment = xInput * acceleration;
            float newSpeed = Mathf.Clamp(body.velocity.x + increment, -groundSpeed, groundSpeed);
            body.velocity = new Vector2(newSpeed, body.velocity.y);

            float direction = Mathf.Sign(xInput);
            transform.localScale = new Vector3(direction, 1, 1);
        }
    }

    void HandleJump()
    {
        if (Input.GetButtonDown("Jump") && grounded)
        {
            body.velocity = new Vector2(body.velocity.x, jumpSpeed);
        }
    }

    void CheckGround()
    {
        grounded = Physics2D.OverlapAreaAll(groundCheck.bounds.min, groundCheck.bounds.max, groundMask).Length > 0;
    }

    void ApplyFriction()
    {
        if (grounded && xInput == 0 && body.velocity.y <= 0)
        {
            body.velocity *= groundDecay;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Salt collection
        if (collision.CompareTag("Salt"))
        {
            collision.gameObject.SetActive(false);
            if (logicManager != null)
                logicManager.AddSalt(1);
            saltCollected++;
            Debug.Log("Salt collected!");

            //Play sound
            if (saltCollectionSound != null)
            {
                audioSource.PlayOneShot(saltCollectionSound);
            }
        }

        //Enemy collision
        if (collision.CompareTag("Enemy"))
        {
            IsDead();
            Debug.Log("Goat died: hit enemy.");
        }

        //Abyss collision
        //if (collision.gameObject.name == "Abyss") ;
        //{
        //    IsDead();
        //    Debug.Log("Goat died: fell into abyss.");
        //}
    }

    private void IsDead()
    {
        isAlive = false;
        body.velocity = Vector2.zero;
        body.isKinematic = true;
            
        if (logicManager != null)
            logicManager.LoseGame();
    }
}
