using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainController : MonoBehaviour
{
    //General Stats
    public float speed = 1.0f;
    public float jumpVelocity = 3f;

    //Position
    public float currentPositionX;
    public float currentPositionY;

    //rigid body
    Rigidbody2D rigidbody2d;

    //direction
    float horizontal; 
    float vertical;
    Vector2 lookDirection = new Vector2(1,0);
    
    //face direction
    bool faceRight = true;

    //animator
    Animator animator;

    //Roll Cooldown
    private float rollCooldown = 1.0f;
    bool isRollCooldown;
    float rollCooldownTimer;

    public Transform jumpPoint;
    public LayerMask groundLayer;
    

    
    
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rigidbody2d = GetComponent<Rigidbody2D>();

        //currentHealth = maxHealth;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.LeftShift) && isRollCooldown==false)
        {
            Roll();
        }
        if(Input.GetKeyDown(KeyCode.W))//&& isRollCooldown==false)
        {
            Collider2D[] grounds = Physics2D.OverlapCircleAll(jumpPoint.position, 0.1f, groundLayer);

            foreach(Collider2D ground in grounds)
            {
                Jump();
            }
            //if(grounds.shapeCount >0) Jump();
        }
    }


    void FixedUpdate()
    {

        
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        Vector2 move = new Vector2(horizontal, vertical);
        
        if (rollCooldownTimer>0)
            rollCooldownTimer=rollCooldownTimer;
        else if(move.x!=0)
            animator.SetBool("isMoving",true);
        else
            animator.SetBool("isMoving",false);

        currentPositionX = transform.position.x;
        currentPositionY = transform.position.y;

        if (isRollCooldown)
        {
            rollCooldownTimer -= Time.deltaTime;
            if (rollCooldownTimer <= 0)
                isRollCooldown = false;
        }
        
        if(horizontal <0 && !faceRight)
            Flip();
        if(horizontal >0 && faceRight)
            Flip();

        rigidbody2d.velocity=new Vector2(speed*horizontal, rigidbody2d.velocity.y);

        
    }

    void Jump()
    {
        rigidbody2d.velocity = Vector2.up*jumpVelocity;//rigidbody2d.velocity = Vector2.up * jumpVelocity;
        animator.SetTrigger("jump");
    }

    void Roll()
    {
        animator.SetTrigger("roll");

        isRollCooldown=true;
        rollCooldownTimer=rollCooldown;
    }

    void Flip()
    {
        
        Vector3 currentScale = transform.localScale;
        currentScale.x*=-1;
        transform.localScale=currentScale;

        faceRight = !faceRight;
        
    }

  


}
