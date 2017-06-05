using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {
	public Transform target;
	public float distance;

	public float scrollSpeed;
	private float scroll;
	
	// Update is called once per frame
	void Update () {
		scroll = Input.GetAxis ("Mouse ScrollWheel") * scrollSpeed;
		GetComponent<Camera> ().fieldOfView += scroll;
		transform.position = new Vector3(target.position.x, target.position.y + 10, target.position.z - distance);
		//transform.position.y = target.position.y;
		//transform.position.x = target.position.x;
	}
}
