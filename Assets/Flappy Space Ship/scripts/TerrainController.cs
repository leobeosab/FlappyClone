using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TerrainController : MonoBehaviour {

	public GameObject tube;
	public GameObject ground;
	GameObject player;
	List<GameObject> grounds;
	List<GameObject> liveTubes;
	
	void Start()
	{
		player = GameObject.Find ("Player");
		liveTubes = new List<GameObject>();
		grounds = new List<GameObject> ();
		Random.seed = 42;
	}
	void spawnTube()
	{
		int yAxi = Random.Range(17, 32); //genereate a random number for the Y value of the tube (-17 - -32) were the best viable locations 
		Vector3 newPos = player.transform.position;
		newPos.y = -yAxi;
		newPos.x += 30f;
		newPos.z = -1;
		liveTubes.Add ( Instantiate(tube, newPos, Quaternion.identity) as GameObject); //add to the list for later destruction and deleteion
	}
	void SpawnGround() //spawn the ground where need be
	{
		Vector3 newPos = player.transform.position;
		newPos.y = -22f;
		newPos.x += 32f;
		newPos.z = -3;
		grounds.Add ( Instantiate(ground, newPos, Quaternion.identity) as GameObject);
	}
	void DestroyGround()
	{
		Destroy(grounds[0]);
		grounds.RemoveAt(0);
	}
	void DestroyTube()
	{
		Destroy(liveTubes[0]);
		liveTubes.RemoveAt(0);
	}
	public void TurnOnOrOff(bool on)
	{
		if (on) 
		{
			InvokeRepeating("spawnTube", 1f, 1f);
			InvokeRepeating("DestroyTube", 6f,1.2f); //can't have them delete too fast
			InvokeRepeating ("SpawnGround", 1f, 3f);
			InvokeRepeating ("DestroyGround", 8f, 6f);
		} 
		else 
		{
			CancelInvoke("spawnTube");
			CancelInvoke("spawnGround");
			CancelInvoke("DestroyTube");
			CancelInvoke("DestroyGround");
		}
	}
}
