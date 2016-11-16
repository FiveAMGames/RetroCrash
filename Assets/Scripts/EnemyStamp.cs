using UnityEngine;
using System.Collections;

public class EnemyStamp : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter(Collider inCOllider){
		if (inCOllider.CompareTag("Stamp")){
			Destroy(inCOllider.gameObject);
			Destroy(gameObject);
		}
	}
}
