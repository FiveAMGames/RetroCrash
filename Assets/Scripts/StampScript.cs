using UnityEngine;
using System.Collections;

public class StampScript : MonoBehaviour {


	bool wall = false;
	public float speed = 10;




	// Use this for initialization
	void Start () {
		transform.Rotate(0,0,Random.Range(-10, 10));



	}
	
	// Update is called once per frame
	void Update () {

		if (!wall) {

			GetComponent<Rigidbody> ().velocity = Vector3.forward * speed;
		} else {
			GetComponent<Rigidbody> ().velocity = new Vector3 (0, 0, 0);
			GetComponent<Collider> ().enabled = false;
		}

		
		
	}

	void OnTriggerEnter(Collider inCollider){
		if (inCollider.CompareTag("Wall")){
			wall = true;

		}
		if (inCollider.CompareTag ("LessExp")) {
			Destroy (gameObject);
		}
	}


}

