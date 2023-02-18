using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WakeUp : MonoBehaviour
{

    public UnityEvent OnWake;
    Animator animator;
    bool sleeping=true;
    float wakeTimer=160;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        if(sleeping==false && wakeTimer>-1)
        { 
            wakeTimer--;
            if(wakeTimer<0) Wake();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && sleeping==true)//&& isRollCooldown==false)
        {
            sleeping=false;
            animator.SetTrigger("wake");
        }
    }

    void Wake()
    {
        OnWake?.Invoke();
    }

}
