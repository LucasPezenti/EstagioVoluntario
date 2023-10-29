using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PickUp : MonoBehaviour
{

    public Transform holdSpot;
    public LayerMask pickUpMask;
    public Vector3 Direction{ get; set; }
    public PlayerController player;
    private GameObject itemHolding;
    
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)){
            if(itemHolding){
                itemHolding.transform.position = transform.position + Direction * .7f;
                itemHolding.transform.parent = null;
                if(itemHolding.GetComponent<Rigidbody2D>()){
                    itemHolding.GetComponent<Rigidbody2D>().simulated = true;
                }
                itemHolding = null;
                //Debug.Log("Item released");
            }else{
                Collider2D pickUpItem = Physics2D.OverlapCircle(transform.position + Direction*.5f, .3f, pickUpMask);
                if(pickUpItem){
                    itemHolding = pickUpItem.gameObject;
                    itemHolding.transform.position = holdSpot.position;
                    itemHolding.transform.parent = transform;
                    if(itemHolding.GetComponent<Rigidbody2D>()){
                        itemHolding.GetComponent<Rigidbody2D>().simulated = false;
                    }
                    //Debug.Log("Item grabbed");
                }
            }
        }
    }

}
