using UnityEngine;
using System.Collections;

public class Hand : MonoBehaviour {


	PlayerScript playerScript;


	// Use this for initialization
	void Start () {
		playerScript = GetComponentInParent<PlayerScript> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void ShootNow(){
		playerScript.Shoot ();
	}
}
