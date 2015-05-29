using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour 
{
	public float jumpSpeed = 1f;
	public float velocity = 1f;
	private bool canJump = true;
	Rigidbody2D rb;
	void Start () 
	{
		rb = GetComponent<Rigidbody2D>();
	}

	void Update () 
	{
		if (Input.GetMouseButton(0) && canJump)
			jump();
		else
			rb.velocity = new Vector2(velocity, rb.velocity.y);
		if (!Input.GetMouseButton(0))
		{
			canJump = true;
		}
	}
	void jump()
	{
		rb.velocity = new Vector2(velocity, jumpSpeed);
		canJump = false;
	}
	void OnCollisionEnter(Collision other)
	{
		//do a gameover
	}
}
