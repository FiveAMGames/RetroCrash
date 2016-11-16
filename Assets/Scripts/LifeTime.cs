using UnityEngine;
using System.Collections;

public class LifeTime : MonoBehaviour {
	public float lifeTime;
	private float timer = 0;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		timer = timer + Time.time;
		if (timer > lifeTime) {
			Destroy (gameObject);
		}
		//Debug.Log (timer);
	}
}
