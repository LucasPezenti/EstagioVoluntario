using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InteractionController : MonoBehaviour
{
    public bool inRange;
    public KeyCode interactKey;
    public UnityEvent interactAction;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(interactKey)){
            interactAction.Invoke();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.gameObject.CompareTag("Player")){
            inRange = true;
            collision.gameObject.GetComponent<PlayerController>().interactOn();
        }
    }

    private void OnTriggerExit2D(Collider2D collision){
        if(collision.gameObject.CompareTag("Player")){
            inRange = false;
            collision.gameObject.GetComponent<PlayerController>().interactOff();
        }
    }
}
