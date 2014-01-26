using UnityEngine;
using System.Collections;

public class playerController : MonoBehaviour
{

	public float maxSpeed = 10f;

	bool facingRight = true;

	bool grounded = false;
	public Transform groundCheck;
	float groundRadius = 0.3f;
	public LayerMask whatIsGround;
	
	private Animator animator;

	public float jumpForce = 500.0f;
	
	// Use this for initialization
	void Start()
	{
		animator = this.GetComponent<Animator>();
	}
	
	// FixedUpdate is called once per physics step
	void FixedUpdate()
	{

		grounded = Physics2D.OverlapCircle (groundCheck.position, groundRadius, whatIsGround);

		float move = Input.GetAxis("Horizontal");

		animator.SetFloat ("Speed", Mathf.Abs (move));

		rigidbody2D.velocity = new Vector2 (move * maxSpeed, rigidbody2D.velocity.y);

		if ((move > 0 && !facingRight) || (move < 0 && facingRight))
		{
			Flip();
		}

//		if (move > 0)
//		{
//			animator.SetInteger("Direction", 1);
//		}
//		else if (move < 0)
//		{
//			animator.SetInteger("Direction", -1);
//		}
//		else
//		{
//			animator.SetInteger("Direction", 0);
//		}
	}

	void Update()
	{
		if (grounded && Input.GetKeyDown(KeyCode.Space)) //fixthis
		{
			rigidbody2D.AddForce(new Vector2(0, jumpForce));
		}
	}

	void Flip() 
	{
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}