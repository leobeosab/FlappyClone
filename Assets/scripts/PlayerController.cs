using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour 
{
	public float jumpSpeed = 1f;
	public float velocity = 1f;
	private bool canJump = true;
	int score = 4;
	public int Score
	{
		get
		{
			return score;
		}
		set
		{
			score = value;
		}
	}

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
	void OnCollisionEnter2D(Collision2D other)
	{
		//do a gameover
		Debug.Log ("wat");
		gameOver();
	}
	void OnTriggerEnter2D(Collider2D other)
	{
		Score += 1;
	}
	void gameOver()
	{

	}
}
