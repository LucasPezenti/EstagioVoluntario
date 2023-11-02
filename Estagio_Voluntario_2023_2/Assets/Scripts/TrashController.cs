using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashController : MonoBehaviour
{  
    [SerializeField] Transform discardSpot;
    private GameObject orderObj;
    private GameObject playerHolding;
    private bool canInteract;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(canInteract){
            if(Input.GetKeyDown(KeyCode.E)){
                discardOrder();
            }
        }
    }

    public void discardOrder(){
        if(playerHolding != null && orderObj == null){
            orderObj = playerHolding;
            //CompareOrder(orderObj.GetComponent<Ingredients>().GetIngredientIndex());
            orderObj.transform.position = discardSpot.position;
            orderObj.transform.parent = transform;
            if(orderObj.GetComponent<Rigidbody2D>()){
                orderObj.GetComponent<Rigidbody2D>().simulated = true;   
            }
            Destroy(orderObj);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.gameObject.CompareTag("Player")){
            canInteract = true;
            collision.gameObject.GetComponent<PlayerController>().interactOn();
            playerHolding = collision.gameObject.GetComponent<PlayerController>().itemHolding;
            
        }
    }

    private void OnTriggerExit2D(Collider2D collision){
        if(collision.gameObject.CompareTag("Player")){
            canInteract = false;
            collision.gameObject.GetComponent<PlayerController>().interactOff();
        }
    }
}
