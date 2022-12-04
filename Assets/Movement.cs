using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float movement;
    [SerializeField] Rigidbody2D rigid;
    [SerializeField] int speed;
    [SerializeField] bool isFacingRight = true;
    [SerializeField] bool jumpPressed = false;
    [SerializeField] float jumpForce = 500.0f;
    [SerializeField] bool isGrounded = true;
    [SerializeField] bool shiftPressed = false;
    public Dart DartPrefab;
    public Transform LaunchOffset;

    [SerializeField] Animator animator;
    const int IDLE = 0;
    const int RUN = 1;
    const int JUMP = 2;

    // Start is called before the first frame update
    void Start()
    {
        if (rigid == null)
            rigid = GetComponent<Rigidbody2D>();
        speed = 15;
        
        if (animator == null)
            animator = GetComponent<Animator>();
        animator.SetInteger("state", IDLE);
    }

    // Update is called once per frame
    void Update()
    {
        movement = Input.GetAxis("Horizontal");
        if (Input.GetButtonDown("Jump"))
            jumpPressed = true;
        
        if (Input.GetButtonDown("Fire1"))
        {
            Vector3 xyz = new Vector3(0, 0, 0);
            Quaternion newRotation = Quaternion.Euler(xyz);
            Instantiate(DartPrefab,LaunchOffset.position, newRotation);
        }
    }

    //called potentially multiple times per frame
    //used for physics & movement
    void FixedUpdate()
	{
		rigid.velocity = new Vector2(movement * speed, rigid.velocity.y);
        if (!jumpPressed && isGrounded)
        {
            if (movement > 0 || movement < 0)
                animator.SetInteger("state", RUN);
            else
                animator.SetInteger("state", IDLE);
        }
		if ((movement < 0 && isFacingRight) || (movement > 0 && !isFacingRight))
			Flip();
		if (jumpPressed && isGrounded)
			Jump();
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

        animator.SetInteger("state", JUMP);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
            animator.SetInteger("state", IDLE);
        }
    }
}
