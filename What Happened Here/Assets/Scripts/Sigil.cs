using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sigil : MonoBehaviour
{
    public Transform mask;
    [TextArea]
    public string[] text;
    // Start is called before the first frame update
    void Start()
    {
        mask.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerController player = collision.GetComponent<PlayerController>();
        if (player)
        {
            mask.gameObject.SetActive(true);
            DialogManager.instance.SetDialog(text);

            player.lastSigilLocation = transform.position + Vector3.down;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        PlayerController player = collision.GetComponent<PlayerController>();
        if (player)
        {
            mask.gameObject.SetActive(false);
            DialogManager.instance.Deactivate();
        }
    }
}
