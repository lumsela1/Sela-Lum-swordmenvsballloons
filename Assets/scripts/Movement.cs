using System.Collections;
using System.Collections.Generic;
using UnityEngine;
///note
public class Movement : MonoBehaviour
{
    [SerializeField] float movement;
    [SerializeField] Rigidbody2D rigid;
    [SerializeField] int speed;
    public bool isFacingRight = true;
    [SerializeField] bool jumpPressed = false;
    [SerializeField] float jumpForce = 250.0f;
    [SerializeField] bool isGrounded = true;
    public Animator aniamator; 
    public Transform position;
    public GameObject projectile;
   // [SerializeField] bool shiftPressed = false;

    // Start is called before the first frame update
    void Start()
    {
        if (rigid == null)
            rigid = GetComponent<Rigidbody2D>();
        speed = 8;
    }

    // Update is called once per frame
    void Update()
    {
        movement = Input.GetAxis("Horizontal");
        aniamator.SetFloat("speed", Mathf.Abs(movement));
        
 aniamator.SetBool("attacking", false);
        if (Input.GetButtonDown("Jump"))
            jumpPressed = true;

             if(Input.GetKeyDown("left ctrl")){
           aniamator.SetBool("attacking", true);
Instantiate(projectile, position.position, Quaternion.identity);

        }
        
    }

    //called potentially multiple times per frame
    //used for physics & movement
    void FixedUpdate()
    { 
        rigid.velocity = new Vector2(movement * speed, rigid.velocity.y);
        if (movement < 0 && isFacingRight || movement > 0 && !isFacingRight)
            Flip();
        if (jumpPressed && isGrounded){
        aniamator.SetBool("jumping", true);     
 aniamator.SetBool("attacking", false);
            Jump();

        }
    }

    void Flip()
    {
        transform.Rotate(0, 180, 0);
        isFacingRight = !isFacingRight;
    }

    void Jump()
    {
        rigid.velocity = new Vector2(rigid.velocity.x, 0);
        rigid.AddForce(new Vector2(0, jumpForce));
        isGrounded = false;
        jumpPressed = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
               aniamator.SetBool("jumping", false);
        }
    }

}
