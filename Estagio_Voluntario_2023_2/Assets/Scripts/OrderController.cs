using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderController : MonoBehaviour
{
    private bool canInteract;
    public List<Ingredients> order = new List<Ingredients>();

    [SerializeField] Transform orderTransf;
    [SerializeField] Transform serveSpot;

    
    public void Update(){
        if(canInteract){
            if(Input.GetKeyDown(KeyCode.Space)){

            }
        }
    }
    
    public void serveOrder(){
        
    }

    public Transform GetServeSpot(){
        return serveSpot;
    }
    Ingredients getOrder(){
        int randomNum = Random.Range(1,6);
        Ingredients curOrder = order[randomNum];

        return curOrder;
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
