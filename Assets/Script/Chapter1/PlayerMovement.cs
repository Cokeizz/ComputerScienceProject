
using UnityEngine;
using XboxCtrlrInput;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D body;
    private Animator anim;
    private Transform bodyfix;
    private bool Grounded;
    private float horizontalInput;
    private float verticalInput;

    [SerializeField]private float speed = 1.5f;
    [SerializeField]private float jump_range = 3.75f;


    private void Awake() {

        // Grab reference from object (Rigidbody and Anomator)
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        bodyfix = GetComponent<Transform>();
       
        
   

    }

    private void Update() {
      
    
        transform.localRotation = Quaternion.Euler(0, 0, 0);

        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        body.velocity = new Vector2(horizontalInput * speed,body.velocity.y);
        
        //Flip Player
        if(horizontalInput > 0.01f)
            transform.localScale = new Vector3(2,2,2);
        if(horizontalInput < -0.01f)
            transform.localScale = new Vector3(-2,2,2);
            
      //Jump
        if((Input.GetKey(KeyCode.Space) && Grounded==true) || (XCI.GetButton(XboxButton.Y) && Grounded==true))
            Jump();
       
        //Set animator parameter
        anim.SetBool("Run", horizontalInput != 0);
        anim.SetBool("Grounded",Grounded);

    }

    private void Jump()
    {
        body.velocity = new Vector2(body.velocity.x,jump_range);
        anim.SetTrigger("Jump");
        Grounded = false; 
      
    }
    private void OnCollisionEnter2D(Collision2D collision) 
    {
        if(collision.gameObject.tag == "Ground")
           Grounded = true;
}}
