using UnityEngine;
using System.Collections;

public class Wall : MonoBehaviour {

	void OnCollisionEnter(Collision col){
		if(col.gameObject.tag == "Shot"){
			Destroy (col.gameObject);
		}
	}
}
