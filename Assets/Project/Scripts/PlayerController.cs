using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
public static PlayerController instance;

[SerializeField] private float moveSpeed;
[SerializeField] private float jumpForce;

public KeyCode left;
public KeyCode right;
public KeyCode jump;

private Rigidbody2D rb2d;
private SpriteRenderer spriteRenderer;
//private Animator anim;
public Animator MyAnim { get; set; }
public bool MyCanMove{ get; set; }

private float fallMultiplier = 4f;
private float lowJumpMulitplier = 2f;

public Transform groundCheckPoint;
public float groundCheckRadius;
public LayerMask whatIsGround;
private bool isGround;


    // Start is called before the first frame update
    void Start()
    {
    instance = this;
        rb2d = GetComponent<Rigidbody2D>();

        spriteRenderer = GetComponent<SpriteRenderer>();
        MyAnim = GetComponent<Animator>();
        MyCanMove = true;
    }

    // Update is called once per frame
    void Update()
    {
    if (MyCanMove == false){
    return;

    }

        isGround = Physics2D.OverlapCircle(groundCheckPoint.position, groundCheckRadius, whatIsGround);

        MovePlayer();
        HandleAnimation();
    }


    private void HandleAnimation(){

    MyAnim.SetFloat("Speed", Mathf.Abs(rb2d.velocity.x));

    MyAnim.SetBool("Grounded", isGround);
    }



    private void MovePlayer()
   {

    if (Input.GetKey(left)){
      rb2d.velocity = new Vector2(-moveSpeed, rb2d.velocity.y);
      spriteRenderer.flipX = true;
      }

    else if (Input.GetKey(right)){
      rb2d.velocity = new Vector2(moveSpeed, rb2d.velocity.y);
      spriteRenderer.flipX = false;
      }

    else{ if (rb2d.velocity.y != 0)
    {
      rb2d.velocity = new Vector2(rb2d.velocity.x, rb2d.velocity.y);
    }else
    {
      rb2d.velocity = new Vector2(0, rb2d.velocity.y);
      }

      if (Input.GetKeyDown(jump)){
            rb2d.velocity = new Vector2(rb2d.velocity.x, jumpForce);
      }
}

if (Input.GetKeyDown(jump))
{
rb2d.velocity = new Vector2(rb2d.velocity.x, jumpForce);
}

BetterJump();

}

private void BetterJump(){
if (rb2d.velocity.y > 0){
    rb2d.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
}
 else if (rb2d.velocity.y > 0 && !Input.GetKey(jump)){
      rb2d.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMulitplier - 1) * Time.deltaTime;
 }

}

}