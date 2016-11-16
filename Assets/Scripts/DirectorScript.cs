using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DirectorScript : MonoBehaviour {

	public Text scoreText;
	private int score = 000;

	EnemyScript enemyScript;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider inCollider){

		if (inCollider.gameObject.GetComponent<EnemyScript> ().good) {

			score += 100;
			scoreText.text = "Score: \n" + score;
		} else {
			scoreText.text = "You are accepted a wrong woman!";
		}

	}
}
