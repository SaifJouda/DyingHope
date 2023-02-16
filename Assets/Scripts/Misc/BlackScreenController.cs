using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BlackScreenController : MonoBehaviour
{
    //animator
    Animator animator;

    public Transform player;

    float restartDelay=0;
    bool died=false;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = player.position;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        /*
        if(Input.GetKeyDown(KeyCode.K) )//&& isRollCooldown==false)
        {
            animator.SetTrigger("fadeOut");
            transform.position = player.position;
        }
        */
        if(died==true) restartDelay++;
        if(restartDelay>300) SceneManager.LoadScene("MainScene");
    }

    public void Died()
    {
        died=true;
        animator.SetTrigger("fadeOut");
        transform.position = player.position;
    }
}
