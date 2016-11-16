using UnityEngine;
using System.Collections;

public class TrailScript : MonoBehaviour {
	public float speed = 100;
	Vector3 startPosition;
	public GameObject player;
	float timer = 2;
	// Use this for initialization
	void Start () {
		startPosition = player.transform.position;
		transform.position = startPosition;
	}
	
	// Update is called once per frame
	void Update () {
		 
		timer += Time.deltaTime;
		if (transform.position.z < startPosition.z + 22f) {
			GetComponent<Rigidbody> ().velocity = Vector3.forward * speed;
		} if (transform.position.z > startPosition.z + 22f && timer>2) {
			//Destroy (gameObject);
			timer = 0;

			GetComponent<TrailRenderer>().Clear();
			GetComponent<TrailRenderer> ().time = 1f;
			transform.position = player.transform.position;

		}

		if (Mathf.CeilToInt(timer) == 0.5) {
			
			transform.position = player.transform.position;
			GetComponent<TrailRenderer> ().time = 0f;
		}

		if (player.transform.position.x != transform.position.x) {
			GetComponent<TrailRenderer>().Clear();
			transform.position = player.transform.position;
		}

	}
}
