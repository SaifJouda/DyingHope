using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMelee : MonoBehaviour
{
    //Animator
    public Animator animator;
    
    //Attack Point
    public Transform attackPoint;
    
    //Meelee Range
    private float attackRange = 0.4f;
    private int attackDamage = -1;
    public LayerMask enemyLayers;
    //Value must be negative
    public int Damage=-1;

    public GameObject projectileGameObject;

    //Ranged
    float difX;
    float difY;
    Vector2 direction;

    //Attack Cooldown
    private float attackCooldown = 0.5f;
    bool isAttackCooldown;
    float attackCooldownTimer;

    //Camera
    public Camera mainCam;
    private Vector3 mousePos;

    //Melee Powerup
    private int damagePlus=0;

    float attackDelay=0;
    private int attackCount=0;
    


    // Update is called once per frame
    void FixedUpdate()
    {
        if (isAttackCooldown)
        {
            attackCooldownTimer -= Time.deltaTime;
            if (attackCooldownTimer <= 0)
                isAttackCooldown = false;
        }



    }

    void Update()
    {
        if(Input.GetKey(KeyCode.Space) && isAttackCooldown==false)
        {
            Attack();
        }

        //if(Input.GetKeyDown(KeyCode.C) && isAttackCooldown==false)
        //{
            //RangedAttack();
        //}

        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);

        difX=mousePos.x-attackPoint.transform.position.x;
        difY=mousePos.y-attackPoint.transform.position.y;
        direction = new Vector2(difX,difY);
        attackPoint.transform.up=direction;
    }

    // Assisted by Tutorial: https://www.youtube.com/watch?v=sPiVz1k-fEs
    void Attack()
    {
        //Attack animation
        animator.SetInteger("attackCounter",attackCount);
        animator.SetTrigger("attack");
        
        if(attackCount>=4) attackCount=0;
        else attackCount++;
        
        //Detection
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        //Damage
        foreach(Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<EnemyDamageControl>().ChangeHealth(attackDamage+damagePlus);
            enemy.GetComponent<EnemyDamageControl>().PlayFeedback(gameObject);
        }
        isAttackCooldown=true;
        attackCooldownTimer=attackCooldown;
    }

    void RangedAttack()
    {
        //Attack animation
        animator.SetTrigger("attack");

        //GameObject projectileObject = Instantiate(projectileGameObject, attackPoint.transform.position,attackPoint.transform.rotation);

        Vector2 launchDirection = attackPoint.transform.up; //= new Vector2(attackPoint.transform.position.x,attackPoint.transform.position.y);
        //Vector2 launchDirection = new Vector2(1,0);

        //projectileObject.GetComponent<projectile>().Launch(launchDirection);

        isAttackCooldown=true;
        attackCooldownTimer=attackCooldown;
    }

    public void changeWpnStats(int damage, float range, float cool)
    {
        attackDamage=damage;
        attackRange=range;
        attackCooldown = cool;
    }

    public void weaponBuffDamage()
    {
        damagePlus-=1;
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(attackPoint.position,attackRange);
    }
}
