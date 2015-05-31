using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TubeController : MonoBehaviour
{
	//y = -1.6
	public GameObject[] tubes;
	public GameObject player;
	public float offset;
	List<GameObject> liveTubes;

	void Start()
	{
		liveTubes = new List<GameObject>();
		InvokeRepeating("spawnTube", 0f, 1f);
		InvokeRepeating("DestroyTube", 2f,2f);
		Random.seed = 42;
	}
	void spawnTube()
	{
		int tubeGroup = Random.Range(1, 5);
		Vector2 newPos = player.transform.position;
		switch (tubeGroup + 1) 
		{
		case 1:
			offset = -15;
			break;
		case 2:
			offset = 1f;
			break;
		case 3:
			offset = -9;
			break;
		case 4:
			offset = -4;
			break;
		case 5:
			offset = 0;
			break;
		}
		newPos.y = offset;
		newPos.x += 30f;
		liveTubes.Add ( Instantiate(tubes[tubeGroup], newPos, Quaternion.identity) as GameObject);
	}
	void DestroyTube()
	{
		Destroy(liveTubes[0]);
		liveTubes.RemoveAt(0);
	}

}
