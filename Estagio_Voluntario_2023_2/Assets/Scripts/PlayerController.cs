using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Animator animator;
    private string curState;
//    AnimController animController;
//    [SerializeField] GameObject animCtrl;
    public float moveSpd;
    public Rigidbody2D rb;
    private Vector2 moveDirection;

    private bool moved = false;
    private bool running = false;
    private float moveX = 0;
    private float moveY = 0;
    private int right_dir = 0, left_dir = 1, up_dir = 3, down_dir = 4;
    private int dir = 4, last_dir = 4;

    // Player animations
    const string PLAYER_IDLE_D = "Player_Idle_D";
    const string PLAYER_IDLE_U = "Player_Idle_U";
    const string PLAYER_IDLE_R = "Player_Idle_R";
    const string PLAYER_IDLE_L = "Player_Idle_L";

    const string PLAYER_RUN_R = "Player_Run_R";
    const string PLAYER_RUN_L = "Player_Run_L";
    const string PLAYER_RUN_D = "Player_Run_D";
    const string PLAYER_RUN_U = "Player_Run_U";

    const string PLAYER_WALK_R = "Player_Walk_R";
    const string PLAYER_WALK_L = "Player_Walk_L";
    const string PLAYER_WALK_D = "Player_Walk_D";
    const string PLAYER_WALK_U = "Player_Walk_U";

    /*
    void Awake(){
        animController = animCtrl.GetComponent<AnimController>();
    }
    */
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessInputs();
        PlayerAnimation();
    }

    // Physics Calculation
    void FixedUpdate(){
        Move();
    }
    
    private void ProcessInputs(){
        moveX = Input.GetAxisRaw("Horizontal");
        moveY = Input.GetAxisRaw("Vertical");

        running = false;
        if(Input.GetKey("left shift")){
            running = true;
        }

        moveDirection = new Vector2(moveX, moveY).normalized;

    }

    private void Move(){
        rb.velocity = new Vector2(moveDirection.x * moveSpd, moveDirection.y * moveSpd);

        moved = false;
        if(running){
            moveSpd = 3.5f;
        }
        else{
            moveSpd = 2.4f;
        }

        // Movement direction
        if(moveX > 0){
            moved = true;
            dir = right_dir;
            last_dir = right_dir;
        }
        else if(moveX < 0){
            moved = true;
            dir = left_dir;
            last_dir = left_dir;
        }
        if(moveY > 0){
            moved = true;
            dir = up_dir;
            last_dir = up_dir;
        }
        else if(moveY < 0){
            moved = true;
            dir = down_dir;
            last_dir = down_dir;
        }
        
        
    }

    private void PlayerAnimation(){

        // Idle animation
        if(!moved){
            if(last_dir == down_dir){
                ChangeAnimationState(PLAYER_IDLE_D);
            }
            else if(last_dir == up_dir){
                ChangeAnimationState(PLAYER_IDLE_U);
            }
            else if(last_dir == right_dir){
                ChangeAnimationState(PLAYER_IDLE_R);
            }
            else if(last_dir == left_dir){
                ChangeAnimationState(PLAYER_IDLE_L);
            }
        }

        // Walking animation
        else if(moved){
            if(dir == down_dir){
                ChangeAnimationState(PLAYER_WALK_D);
            }
            else if(dir == up_dir){
                ChangeAnimationState(PLAYER_WALK_U);
            }
            else if(dir == right_dir){
                ChangeAnimationState(PLAYER_WALK_R);
            }
            else if(dir == left_dir){
                ChangeAnimationState(PLAYER_WALK_L);
            }
        }

        // Running animation
        else if(moved && running){
            if(dir == down_dir){
                ChangeAnimationState(PLAYER_RUN_D);
            }
            else if(dir == up_dir){
                ChangeAnimationState(PLAYER_RUN_U);
            }
            else if(dir == right_dir){
                ChangeAnimationState(PLAYER_RUN_R);
            }
            else if(dir == left_dir){
                ChangeAnimationState(PLAYER_RUN_L);
            }
        }
    }
    
    public void ChangeAnimationState(string newState){

        // Stop an animaiton from interrupting itself
        if(curState == newState){
            return;
        }

        animator.Play(newState);
        curState = newState;

    }
    
}
