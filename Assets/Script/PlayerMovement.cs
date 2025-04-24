using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb2d;

    Vector2 moveinput; //work with walk addForce

    //walk
    float move; //�� input
    [SerializeField] float speed;

    //jump
    [SerializeField] float jumpforce;
    [SerializeField] bool isjumping;


    void Start()
    {
       rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        //walk with addforce
        moveinput = new Vector2 (Input.GetAxisRaw("Horizontal"),Input.GetAxisRaw("Vertical"));
        rb2d.AddForce (moveinput*speed);

        
/*
        //walk
        move = Input.GetAxis("Horizontal");
        rb2d.velocity = new Vector2(move * speed , rb2d.velocity.y);
*/

        //jump
        if (Input.GetButtonDown("Jump") && !isjumping)
        {
            rb2d.AddForce(new Vector2(rb2d.velocity.x, jumpforce));
            Debug.Log("jump!");
        }




    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        {
            if (other.gameObject.CompareTag("Ground"))
            {
                isjumping = false;
            }
        }
    }
    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isjumping = true;
        }
    }
}
