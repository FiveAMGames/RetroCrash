using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {
	Rigidbody rig;
	public float speed = 30f;

	public GameObject StampAccepted;
	public GameObject StampDeied;


	public GameObject AcceptedStampInHand;
	public GameObject DeniedStampInHand;

	Vector3 positionAcceptedStamp;
	Vector3 positionDeniedStamp;
	Quaternion rotationDeniedStamp;
	Quaternion rotationAcceptedStamp;

	public GameObject trail;


	private bool denied;  //on deny stamp trigger) {
	bool denyStampBack = false;
	bool acceptStampBack = false;

	private bool accepted;// on accept stamp trigger

	private bool _deny;  //if deny stamp is taken
	private bool _accept; // if accept stamp is taken
	private float timer = 0f;
	void Start(){

	//	StartCoroutine(Trail());

		positionAcceptedStamp = AcceptedStampInHand.transform.position;
		rotationAcceptedStamp =AcceptedStampInHand.transform.rotation;
		positionDeniedStamp = DeniedStampInHand.transform.position;
		rotationDeniedStamp = DeniedStampInHand.transform.rotation;
		rig = GetComponent<Rigidbody> ();
	}

	void Update(){
		timer += Time.deltaTime;

		if (Input.GetKeyDown (KeyCode.Space)/*)&& timer>0.1f*/ && _deny && !accepted) {
			GetComponentInChildren<Animator> ().SetTrigger ("Shoot");

		}
		if (Input.GetKeyDown (KeyCode.Space)/*&& timer>0.1f*/ && _accept && !denied) {
			GetComponentInChildren<Animator> ().SetTrigger ("Shoot");


		}



		if (!_deny && !_accept) {
			trail.GetComponent<TrailRenderer> ().enabled = false;
		}
		if (_deny || _accept) {
			trail.GetComponent<TrailRenderer> ().enabled = true;
		}


		/* if (Input.GetKeyDown (KeyCode.Space) && denied == null) {
			return;
		} if (Input.GetKeyDown (KeyCode.Space) && accepted == null) {
			return;
		}*/


		 if (Input.GetKeyDown (KeyCode.Space) && denied && !_deny) {
			
			GetComponentInChildren<Animator> ().SetTrigger ("Take");

			AcceptedStampInHand.transform.parent = null;

			acceptStampBack = true;
			Debug.Log ("acceptStamp true");
			AcceptedStampInHand.transform.rotation = rotationAcceptedStamp;

			_accept = false;
			_deny = true;

			DeniedStampInHand.transform.SetParent (GameObject.Find("WhereToParent").transform);
		//	DeniedStampInHand.transform.position = new Vector3 (GameObject.Find ("WhereToParent").transform.position.x,GameObject.Find ("WhereToParent").transform.position.y, GameObject.Find ("WhereToParent").transform.position.z);
			//DeniedStampInHand.transform.rotation = Quaternion.Euler(0, 0, 0);
			//	DeniedStampInHand.transform.rotation = Quaternion.Euler (-90, 0f, DeniedStampInHand.transform.rotation.z);
		//	gameObject.transform.rotation = Quaternion.Euler(-50f, gameObject.transform.rotation.y, gameObject.transform.rotation.z);
		
			//DeniedStampInHand.transform.position = Vector3.Lerp (DeniedStampInHand.transform.position, new Vector3(GameObject.Find ("WhereToParent").transform.position.x,GameObject.Find ("WhereToParent").transform.position.y, GameObject.Find ("WhereToParent").transform.position.z), 0.1f);




		}  if (Input.GetKeyDown (KeyCode.Space) && accepted && !_accept) {
			
			GetComponentInChildren<Animator> ().SetTrigger ("Take");


			DeniedStampInHand.transform.parent = null;

			denyStampBack = true;
			DeniedStampInHand.transform.rotation = rotationDeniedStamp;


			AcceptedStampInHand.transform.SetParent (GameObject.Find("WhereToParent").transform);
			//AcceptedStampInHand.transform.position = new Vector3 (GameObject.Find ("WhereToParent").transform.position.x,GameObject.Find ("WhereToParent").transform.position.y, GameObject.Find ("WhereToParent").transform.position.z);
			//AcceptedStampInHand.transform.rotation =Quaternion.Euler(0, 0, 0);
			//AcceptedStampInHand.transform.rotation = Quaternion.Euler (-90, 0f, AcceptedStampInHand.transform.rotation.z);
			_deny = false;
			_accept = true;
		}


		if (denyStampBack && DeniedStampInHand.transform.position !=  positionDeniedStamp) {
			DeniedStampInHand.transform.position = Vector3.Lerp(DeniedStampInHand.transform.position, new Vector3 (positionDeniedStamp.x+1f,positionDeniedStamp.y, positionDeniedStamp.z), Time.deltaTime*2f);
		}
		if (DeniedStampInHand.transform.position ==  positionDeniedStamp){
			denyStampBack = false;
		}

		if (acceptStampBack && AcceptedStampInHand.transform.position != positionAcceptedStamp) {
		//	AcceptedStampInHand.transform.position = Vector3.Lerp (AcceptedStampInHand.transform.position, new Vector3 (positionAcceptedStamp.x-1f,positionAcceptedStamp.y, positionAcceptedStamp.z), Time.deltaTime*2f);
			AcceptedStampInHand.transform.position = positionAcceptedStamp;
		}
		if (AcceptedStampInHand.transform.position == positionAcceptedStamp) {
			acceptStampBack = false;
			Debug.Log ("acceptedStamp false");
		}

	}


	void FixedUpdate(){


		float moveHorizontal = Input.GetAxis ("Horizontal");
		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, 0.0f);
		//rig.velocity = movement * speed;
		transform.position += movement*speed*Time.deltaTime;
	}
	void OnTriggerEnter(Collider inCollider){
		
		if (inCollider.CompareTag ("DenyStamp")) {
			denied = true;
		} if (inCollider.CompareTag ("AcceptStamp")) {
			accepted = true;
			//Debug.Log ("In Accepted Zone");
		}
	}
	void OnTriggerExit(Collider inCollider){
		if (inCollider.CompareTag ("DenyStamp")) {
			denied = false;
		}if (inCollider.CompareTag ("AcceptStamp")) {
			accepted = false;
		}
	}
	public void Shoot(){
		float y = transform.position.y;
		float x = transform.position.x;
		float whereY = Random.Range (y - 5f, y + 1f); 
		float whereX = Random.Range (x -1f, x + 1f);
		if (_deny && !accepted) {
			
			Instantiate (StampDeied,new Vector3(whereX, whereY, transform.position.z), StampDeied.transform.rotation);

			timer = 0;
		}
		if (_accept && !denied) {
			Instantiate (StampAccepted, new Vector3(whereX, whereY, transform.position.z), StampAccepted.transform.rotation);

			timer = 0;
		}
	}

	public void TakeDeny(){
	
	}

	public void TakeApply(){
	
	}

	//IEnumerator Trail(){
	//	Instantiate (trail, transform.position, trail.transform.rotation);
	//	yield return new WaitForSeconds(2f);
	//}
}
