using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class pickUpItem : MonoBehaviour
{
    public enum itemType {coffee,chest,chicken};   
    private GameObject player;
    public itemType typeOfItem;
    public TextMeshPro HPPrefab;

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
            TextMeshPro recoveryText = Instantiate(HPPrefab, gameObject.transform.position + new Vector3(0, 0.5f, -1), Quaternion.identity);
            Destroy(recoveryText, 1.5f);
            Destroy(gameObject);
        }

        if(typeOfItem==itemType.chest)
        {
            GetComponent<Chest>().Open();
        }

        if (typeOfItem == itemType.chicken)
        {
            player.GetComponent<PlayerDamageControl>().IncreaseHealth(1);
            TextMeshPro increaseText = Instantiate(HPPrefab, gameObject.transform.position + new Vector3(0, 0.5f, -1), Quaternion.identity);
            Destroy(increaseText, 1.5f);
            Destroy(gameObject);
        }

        

    }
}
