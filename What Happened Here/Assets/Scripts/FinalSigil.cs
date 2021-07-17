using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalSigil : Sigil
{
    // Start is called before the first frame update
    void Start()
    {
        mask.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerController player = collision.GetComponent<PlayerController>();
        if (player)
        {
            // awful awful code lol, if you're reading this, the code is so bad bc I lost interest in this project but I want it to be done
            mask.gameObject.SetActive(true);
            player.canMove = false;
            Camera.main.GetComponent<Animator>().SetTrigger("ZoomOut");
            GameObject.FindGameObjectWithTag("EndPanel").GetComponent<Animator>().SetTrigger("EndScreen");
            GameObject.FindGameObjectWithTag("EndText").GetComponent<Animator>().SetTrigger("End");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        
    }
}
