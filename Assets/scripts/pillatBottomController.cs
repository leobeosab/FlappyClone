using UnityEngine;
using System.Collections;

public class pillatBottomController : MonoBehaviour {



	void Update()
	{
		if (transform.localPosition.x != 0 || transform.localPosition.z != -1) 
		{
			Vector3 pos = transform.localPosition;
			pos.x = 0;
			pos.z = -1;
			transform.localPosition = pos;
		}
	}
}
