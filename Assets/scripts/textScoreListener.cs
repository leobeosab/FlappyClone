using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class textScoreListener : MonoBehaviour 
{
	PlayerController playersController;
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
