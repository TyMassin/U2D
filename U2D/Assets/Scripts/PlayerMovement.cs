using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement: MonoBehaviour
{

    public float speed = 5;
    // Start is called before the first frame update

    [SerializeField]
    //Jump vars
    private Rigidbody2D body;

    float moveX;
    public float jumpForce = 10f;
    bool isGrounded; //Are we touching the ground?
    private string GROUND_TAG = "Ground";

    private Animator anim;
    private string WALK_ANIMATION = "Walk";
    private string JUMP_ANIMATION = "Jump";

    private SpriteRenderer spriteRen;


    private void Awake()
    {
       body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spriteRen = GetComponent<SpriteRenderer>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        PlayerJump();
        AnimatePlayer();
    }

    void MovePlayer()
    {
        moveX = Input.GetAxisRaw("Horizontal");
        Vector2 pos = transform.position;
        pos.x += moveX * speed * Time.deltaTime;
        transform.position = pos;


    }

    void PlayerJump()
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            
            body.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            anim.SetTrigger("Takeoff");
            isGrounded = false;
            
        }

        if (isGrounded==true)
        {
            anim.SetBool("Jump", false);
            anim.ResetTrigger("Takeoff");
        }
        else
        {
            anim.SetBool("Jump", true);

        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(GROUND_TAG)) {
            isGrounded = true;
        }

    }

    void AnimatePlayer()
    {
//moving to the right
        if (moveX > 0)
        {
            anim.SetBool(WALK_ANIMATION, true);
            spriteRen.flipX = false;
        }

        else if (moveX<0)
        {
            //we're moving left
            anim.SetBool(WALK_ANIMATION, true);
            spriteRen.flipX = true;

        }

        else
        {
            anim.SetBool(WALK_ANIMATION, false);
        }
    }
  
}
