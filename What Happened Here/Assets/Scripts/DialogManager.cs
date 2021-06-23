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
    bool textFinishedDisplaying = false;
    string[] dialogs;
    int dialogIndex = 0;
    bool isActive = false;

    Animator anim;

    public static DialogManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.Log("More than one instance of " + name);
            Destroy(gameObject);
        }
        instance = this;

        anim = GetComponent<Animator>();
    }
    // Start is called before the first frame update
    void Start()
    {
        //animator.ShowText("<wiggle a=0.1>Hellooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooo");
        animator.onTextShowed.AddListener(TextShowedListener);
        //animator.SkipTypewriter();
        //animator.onTextShowed
    }

    // Update is called once per frame
    void Update()
    {
        if (!isActive)
            return;

        if (Input.GetMouseButtonDown(0))
        {
            if (textFinishedDisplaying)
            {
                dialogIndex++;
                if (dialogIndex >= dialogs.Length)
                {
                    anim.SetBool("shouldBeUp", false);
                    return;
                }
                    
                animator.ShowText("<wiggle a=0.1>" + dialogs[dialogIndex]);
                textFinishedDisplaying = false;
            } else
            {
                animator.SkipTypewriter();
            }
        }
    }

    void TextShowedListener()
    {
        textFinishedDisplaying = true;
        //Debug.Log("text done");
    }

    public void SetDialog(string[] dialogs)
    {
        this.dialogs = dialogs;
        textFinishedDisplaying = false;
        dialogIndex = 0;
        isActive = true;
        animator.ShowText("<wiggle a=0.1>" + dialogs[0]);
        anim.SetBool("shouldBeUp", true);
    }

    public void Deactivate()
    {
        isActive = false;
        anim.SetBool("shouldBeUp", false);
    }
}
