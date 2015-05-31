using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TubeController : MonoBehaviour
{
	//y = -1.6
	public GameObject tube;
	public List<GameObject> grounds;
	public GameObject ground;
	public GameObject player;
	public float offset;
	List<GameObject> liveTubes;

	void Start()
	{
		liveTubes = new List<GameObject>();
		grounds = new List<GameObject> ();
		InvokeRepeating("spawnTube", 1f, 1f);
		InvokeRepeating("DestroyTube", 6f,2f);
		InvokeRepeating ("SpawnGround", 1f, 3f);
		InvokeRepeating ("DestroyGround", 8f, 6f);
		Random.seed = 42;
	}
	void spawnTube()
	{
		int yAxi = Random.Range(17, 32);
		Vector3 newPos = player.transform.position;
		newPos.y = -yAxi;
		newPos.x += 30f;
		newPos.z = -1;
		liveTubes.Add ( Instantiate(tube, newPos, Quaternion.identity) as GameObject);
	}
	void SpawnGround()
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

}
