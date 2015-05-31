using UnityEngine;
using System.Collections;

public class GroundController : MonoBehaviour {

	void Update()
	{
		if (transform.localPosition.z != -3) 
		{
			Vector3 pos = transform.localPosition;
			pos.z = -3;
			transform.localPosition = pos;
			Debug.Log("Fuck   " + transform.localPosition);
		}
	}
}
