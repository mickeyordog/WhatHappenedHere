using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    Rigidbody2D rb;
    SpriteRenderer sr;

    public bool hasRedCrystal = false;

    public static PlayerController instance;

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
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("RedCrystal"))
        {
            Destroy(collision.gameObject);
            hasRedCrystal = true;
        }
    }
}
