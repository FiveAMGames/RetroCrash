using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class EndStamp : MonoBehaviour {

	float timer;
	public GameObject stamp;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		if (Mathf.CeilToInt(timer) > 5) {
			SceneManager.LoadScene (0);
		}
	}

	public void Shoot(){
		Instantiate (stamp, new Vector3 (transform.position.x - 4f, transform.position.y, transform.position.z), stamp.transform.rotation);
	}

}
