using UnityEngine;
using System.Collections;

public class EnemyPregnant : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter(Collider inCOllider){
		if (inCOllider.CompareTag("Pregnant")){
			Destroy(inCOllider.gameObject);
			Destroy(gameObject);
		}
	}
}
