using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    Rigidbody2D rb;
    SpriteRenderer sr;

    public Vector3 lastSigilLocation;

    public bool hasRedCrystal = false;
    public bool hasBlueCrystal = false;
    public bool hasYellowCrystal = false;

    public static PlayerController instance;
    public bool canMove = true;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.Log("More than one instance of " + name);
            Destroy(gameObject);
        }
        instance = this;

        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();

        lastSigilLocation = transform.position;
    }

    public void Respawn()
    {
        transform.position = lastSigilLocation;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 newVeloc = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized * speed;
        rb.velocity = newVeloc;
        if (newVeloc.x < 0f)
        {
            sr.flipX = true;
        } else if (newVeloc.x > 0f)
        {
            sr.flipX = false;
        }

        if (!canMove)
            rb.velocity = Vector2.zero;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // garbage code, only doing this bc it's a game jam
        if (collision.gameObject.CompareTag("RedCrystal"))
        {
            Destroy(collision.gameObject);
            hasRedCrystal = true;
        } else if (collision.gameObject.CompareTag("BlueCrystal"))
        {
            Destroy(collision.gameObject);
            hasBlueCrystal = true;
        }
        else if (collision.gameObject.CompareTag("YellowCrystal"))
        {
            Destroy(collision.gameObject);
            hasYellowCrystal = true;
        }
    }
}
