using UnityEngine;
using System.Collections;
[System.Serializable]
public class Boundary
{
	public float xMin, xMax, zMin, zMax;
}

public class PlayerMovement : MonoBehaviour {
	static public float maxHealth = 100.0f;
	public float currentHealth = 100.0f;
	public float speed;
	public Boundary boundary;
	public GameObject shot;
	public Transform shotSpawn;
	public float fireRate;
	Rigidbody body;
	int floorMask;
	Vector3 movement;
	float camRayLength = 100f;

	private float nextFire;

	void Awake()
	{
		floorMask = LayerMask.GetMask ("Floor");
	}

	// Use this for initialization
	void Start () 
	{
	
	}

	void Update()
	{
		if (Input.GetMouseButton (0) && Time.time > nextFire) 
		{
			//shot = Instantiate (shot) as GameObject;
			GameObject instance = Instantiate(shot,shotSpawn.position,shotSpawn.rotation) as GameObject;
			nextFire = Time.time + fireRate; 
			instance.GetComponent<Rigidbody> ().AddForce (transform.forward * 10); 
			//Rigidbody rb = shot.GetComponent<Rigidbody> ();
			//rb.velocity = rb.transform.forward*100;

			Destroy (instance, 3.0f);
		}
	}

	// Update is called once per frame
	void FixedUpdate () 
	{
		float moveHorizontal = Input.GetAxisRaw ("Horizontal");
		float moveVertical = Input.GetAxisRaw ("Vertical");

		Move (moveHorizontal, moveVertical);

		Turning ();

	}


	// Drag slows object down so it can get to pointer faster. 
	void Move(float h, float v)
	{
		body = GetComponent<Rigidbody> ();
		movement = new Vector3(h, 0.0f, v);
		Ray camRay = Camera.main.ScreenPointToRay (Input.mousePosition);
		movement = movement.normalized * speed * Time.deltaTime;

		// USE THIS TO GO FORWARD TOWARDS MOUSE POINTER-----------------------------
/*		if (h == 1) {
			// GO RIGHT OF POINTER
			body.AddForce(Vector2.right * 100 * speed * Time.deltaTime);
		} else if (h == -1) {
			// GO LEFT OF POINTER
			body.AddForce(Vector2.left * 100 * speed * Time.deltaTime);
		}
		if (v == 1) {
			//GO TOWARDS POINTER
			//if(body.position < camRay.GetPoint)
				body.AddForce(transform.forward * 100 * speed * Time.deltaTime);
			//body.MovePosition (transform.forward + movement);
		} else if (v == -1) {
			// GO AWAY FROM POINTER
			body.AddForce(transform.forward * -100 * speed * Time.deltaTime);
		}
*/
		// END COMMENT BLOCK---------------------------------------------------------

		// Normalise movement vector. Proportionalize to speed per sec.
	
		//movement = movement.normalized * speed * Time.deltaTime;
		// Move player to it's current position plus the movement.

		GetComponent<Rigidbody> ().MovePosition (transform.position + movement);
	}

	void Turning()
	{
		Ray camRay = Camera.main.ScreenPointToRay (Input.mousePosition);

		RaycastHit floorHit;

		if (Physics.Raycast (camRay, out floorHit, camRayLength, floorMask))
		{
			Vector3 playerToMouse = floorHit.point - transform.position;
			playerToMouse.y = 0f;

			Quaternion newRotation = Quaternion.LookRotation (playerToMouse);
			GetComponent<Rigidbody> ().MoveRotation (newRotation);
		}
	}

	void onHit(float damage){
		currentHealth -= damage;
		Debug.Log (currentHealth);
		if (currentHealth < 0) {
			Debug.Log ("YOU DIED");
		}
	}

//	void OnCollisionEnter(Collision collision){
//		if (collision.tag == "Shot") {
//			Destroy (collision);
//		}
//	}

}
