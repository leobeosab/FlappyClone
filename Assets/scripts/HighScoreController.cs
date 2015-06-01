using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class HighScoreController : MonoBehaviour {

	PlayerController player;
	Text text;
	int highScore;
	void Start () 
	{
		player = GameObject.Find ("Player").GetComponent<PlayerController>();
		highScore = PlayerPrefs.GetInt ("score");
		text = GetComponent<Text>();
		text.text = highScore.ToString();
	}

	void UpdateScore()
	{
		if (player.Score > highScore)
		{
			PlayerPrefs.SetInt("score", player.Score);
		}
	}
}
