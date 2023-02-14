using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackScreenController : MonoBehaviour
{
    //animator
    Animator animator;

    public Transform player;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = player.position;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.K) )//&& isRollCooldown==false)
        {
            animator.SetTrigger("fadeOut");
            transform.position = player.position;
        }
    }
}
