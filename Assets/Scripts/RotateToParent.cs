using UnityEngine;
using System.Collections;

public class RotateToParent : MonoBehaviour {
    Transform originalTransform;
	// Use this for initialization
	void Start () {
		originalTransform = transform;
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.parent != null) {
			transform.rotation = GameObject.Find ("WhereToParent").transform.rotation;
			transform.position = GameObject.Find ("WhereToParent").transform.position;
		} if (transform.parent == null) {
			transform.rotation = originalTransform.rotation;
			transform.position = originalTransform.position;

		}
	}
}
