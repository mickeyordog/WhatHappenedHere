using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Febucci.UI;

public class DialogManager : MonoBehaviour
{
    public TextMeshProUGUI text;
    public TextAnimatorPlayer animator;
    // Start is called before the first frame update
    void Start()
    {
        animator.ShowText("<wiggle a=0.1>Hellooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooo");
        animator.SkipTypewriter();
        //animator.onTextShowed
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
