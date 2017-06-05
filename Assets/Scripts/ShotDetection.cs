using UnityEngine;
using System.Collections;

public class ShotDetection : MonoBehaviour {

	public float damage;
	//public Transform bullet;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnCollisionEnter(Collision col){
		if(col.gameObject.tag == "Enemy"){
			Debug.Log ("hit");
			//GetComponent<EnemyUtils> ().currentHealth = GetComponent<EnemyUtils> ().currentHealth - damage;
			col.gameObject.SendMessage("updateEnemyHealth", damage);
			//Destroy (col.gameObject);
		}
		if (col.gameObject.tag == "Sword") {
			GameObject enemy = col.gameObject.transform.parent.gameObject;
			Debug.Log ("SWORD HIT");
			enemy.SendMessage("updateEnemyHealth", damage);
		}
	}
}
