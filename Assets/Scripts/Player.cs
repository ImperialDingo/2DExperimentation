using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	public float walkingSpeed = 300;
	public float runningSpeed = 700;

	private SpriteRenderer spriteRenderer;
	private Animator animator;

	private BoxCollider2D boxCollider;
	private Rigidbody2D rb2D;

	// Use this for initialization
	void Start () 
	{
		animator = GetComponent<Animator>();
		boxCollider = GetComponent<BoxCollider2D>();
		rb2D = GetComponent<Rigidbody2D>();
		spriteRenderer = GetComponent<SpriteRenderer>();
	}

	void Update()
	{
		Vector3 start = rb2D.transform.position;
		Vector3 end = start;
		bool run = false;
		float speed = walkingSpeed;

		if(Input.GetKey(KeyCode.LeftShift))
		{
			run = true;
		}

		if(run)
		{
			speed = runningSpeed;
			animator.speed = 1.4f;
		}
		else
		{
			animator.speed = 0.9f;
		}

		float horizontalMove = Input.GetAxisRaw("Horizontal");
		float verticalMove = Input.GetAxisRaw("Vertical");

		if(horizontalMove != 0) verticalMove = 0;

		if(horizontalMove != 0 || verticalMove != 0)
		{
			animator.SetFloat("HorizontalVelocity", Mathf.Abs(horizontalMove) * speed);
			animator.SetFloat("VerticalVelocity", verticalMove * speed);

			if(verticalMove == 0)
			{
				if(horizontalMove < 0)
				{
					spriteRenderer.flipX = true;
				}
				else
				{
					spriteRenderer.flipX = false;
				}
			}

		}
		else
		{
			animator.SetFloat("HorizontalVelocity", 0);
			animator.SetFloat("VerticalVelocity", 0);
		}

		rb2D.velocity = new Vector2(horizontalMove * speed * Time.deltaTime, verticalMove * speed * Time.deltaTime);

		

		// if(Input.GetKey(KeyCode.W))
		// {	
		// 	end = new Vector3(speed * Time.deltaTime, 0, 0);
		// }
		// else if(Input.GetKey(KeyCode.A))
		// {
		// 	end = new Vector3(-speed * Time.deltaTime, 0, 0);
		// }
		// else if(Input.GetKey(KeyCode.S))
		// {
		// 	end = new Vector3(0, -speed * Time.deltaTime, 0);
		// }
		// else if(Input.GetKey(KeyCode.D))
		// {
		// 	end = new Vector3(0, speed * Time.deltaTime, 0);
		// }
		// Vector3 newPosition = Vector3.MoveTowards(rb2D.position, end, 1 / speed / Time.deltaTime);
		// rb2D.MovePosition(newPosition);
	}

}
