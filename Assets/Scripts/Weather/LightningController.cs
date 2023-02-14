using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningController : MonoBehaviour
{
    public GameObject lightningPrefab;
    public Transform playerPosition;

    public float LightningTime = 5.0f;
    public float timer = 0.0f;


    // Update is called once per frame
    void Update()
    {
       timer += Time.deltaTime;
        if(timer >LightningTime)
        {
            //do something
            LightningTime=Random.Range(5.0f,15f);
            timer=0;
            Lightning();
        }
    }

    void Lightning()
    {
        float randomDeviationX=  Random.Range(-6.0f, 6.0f);
        float randomDeviationY=  Random.Range(-0.7f, 0.7f);
        Vector3 offSet = new Vector3(0f+randomDeviationX,2.0f+randomDeviationY,0f);
        GameObject projectileObject = Instantiate(lightningPrefab, playerPosition.transform.position+offSet ,playerPosition.transform.rotation);
    }
}
