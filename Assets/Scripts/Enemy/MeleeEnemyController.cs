using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemyController : MonoBehaviour
{
    public float speed=1.0f;
    //public bool vertical=false;
    //public float changeTime = 2.0f;
    private GameObject player;

    public float playerSpotDistance=1.5f;

    Rigidbody2D rigidbody2D;
    //float timer;
    int direction = 1;
    bool broken = true;
    
    float difX;
    float difY;
    float difXpos, difYpos;

    Animator animator;


    //face direction
    bool faceRight = true;

    


    //attack
    public Transform attackPoint;
    public float attackRange = 0.4f;
    float followRange;
    public LayerMask playerLayer;
    public int Damage=-1; //Value must be negative
    //Attack Cooldown
    private float attackCooldown = 1.0f;
    bool isAttackCooldown;
    float attackCooldownTimer;

    //Attack delay
    float attackDelayTimer;

    // Start is called before the first frame update
    void Start()
    {
        followRange =attackRange;
        rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        player=GameObject.Find("Player");

    }

    void Update()
    {
        
        if (player != null)
        {
            difX=player.transform.position.x-attackPoint.transform.position.x;
            difY=player.transform.position.y-attackPoint.transform.position.y;
        }

        
    }
    
    void FixedUpdate()
    {
        Vector2 position = rigidbody2D.position;
        
        int horizontal=0;
        int vertical=0;

        //only follow player when in range?
        difXpos=difX;
        difYpos=difY;
        if(difXpos<0)
            difXpos=difXpos*-1;
        if(difYpos<0)
            difYpos=difYpos*-1;
        if(difXpos<playerSpotDistance && difYpos<playerSpotDistance)
        {
            if(difX>followRange)
                horizontal=1;
            else if(difX<-followRange)
                horizontal=-1;
            else
                horizontal=0;

            //if(difY>followRange)
            //    vertical=1;
            //else if(difY<-followRange)
            //    vertical=-1;
            //else
            //    vertical=0;
        }

        if(difX<=followRange && difX>=-followRange && difY<=followRange && difY>=-followRange && isAttackCooldown==false)
        {
            Attack();
        }

        if(difX<=followRange && difX>=-followRange && difY<=followRange && difY>=-followRange)
        {
            attackDelayTimer++;
        }
        else
        {
            attackDelayTimer=0f;
        }

        if(horizontal!=0 || vertical!=0)
        {
            animator.SetBool("isMoving",true);
        }
        else
        {
            animator.SetBool("isMoving",false);
        }

        //Vector2 position = rigidbody2d.position;
        position.x = position.x + speed * horizontal * Time.deltaTime;
        position.y = position.y + speed * vertical * Time.deltaTime;

        rigidbody2D.MovePosition(position);

        if(horizontal <0 && !faceRight)
            Flip();
        if(horizontal >0 && faceRight)
            Flip();

        if (isAttackCooldown)
        {
            attackCooldownTimer -= Time.deltaTime;
            if (attackCooldownTimer <= 0)
                isAttackCooldown = false;
        }
        
    }


    void Attack()
    {
        //Attack animation
        animator.SetTrigger("attack");

        if(attackDelayTimer>0.0f)
        {
            //Detection
            Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, playerLayer);

            //Damage
            foreach(Collider2D enemy in hitEnemies)
            {
                enemy.GetComponent<PlayerDamageControl>().PlayFeedback(gameObject);
                enemy.GetComponent<PlayerDamageControl>().ChangeHealth(-1);
            }
            attackDelayTimer=0f;
        }
        isAttackCooldown=true;
        attackCooldownTimer=attackCooldown;
        
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(attackPoint.position,attackRange);
        Gizmos.DrawWireSphere(attackPoint.position,playerSpotDistance);
    }

    void Flip()
    {
        
        Vector3 currentScale = transform.localScale;
        currentScale.x*=-1;
        transform.localScale=currentScale;

        faceRight = !faceRight;
        
    }




}
