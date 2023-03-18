using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickUpItem : MonoBehaviour
{
    public enum itemType {coffee,chest};   
    private GameObject player;
    public itemType typeOfItem;

    void Start() 
    {
        player=GameObject.Find("Player");    
    }

    public void pickUp()
    {
        //Destroy(gameObject);
        handlePickUp();
    }

    private void handlePickUp()
    {
        if(typeOfItem==itemType.coffee)
        {
            player.GetComponent<PlayerDamageControl>().ChangeHealth(1);
            Destroy(gameObject);
        }

        if(typeOfItem==itemType.chest)
        {
            GetComponent<Chest>().Open();
        }

        

    }
}
