using UnityEngine;
using System.Collections;

public class swordHit : MonoBehaviour {
	public float damage;
	public float attackSpeed;
	private float currentTime = 0.0f;

	void Update () {
		currentTime += Time.deltaTime;
	}

	void OnCollisionEnter(Collision col){
		if (col.gameObject.tag == "Player") {
			Debug.Log ("hit Player");
			if (currentTime >= attackSpeed) {
				Debug.Log ("attackSpeedLookedAt");
				//GetComponent<EnemyUtils> ().currentHealth = GetComponent<EnemyUtils> ().currentHealth - damage;
				col.gameObject.SendMessage ("onHit", damage);
				currentTime = 0;
				//Destroy (col.gameObject);
			}
		}
		currentTime += Time.deltaTime;
		if (col.gameObject.tag == "Shot")
			Destroy (col.gameObject);
	}
}
