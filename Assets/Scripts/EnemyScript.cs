using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.SceneManagement;


public class EnemyScript : MonoBehaviour {







	//public Transform target;

	Rigidbody rig;
	private bool go = false;
	private float newPositionZ;
	private float boarders = 70f;


	public int age;
	public bool married;
	public bool baby;
	public bool pregnant;

	public Text [] _age;

	public bool good;


	public GameObject _pregnant;
	public GameObject _baby;
	public GameObject _married;
	public GameObject pregnantParticles;


	GameController gameControllerScript;

	public GameObject tafel;
	Vector3 rotation;




	int counter = 0;

	private bool goodAway = false;
	bool willBePregnant = false;
	float wennWillBePregnant = 0f;
	public float speed = 20;
	Vector3 target;
	float timeInPlay = 0f;
	void Start(){
		target = new Vector3 (GameObject.Find ("LookHere").transform.position.x, GameObject.Find ("LookHere").transform.position.y, GameObject.Find ("LookHere").transform.position.z);
		rotation = new Vector3(-84.993f, 94.174f, -169.418f);


		gameControllerScript = GameObject.Find ("GameController").GetComponent<GameController> ();

		married = (Random.value < 0.5);
		baby = (Random.value < 0.2);
		pregnant = (Random.value < 0.1);
		age = Mathf.Abs (Random.Range (18, 60));
			
		if (age > 42) {
			pregnant = false;
			baby = false;
		}

		if (baby) {
			_baby.SetActive (true);
		}

		if (pregnant) {
			Debug.Log ("Pregnant");
			GetComponentInChildren<Animator> ().SetTrigger ("Pregnant");
			//pregnantVersion.SetActive (true);
			//_pregnant.SetActive (true);
		}/* else if (!pregnant) {
			normalVersion.SetActive (true);
		}*/
		if (married) {
			//_married.SetActive (true);
		}

		//GetComponentsInChildrens<Text>().text = age.ToString();
		for (int i = 0; i< _age.Length; i++){
			_age [i].text = age.ToString ();
		}

		if (!pregnant && age < 42) {
			willBePregnant = Random.value < 0.3;
			wennWillBePregnant = Random.Range (8f, 12f);
		}



		if (baby || pregnant || age >= 45) {
			good = false;
		} //else if (married && age <= 35) {
		//good = false;}
		 else {
			good = true;
		}
		if (good){
			//Renderer rend = GetComponent<Renderer> ();
		    
			//rend.material.color = Color.green;
		}



		rig = GetComponent<Rigidbody> ();

		newPositionZ = rig.position.z - 100f;
	}
	void Update(){

		if (SceneManager.GetActiveScene ().name == "Tutorial") {


				good = true;

		}


		if (SceneManager.GetActiveScene ().name == "DayOne") {
			
			if (age < 45) {
				good = true;
			} else {
				good = false;
			}
		}
		if (SceneManager.GetActiveScene ().name == "DayTwo") {
			if (age > 45 || pregnant == true) {
				good = false;
			} else {
				good = true;
			}
		}





		timeInPlay += Time.deltaTime;
		if (good){
			//Renderer rend = GetComponent<Renderer> ();

			//rend.material.color = Color.green;
		}
		if (!go && !goodAway) {
			rig.position = Vector3.MoveTowards (rig.position, new Vector3 (rig.position.x, rig.position.y, newPositionZ), speed * Time.deltaTime); 
			transform.LookAt(target);
			tafel.transform.rotation = Quaternion.Euler (rotation); 
		
		}

		if (rig.position.z ==  newPositionZ) {
			go = true;
		}
			

		if (go) {
			
			rig.position = Vector3.MoveTowards (rig.position, new Vector3 (boarders, rig.position.y, rig.position.z), speed * Time.deltaTime);
			transform.rotation = Quaternion.LookRotation (new Vector3 (-boarders, rig.position.y, rig.position.z)); 
			tafel.transform.rotation = Quaternion.Euler (rotation);

		}
		if (goodAway) {
			go = true;
			boarders = -100f;
		}



		if (willBePregnant && timeInPlay>wennWillBePregnant && counter ==0) {
			GetComponentInChildren<Animator> ().SetTrigger ("Pregnant");
			pregnant = true;
			good = false;
			pregnantParticles.SetActive (true);
		    Debug.Log ("She is getting pregnant!");
			counter++;

		}

		  ///TO DO
	}

	void OnTriggerEnter(Collider inCollider){
		if (inCollider.CompareTag("Boarder")){
		go = false;
		boarders = -boarders;
		}
		else if(inCollider.CompareTag("Door")) {
			go = true;
			newPositionZ = rig.position.z - 3f;

		}

		if (inCollider.CompareTag ("GoodAway")) {
			if (good) {
				goodAway = true;
			}
		}


		if (inCollider.CompareTag ("Denied")) {
			gameControllerScript.EmployeeDenied (this.gameObject);

			Destroy (gameObject);
			Destroy (inCollider.gameObject);
		}
		if (inCollider.CompareTag ("Accepted")) {

			gameControllerScript.Hired ();
			Destroy (gameObject);
			gameControllerScript.EmployeeAccepted (this.gameObject);
			Destroy (inCollider.gameObject);
		}

	}
	void OnTriggerExit(Collider inCollider){
		if (inCollider.CompareTag ("Boarder") ) {
			newPositionZ = rig.position.z - 3f;

		}
	}
		

}
