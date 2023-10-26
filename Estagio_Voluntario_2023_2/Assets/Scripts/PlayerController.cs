using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private string curState;
    public float moveSpd;
    public Rigidbody2D rb;
    public Animator anim;
    private Vector2 moveDirection;
    private Vector2 lastMoveDirection;

    private bool moved = false;
    private float moveX = 0;
    private float moveY = 0;

    
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        ProcessInputs();
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

    }

    private void Move(){
        
        rb.velocity = new Vector2(moveDirection.x * moveSpd, moveDirection.y * moveSpd);
        moved = false;
        moveSpd = 3.4f;
        
    }

    public void Animate(){
        anim.SetFloat("AnimMoveX", moveDirection.x);
        anim.SetFloat("AnimMoveY", moveDirection.y);
        anim.SetFloat("AnimMoveMagnitude", moveDirection.magnitude);
        anim.SetFloat("AnimLastMoveX", lastMoveDirection.x);
        anim.SetFloat("AnimLastMoveY", lastMoveDirection.y);
    }
    
}
