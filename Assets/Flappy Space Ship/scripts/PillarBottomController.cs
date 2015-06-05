using UnityEngine;
using System.Collections;

public class PillarBottomController : MonoBehaviour 
{
	void Update() //This is used to correct any offesets that occur when placing multiple prefabs while moving
	{

		if (transform.localPosition.x != 0 || transform.localPosition.z != -1) {
			Vector3 pos = transform.localPosition;
			pos.x = 0;
			pos.z = -1;
			transform.localPosition = pos;
		}

	}
}
