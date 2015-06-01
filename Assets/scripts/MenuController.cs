using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class MenuController : MonoBehaviour {

	public List<Sprite> medals;
	PlayerController player;
	Text highScoreText;
	int highScore;
	Button restartButton;
	Image medalImage;
	void Start () 
	{
		player = GameObject.Find ("Player").GetComponent<PlayerController>();
		highScore = PlayerPrefs.GetInt ("score");
		highScoreText = GameObject.Find ("High Score").GetComponent<Text>();
		highScoreText.text = highScore.ToString();
		restartButton = GameObject.Find("Restart Button").GetComponent<Button>();
		restartButton.onClick.AddListener(() => 
	    {
			Restart ();
		});
		medalImage = GameObject.Find ("Medal Image").GetComponent<Image>();
	}
	
	void UpdateScore()
	{
		if (player.Score > highScore)
		{
			PlayerPrefs.SetInt("score", player.Score);
			highScoreText.text = player.Score.ToString ();
		}
		if (player.Score >= 25 && player.Score < 50)
		{
			medalImage.sprite = medals[1];
		}
		else if (player.Score > 50)
		{
			medalImage.sprite = medals[2];
		}
	}

	void Restart()
	{
		Application.LoadLevel(0);
	}

	IEnumerator moveUp()
	{

	}
	IEnumerator moveDown()
	{
		Vector2 target = new Vector2(0, 32);
		while(Vector2.Distance(transform.position, target.position) > 0.05f)
		{
			transform.position = Vector3.Lerp(transform.position, target.position, smoothing * Time.deltaTime);
			
			yield return null;
		}
		
		print("Reached the target.");
		
		yield return new WaitForSeconds(3f);
		
		print("MyCoroutine is now finished.");
	}
	public void GameOver()
	{
		UpdateScore ();
	}
}
