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

    public float jumpForce = 10f;
    bool isGrounded; //Are we touching the ground?
    private string GROUND_TAG = "Ground";

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        PlayerJump();
    }

    void MovePlayer()
    {
        float moveX = Input.GetAxis("Horizontal");
        Vector2 pos = transform.position;
        pos.x += moveX * speed * Time.deltaTime;
        transform.position = pos;


    }

    void PlayerJump()
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            body.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            isGrounded = false;
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(GROUND_TAG)) {
            isGrounded = true;
        }

    }
  

}
