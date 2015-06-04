using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour 
{
	public float jumpSpeed = 1f;
	public float velocity = 1f;
	public AudioClip jumpSound;
	public AudioClip pointAddedSound;
	public AudioClip gameOverSound;

	private bool gameOver;
	private bool started;
	private bool canJump = true;
	private AudioSource source;

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
	TerrainController terrainController;

	void Start () 
	{
		source = GetComponent<AudioSource> ();
		terrainController = GameObject.Find ("Background").GetComponent<TerrainController> ();
		rb = GetComponent<Rigidbody2D>(); //grab the rididbody
		rb.gravityScale = 0;
	}

	void Update () 
	{
		if (!started && Input.GetMouseButton (0)) 
		{
			started = true;
			rb.gravityScale = 6;
			GameObject.Find("Canvas").GetComponent<MenuController>().MoveInstructions();
			terrainController.TurnOnOrOff(true);
		}
		if (!gameOver && started) 
		{
			if (Input.GetMouseButton (0) && canJump) //make sure you don't just fly off when you hold mouse 1 or hold your phone
				jump ();
			else
				rb.velocity = new Vector2 (velocity, rb.velocity.y);
			if (!Input.GetMouseButton (0))
				canJump = true;
		}
	}
	void jump()
	{
		source.PlayOneShot (jumpSound, .75f);
		rb.velocity = new Vector2(velocity, jumpSpeed);
		canJump = false;
	}
	void OnCollisionEnter2D(Collision2D other)
	{
		if (!gameOver)
		GameOver();
	}
	void OnTriggerEnter2D(Collider2D other) //triggers are placed between the TubePrefabs to add the points
	{
		Score += 1;
		source.PlayOneShot (pointAddedSound, .75f);
	}
	void GameOver()
	{
		GameObject.Find("Canvas").GetComponent<MenuController>().GameOver();
		source.PlayOneShot (gameOverSound, .75f);
		terrainController.TurnOnOrOff(false);
		gameOver = true;
	}
}
