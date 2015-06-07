using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class MenuController : MonoBehaviour {
	
	public List<Sprite> medals;
	GameObject instructions;
	GameObject gameOver;
	PlayerController player;
	Text highScoreText;
	int highScore;
	Button restartButton;
	Image medalImage;
	void Start () 
	{
		instructions = GameObject.Find ("Instructions");
		gameOver = GameObject.Find ("Game Over Object");
		player = GameObject.Find ("Player").GetComponent<PlayerController>();
		highScore = PlayerPrefs.GetInt ("score");
		highScoreText = GameObject.Find ("High Score").GetComponent<Text>();
		highScoreText.text = highScore.ToString();
		restartButton = GameObject.Find("Restart Button").GetComponent<Button>();
		restartButton.onClick.AddListener(() => 
		                                  {
			Reset ();
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
	
	void Reset()
	{
		Application.LoadLevel (0);
		//Restart ();
	}
	
	IEnumerator MoveDown(GameObject uiElement)
	{
		float smoothing = 8f;
		Vector2 target = new Vector2(0, 0);
		while(Vector2.Distance(uiElement.transform.localPosition, target) > 0.05f)
		{
			uiElement.transform.localPosition = Vector2.Lerp(uiElement.transform.localPosition, target, smoothing * Time.deltaTime);
			yield return null;
		}
		yield return new WaitForSeconds(.1f);
		if (uiElement.Equals (instructions)) {
			GameObject.Find ("Player").GetComponent<PlayerController>().CanInput = true;
		}
	}
	
	IEnumerator MoveUp(GameObject uiElement)
	{
		StopCoroutine ("MoveDown");
		float smoothing = 8f;
		Vector2 target = new Vector2(0, 300);
		while(Vector2.Distance(uiElement.transform.localPosition, target) > 0.05f)
		{
			uiElement.transform.localPosition = Vector2.Lerp(uiElement.transform.localPosition, target, smoothing * Time.deltaTime);
			yield return null;
		}

	}
	void Restart()
	{
		GameObject.Find ("Background").GetComponent<TerrainController> ().Restart ();
		GameObject.Find ("Player").GetComponent<PlayerController> ().Restart ();
		StartCoroutine ("MoveUp", gameOver);
		StartCoroutine ("MoveDown", instructions);
	}

	public void GameOver()
	{
		UpdateScore ();
		StartCoroutine ("MoveDown", gameOver);
	}
	public void MoveInstructions()
	{
		StartCoroutine ("MoveUp", instructions);
	}
}
