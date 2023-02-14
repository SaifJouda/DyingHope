using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WakeUp : MonoBehaviour
{

    public UnityEvent OnWake;
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) )//&& isRollCooldown==false)
        {
            Wake();
        }
    }

    void Wake()
    {
        animator.SetTrigger("wake");
        waiter();
        OnWake?.Invoke();
    }

    IEnumerator waiter()
    {
        yield return new WaitForSeconds(2.2f);
    }
}
