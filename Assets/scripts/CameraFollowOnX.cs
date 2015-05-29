using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class CameraFollowOnX : MonoBehaviour {

	public GameObject player;

	void Update () 
	{
		Vector3 newTransform = transform.position;
		newTransform.x = player.transform.position.x;
		transform.position = newTransform;
	}
}
