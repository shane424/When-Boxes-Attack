using UnityEngine;
using System.Collections;

public class EnemyUtils : MonoBehaviour {

	public float spawnTime = 5.0f;
	public Transform[] spawnPoints;

	static public float maxHealth = 100.0f;
	public float currentHealth = 100.0f;
	public Material Enemy100;
	public Material Enemy80;
	public Material Enemy60;
	public Material Enemy30;
	public Material EnemyDead;
	public float speed;
	public float maxDist;
	public float minDist;
	public float damage;
	private GameObject playerManager;
	Rigidbody body;// = GetComponent<Rigidbody>();
	Renderer rend;// = GetComponent<Renderer>();
	private float currentTime = 0;

	// Use this for initialization
	void Start () {
		playerManager = GameObject.Find("player");
	}
	
	// Update is called once per frame
	void Update () {
		currentTime += Time.deltaTime;
		playerManager = GameObject.Find("player");
		//body = GetComponent<Rigidbody>();
		//rend = GetComponent<Renderer>();
		//moveToPlayer();
		updateEnemyMaterial();
	}

	void updateEnemyMaterial(){
		rend = GetComponent<Renderer>();
		if (currentHealth > 80) {
			rend.material = Enemy100;
		} else if (currentHealth > 60) {
			rend.material = Enemy80;
		} else if (currentHealth > 30) {
			rend.material = Enemy60;
		} else if (currentHealth > 0) {
			rend.material = Enemy30;
		} else {
			rend.material = EnemyDead;
		}
	}

	void updateEnemyHealth(float hit){
		currentHealth -= hit;
		Debug.Log (currentHealth);
		if (currentHealth <= 0)
			Destroy (gameObject);
	}

	void OnCollisionEnter(Collision col){
		if(col.gameObject.tag == "Shot"){
			Destroy (col.gameObject);
		}
		if (col.gameObject.tag == "Player") {
			col.gameObject.SendMessage("onHit", damage);
		}
	}

	/*void moveToPlayer(){
		//transform.LookAt (playerManager.transform);
		playerManager = GameObject.Find("Player");
		//if (Vector3.Distance (transform.position, playerManager.transform.position) >= minDist) {
			transform.LookAt (playerManager.transform);
			Debug.Log ("E");
			transform.position += transform.forward * 2 * speed * Time.deltaTime;
		//}

	}*/
}
