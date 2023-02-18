using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    public GameObject coffeePrefab;
    //animator
    Animator animator;
    // Start is called before the first frame update
    bool opened = false;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void Open()
    {
        
        if(!opened)
        {
            animator.SetTrigger("open");
            waiter();
            GameObject coffeSpawned = Instantiate(coffeePrefab, transform.position + new Vector3(0,0.3f,0) ,transform.rotation);
            coffeSpawned.GetComponent<Rigidbody2D>().velocity=new Vector2(Random.Range(-1.0f, 1.0f),Random.Range(2.0f, 3.0f));
            opened = true;
        }
        
    
    }

    IEnumerator waiter()
    {
        yield return new WaitForSeconds(0.5f);
    }
}
