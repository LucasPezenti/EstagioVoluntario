using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Player Settings")]
    public Rigidbody2D rb;
    public Animator anim;
    public GameObject interactionAlert;
    public Transform holdSpot;
    public LayerMask pickUpMask;
    public Vector3 pickDirection{ get; set; }
    public GameObject itemHolding;

    [Header("Game Settings")]
    [SerializeField] GameObject gameOverScreen;
    [SerializeField] GameObject winScreen;

    private Score score;
    private Timer timer;

    private float moveSpd;
    private Vector2 moveDirection;
    private Vector2 lastMoveDirection;

    private bool canMove = true;
    private float moveX = 0;
    private float moveY = 0;

    
    void Start()
    {
        timer = GameObject.FindObjectOfType<Timer>();
        score = GameObject.FindObjectOfType<Score>();
        pickDirection = new Vector2(0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        Game();
        if(canMove){
            ProcessInputs();
        }
        Animate();
    }

    // Physics Calculation
    void FixedUpdate(){
        Move();
    }
    
    private void ProcessInputs(){
        moveX = Input.GetAxisRaw("Horizontal");
        moveY = Input.GetAxisRaw("Vertical");

        if((moveX == 0 && moveY == 0) && moveDirection.x != 0 || moveDirection.y != 0){
            lastMoveDirection = moveDirection;
        }

        moveDirection = new Vector2(moveX, moveY).normalized;

        // Pick up direction
        if(moveDirection.sqrMagnitude > .1f){
            pickDirection = moveDirection.normalized;
        }


        if(itemHolding == null && Input.GetKeyDown(KeyCode.E)){
            PickUp();
        }
        else if(itemHolding != null && Input.GetKeyDown(KeyCode.E)){
            Release();
        }

    }

    private void Move(){
        
        rb.velocity = new Vector2(moveDirection.x * moveSpd, moveDirection.y * moveSpd);
        //moved = false;
        moveSpd = 3.4f;
        
    }

    private void PickUp(){
        Collider2D pickUpItem = Physics2D.OverlapCircle(transform.position + pickDirection*.5f, .3f, pickUpMask);
        if(pickUpItem){
            itemHolding = pickUpItem.gameObject;
            itemHolding.transform.position = holdSpot.position;
            itemHolding.transform.parent = transform;
            if(itemHolding.GetComponent<Rigidbody2D>()){
                itemHolding.GetComponent<Rigidbody2D>().simulated = false;                
            //Debug.Log("Item grabbed");
            }
        }
    }

    private void Release(){
        itemHolding.transform.position = transform.position + pickDirection * .7f;
        itemHolding.transform.parent = null;
        if(itemHolding.GetComponent<Rigidbody2D>()){
            itemHolding.GetComponent<Rigidbody2D>().simulated = true;
        }
        itemHolding = null;
        //Debug.Log("Item released");
    }

    // Set interaction alert on
    public void interactOn(){
        interactionAlert.SetActive(true);
    }

    // Set interaction alert off
    public void interactOff(){
        interactionAlert.SetActive(false);
    }

    public void Game(){
        if(score.GetWin()){
            canMove = false;
            moveDirection.x = 0;
            moveDirection.y = 0;
            timer.setTimerActiveOff();
            winScreen.SetActive(true);
            //Debug.Log("Ganhou");
        }else if(timer.GetGameOver()){
            canMove = false;
            moveDirection.x = 0;
            moveDirection.y = 0;
            gameOverScreen.SetActive(true);
            //Debug.Log("Fim de jogo");
        }
    }

    public void Animate(){
        anim.SetFloat("AnimMoveX", moveDirection.x);
        anim.SetFloat("AnimMoveY", moveDirection.y);
        anim.SetFloat("AnimMoveMagnitude", moveDirection.magnitude);
        anim.SetFloat("AnimLastMoveX", lastMoveDirection.x);
        anim.SetFloat("AnimLastMoveY", lastMoveDirection.y);
    }
    
}
