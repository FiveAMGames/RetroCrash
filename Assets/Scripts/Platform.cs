using UnityEngine;
using System.Collections;

public class Platform : MonoBehaviour {

	Rigidbody rig;
	private bool go = true;

	private float boarders = 70f;




	public float speed = 20;
	void Start(){

		rig = GetComponent<Rigidbody> ();


	}
	void Update(){



		if (go) {

			rig.position = Vector3.MoveTowards (rig.position, new Vector3 (boarders, rig.position.y, rig.position.z), speed * Time.deltaTime);


		}
	}

	void OnTriggerEnter(Collider inCollider){
		if (inCollider.CompareTag("Boarder")){
			boarders = -boarders;
		}
	}

}
