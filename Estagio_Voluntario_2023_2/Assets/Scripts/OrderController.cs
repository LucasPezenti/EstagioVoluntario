using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;

public class OrderController : MonoBehaviour
{
    public Ingredients curOrder;
    public List<Ingredients> order = new List<Ingredients>();
    public GameObject orderObj;
    [SerializeField] Transform serveSpot;
    private GameObject playerHolding;
   private bool canInteract;


    public void Update(){
        if(canInteract){
            if(Input.GetKeyDown(KeyCode.E)){
                serveOrder();
            }
        }
    }
    
    public void serveOrder(){
        if(playerHolding != null && orderObj == null){
            orderObj = playerHolding;
            orderObj.transform.position = serveSpot.position;
            orderObj.transform.parent = transform;
            if(orderObj.GetComponent<Rigidbody2D>()){
                orderObj.GetComponent<Rigidbody2D>().simulated = true;   
            }
            Destroy(orderObj);
        }
    }

    public Transform GetServeSpot(){
        return serveSpot;
    }
    Ingredients getOrder(){
        int randomNum = Random.Range(1,6);
        curOrder = order[0];

        return curOrder;
    }

    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.gameObject.CompareTag("Player")){
            canInteract = true;
            collision.gameObject.GetComponent<PlayerController>().interactOn();
            playerHolding = collision.gameObject.GetComponent<PickUp>().itemHolding;
            
        }
    }

    private void OnTriggerExit2D(Collider2D collision){
        if(collision.gameObject.CompareTag("Player")){
            canInteract = false;
            collision.gameObject.GetComponent<PlayerController>().interactOff();
        }
    }

}
