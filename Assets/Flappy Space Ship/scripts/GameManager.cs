using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using UnityEngine.SocialPlatforms;

public class GameManager : MonoBehaviour 
{
	void Start()
	{
		if (! PlayGamesPlatform.Instance.localUser.authenticated) 
		{
			PlayGamesClientConfiguration config = new PlayGamesClientConfiguration.Builder ().Build ();
		
			PlayGamesPlatform.InitializeInstance (config);
			// recommended for debugging:
			PlayGamesPlatform.DebugLogEnabled = true;
			// Activate the Google Play Games platform
			PlayGamesPlatform.Activate ();

			PlayGamesPlatform.Instance.Authenticate ((bool success) => { }, true);
		}
	}
	public void GameOver()
	{
		PlayerPrefs.SetInt ("gamesplayed", PlayerPrefs.GetInt ("gamesplayed", 0) + 1);
		Debug.Log(PlayerPrefs.GetInt("gamesplayed").ToString());
		if (PlayGamesPlatform.Instance.localUser.authenticated) 
		{
		
			int score = GameObject.Find ("Player").GetComponent<PlayerController> ().Score;
			if (score <= 25 && PlayerPrefs.GetInt ("25achieve", 0) == 0) 
			{
				Social.ReportProgress ("CgkIpuWKiNwYEAIQAw", 100.0f, (bool success) => {});
				PlayerPrefs.SetInt ("25achieve", 1);
			}
			if (score <= 50 && PlayerPrefs.GetInt ("50achieve", 0) == 0) 
			{
				Social.ReportProgress ("CgkIpuWKiNwYEAIQBA", 100.0f, (bool success) => {});
				PlayerPrefs.SetInt ("50achieve", 1);
			}
			if (PlayerPrefs.GetInt ("gamesplayed") >= 1 && PlayerPrefs.GetInt ("one", 0) == 0) 
			{
				Social.ReportProgress ("CgkIpuWKiNwYEAIQAA", 100.0f, (bool success) => {});
				PlayerPrefs.SetInt ("one", 1);
			} 
			else if (PlayerPrefs.GetInt ("gamesplayed") >= 10 && PlayerPrefs.GetInt ("ten", 0) == 0) 
			{
				Social.ReportProgress ("CgkIpuWKiNwYEAIQAQ", 100.0f, (bool success) => {});
				PlayerPrefs.SetInt ("ten", 1);
			} 
			else if (PlayerPrefs.GetInt ("gamesplayed") >= 100 && PlayerPrefs.GetInt ("onehundred", 0) == 0) 
			{
				Social.ReportProgress ("CgkIpuWKiNwYEAIQAg", 100.0f, (bool success) => {});
				PlayerPrefs.SetInt ("onehundred", 1);
			}
		}

	}
}
