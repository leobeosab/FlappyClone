using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class CameraFollowOnX : MonoBehaviour {

	public GameObject player;
	public float offset = 0f;
	void Update () 
	{
		Vector3 newTransform = transform.position;
		newTransform.x = player.transform.position.x + offset;
		transform.position = newTransform;
	}
}
