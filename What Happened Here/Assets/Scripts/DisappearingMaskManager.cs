using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisappearingMaskManager : MonoBehaviour
{
    SpriteRenderer[] srs;
    // Start is called before the first frame update
    void Start()
    {
        srs = GetComponentsInChildren<SpriteRenderer>();
        SetActiveMasks(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            
        }
    }

    public void SetActiveMasks(bool shouldBeActive)
    {
        foreach (SpriteRenderer sr in srs)
        {
            sr.enabled = shouldBeActive;
        }
    }
}
