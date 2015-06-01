using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TextScoreListener1 : MonoBehaviour 
{
	PlayerController playersController; //Updates the score text
	Text text;
	void Start()
	{
		playersController = GameObject.Find ("Player").GetComponent<PlayerController>();
		text = GetComponent<Text> ();
	}
	void Update()
	{
		text.text = playersController.Score.ToString();
	}
}
