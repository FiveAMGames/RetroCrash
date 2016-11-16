using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CameraSchaderChange : MonoBehaviour {

	int count = 0;

	 PerformanceQualityScript qualityScript;

	public GameObject otherCamera;
	// Use this for initialization
	void Awake () {
		qualityScript = GameObject.Find ("PrformanceQuality").GetComponent<PerformanceQualityScript> ();

		otherCamera.SetActive (qualityScript.quality);


	}
	
	// Update is called once per frame
	void Update () {

		if (otherCamera.activeInHierarchy) {
			GetComponent<AudioListener> ().enabled = false;
		
		}
		//if (count < 1) {
		//	otherCamera.SetActive (qualityScript.quality);
		//	count++;
		//}
		//if (count>0){
		  if (Input.GetKeyDown (KeyCode.Q)) {
			otherCamera.SetActive (!qualityScript.quality);

			qualityScript.quality = !qualityScript.quality;
			GetComponent<AudioListener> ().enabled = qualityScript.quality;
		    }
		//}
	}
}
