using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	public float walkingSpeed = 3;
	public float runningSpeed = 7;

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
	}

	void Update()
	{
		Vector3 start = rb2D.transform.position;
		Vector3 end = start;
		float speed = walkingSpeed; 
		if(Input.GetKey(KeyCode.W))
		{	
			end = new Vector3(speed * Time.deltaTime, 0, 0);
		}
		else if(Input.GetKey(KeyCode.A))
		{
			end = new Vector3(-speed * Time.deltaTime, 0, 0);
		}
		else if(Input.GetKey(KeyCode.S))
		{
			end = new Vector3(0, -speed * Time.deltaTime, 0);
		}
		else if(Input.GetKey(KeyCode.D))
		{
			end = new Vector3(0, speed * Time.deltaTime, 0);
		}
		Vector3 newPosition = Vector3.MoveTowards(rb2D.position, end, 1 / speed / Time.deltaTime);
		rb2D.MovePosition(newPosition);
	}

}
