using UnityEngine;
using System.Collections;

public class enemySpawner : MonoBehaviour {
	public GameObject leftWall;
	public GameObject rightWall;
	public GameObject backWall;
	public GameObject frontWall;
	public GameObject enemyUnit;
	private float currentTime = 0.0f;
	
	// Update is called once per frame
	void Update () {
		if (currentTime >= 4){
			Spawn ();
			currentTime = 0.0f;
		}
		currentTime += Time.deltaTime;

		//InvokeRepeating ("Spawn", 3, 4);
	}

	void Spawn(){
		int x = (int)Random.Range (leftWall.transform.position.x, rightWall.transform.position.x);
		int z = (int)Random.Range (backWall.transform.position.z, frontWall.transform.position.z);

		Instantiate(enemyUnit, new Vector3(x,6,z), Quaternion.identity);
	}
}
