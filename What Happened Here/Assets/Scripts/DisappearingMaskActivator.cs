using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisappearingMaskActivator : MonoBehaviour
{
    public DisappearingMaskManager manager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (manager)
            manager.SetActiveMasks(true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (manager)
            manager.SetActiveMasks(false);
    }
}
