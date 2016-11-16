using UnityEngine;
using System.Collections;

public class hairColorScript : MonoBehaviour {

	EnemyScript enemyScript;
	// Use this for initialization

	void Start () {
		enemyScript = GetComponentInParent<EnemyScript> ();
		/*int age = enemyScript.age;
		Renderer rend = GetComponent<Renderer> ();

		if (age<= 35) {
			rend.material.color = Color.green;
		}
		else if (age>=45) {
			rend.material.color = Color.gray;
		} else {
			rend.material.color = Color.cyan;
		}*/
		Renderer rend = GetComponent<Renderer> ();
		int color = Random.Range (0, 4);
		if (color == 0) {
			rend.material.color = Color.green;
		}
		if (color == 1) {
			rend.material.color = Color.red;
		}
		if (color == 2) {
			rend.material.color = Color.blue;
		}
		if (color == 3) {
			rend.material.color = Color.cyan;
		}



	


	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
