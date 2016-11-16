using UnityEngine;
using System.Collections;

public class notRotate : MonoBehaviour {
	Vector3 rotation;
	// Use this for initialization
	void Start () {
		rotation = new Vector3(transform.rotation.x, transform.rotation.y, transform.rotation.z);
	}
	
	// Update is called once per frame
	void Update () {
		transform.rotation = Quaternion.Euler(rotation);
	}
}
