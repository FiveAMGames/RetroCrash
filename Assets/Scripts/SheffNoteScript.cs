using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SheffNoteScript : MonoBehaviour {


	CanvasGroup opacity;
	void Start () {
		opacity = GetComponent<CanvasGroup> ();
		opacity.alpha= 0.75f;
	
	}
	
	// Update is called once per frame
	void Update () {
		



	}
}
