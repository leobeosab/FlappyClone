using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TubeController : MonoBehaviour
{
	//y = -1.6
	public GameObject[] tubes;
	public GameObject player;
	List<GameObject> liveTubes;

	void Start()
	{
		liveTubes = new List<GameObject>();
		InvokeRepeating("spawnTube", 0f, 4f);
		InvokeRepeating("DestroyTube", 8f,4f);
		Random.seed = 42;
	}
	void spawnTube()
	{
		int tubeGroup = Random.Range(0, 4);
		Vector2 newPos = player.transform.position;
		newPos.y = -1.6f;
		newPos.x += 50f;
		liveTubes.Add ( Instantiate(tubes[tubeGroup], newPos, Quaternion.identity) as GameObject);
	}
	void DestroyTube()
	{
		Destroy(liveTubes[0]);
		liveTubes.RemoveAt(0);
	}

}
