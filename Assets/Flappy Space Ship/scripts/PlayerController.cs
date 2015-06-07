using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerController : MonoBehaviour 
{
	public float jumpSpeed = 1f;
	public float velocity = 1f;
	public AudioClip jumpSound;
	public AudioClip pointAddedSound;
	public AudioClip gameOverSound;
	public List<Sprite> sprites;

	private bool gameOver;
	private bool started;
	private bool canJump = true;
	private AudioSource source;
	private bool canInput = true;

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
	public bool CanInput
	{
		set
		{
			canInput = value;
		}
	}

	Rigidbody2D rb;
	TerrainController terrainController;

	void Start () 
	{
		source = GetComponent<AudioSource> ();
		Random.seed = (int)System.DateTime.Now.Ticks;
		GetComponent<SpriteRenderer> ().sprite = sprites [Random.Range (0, 1)];
		GameObject.Find ("Glaze").GetComponent<SpriteRenderer> ().sprite = sprites [Random.Range (2, 5)];
		GameObject.Find ("Sprinkles").GetComponent<SpriteRenderer> ().sprite = sprites [Random.Range (6, 8)];


		terrainController = GameObject.Find ("Background").GetComponent<TerrainController> ();
		rb = GetComponent<Rigidbody2D>(); //grab the rididbody
		rb.gravityScale = 0;

	}

	void Update () 
	{
		if (canInput) 
		{
			StopCoroutine("MoveToStart");
			if (!started && Input.GetMouseButton (0)) 
			{
				started = true;
				rb.gravityScale = 6;
				GameObject.Find ("Canvas").GetComponent<MenuController> ().MoveInstructions ();
				terrainController.TurnOnOrOff (true);
			}
			if (!gameOver && started) {
				if (Input.GetMouseButton (0) && canJump) //make sure you don't just fly off when you hold mouse 1 or hold your phone
					jump ();
				else
					rb.velocity = new Vector2 (velocity, rb.velocity.y);
				if (!Input.GetMouseButton (0))
					canJump = true;
			}

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
		GameObject.Find ("Main Camera").GetComponent <AdController> ().GameOver ();
		GameObject.Find ("Main Camera").GetComponent <GameManager> ().GameOver ();
		source.PlayOneShot (gameOverSound, .75f);
		terrainController.TurnOnOrOff(false);
		gameOver = true;
	}
	public void Restart()
	{
		Score = 0;
		canInput = false;
		Vector2 newPos = new Vector2 (-29.7f, 0f);
		transform.position = newPos;
		//StartCoroutine ("MoveToStart");
		rb.gravityScale = 0;
		started = false;
		gameOver = false;
	}
	IEnumerator MoveToStart()
	{
		float smoothing = 8f;
		Vector2 target = new Vector2(-29.4f, 0f);
		while(Vector2.Distance(transform.position, target) > 0.05f)
		{
			transform.position = Vector2.Lerp(transform.position, target, smoothing * Time.deltaTime);
			yield return null;
		}
		canInput = true;
		yield return new WaitForSeconds(.5f);

	}
}
