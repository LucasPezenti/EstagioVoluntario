using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class StoreroomController : MonoBehaviour
{   
    private int ingredientCount;
    private int maxIngredients = 5;
    private bool canInteract;


    public void Update(){
        if(canInteract){
            if(Input.GetKeyDown(KeyCode.Space)){
                PickUpIngredient();
            }
        }
    }

    private void PickUpIngredient(){
        if(ingredientCount <= maxIngredients){
            GetComponent<IngredientBox>().InstantiateIngredient(transform.position);
            ingredientCount++;
        }
        else{
            return;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.gameObject.CompareTag("Player")){
            canInteract = true;
            collision.gameObject.GetComponent<PlayerController>().interactOn();
        }
    }

    private void OnTriggerExit2D(Collider2D collision){
        if(collision.gameObject.CompareTag("Player")){
            canInteract = false;
            collision.gameObject.GetComponent<PlayerController>().interactOff();
        }
    }

}
