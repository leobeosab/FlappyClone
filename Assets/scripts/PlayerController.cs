using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour 
{
	public float jumpSpeed = 1f;
	public float velocity = 1f;
	private bool canJump = true;
	int score = 0;
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
		rb = GetComponent<Rigidbody2D>(); //grab the rididbody
	}

	void Update () 
	{
		if (Input.GetMouseButton(0) && canJump) //make sure you don't just fly off when you hold mouse 1 or hold your phone
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
		gameOver();
	}
	void OnTriggerEnter2D(Collider2D other) //triggers are placed between the TubePrefabs to add the points
	{
		Score += 1;
	}
	void gameOver()
	{

	}
}
