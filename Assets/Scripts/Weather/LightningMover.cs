using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningMover : MonoBehaviour
{
    public GameObject player;
    public Vector2 Speed=new Vector2(0.5f,0.1f);
    public GameObject lightningPrefab;
    public GameObject light;

    Rigidbody2D rigidbody2d;

    public float bruhx;
    public float bruhy;

    private Vector2 initialPos;

    void Start()
    {
        player=GameObject.Find("Player");
        transform.position=lightningPrefab.transform.position;
        rigidbody2d = GetComponent<Rigidbody2D>();
        //initialPos = new Vector2(transform.position.x,transform.position.y);
        //bruhx=lightningPrefab.transform.position.x;
        //bruhy=lightningPrefab.transform.position.y;

    }

    // Update is called once per frame
    void Update()
    {
        //var position = player.position;
        //transform.position = new Vector3(initialPos.x + position.x * Speed.x,initialPos.y+ position.y * Speed.y, position.z);
        rigidbody2d.velocity=new Vector2(player.GetComponent<Rigidbody2D>().velocity.x * Speed.x, player.GetComponent<Rigidbody2D>().velocity.y* Speed.y);  
        light.transform.position=transform.position;
    }
}
