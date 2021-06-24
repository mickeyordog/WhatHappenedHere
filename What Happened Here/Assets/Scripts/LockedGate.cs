using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockedGate : MonoBehaviour
{
    public string color = "";
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //garbage code

        PlayerController player = collision.gameObject.GetComponent<PlayerController>();
        if (player && player.hasRedCrystal && color == "purple")
        {
            Destroy(gameObject);
        } else if (player && player.hasBlueCrystal && color == "blue")
        {
            Destroy(gameObject);
        }
    }
}
