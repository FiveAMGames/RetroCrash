using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LetterByLetter : MonoBehaviour {

	private string str;
	private string inputText;
	public GameObject signature;

	private float waitTime = 0.1f;
	private float waitBetweenTime = 5f;

	private bool anyKeyCheck = false;
	private int warn;

	public bool performanceText = false;

	PerformanceQualityScript qualityScript;

	public bool lastInput = false;
	// Use this for initialization
	void Awake(){
		inputText = GetComponent<Text> ().text;
		GetComponent<Text> ().text = "";


	}

	void Start () {
		qualityScript = GameObject.Find ("PrformanceQuality").GetComponent<PerformanceQualityScript> ();
		warn = qualityScript.warnings;



		if (performanceText && !qualityScript.skipTutorial) {

			if (warn == 0) {
				inputText = "Your performance was good.";
			}
			if (warn == 1) {
				inputText = "You performance was ok.";
			}
			if (warn == 2) {
				inputText = "You performance needs improvement.";
			}
			if (warn >= 3) {
				inputText = "You performance was close to be unacceptable.";
			}
			StartCoroutine (AnimateText (inputText));
		}
		if (!performanceText) {
			StartCoroutine (AnimateText (inputText));
		}

		if (qualityScript.skipTutorial) {
			StartCoroutine (AnimateText (inputText));
		}
		qualityScript.skipTutorial = false;

	}


	
	// Update is called once per frame
	void Update () {
		GetComponent<Text> ().text = str;

		if (Input.anyKeyDown ) {
			if (!anyKeyCheck) {
				waitTime = 0f;
				anyKeyCheck = true;
			} if (anyKeyCheck && inputText.Length == str.Length) {
				Debug.Log ("Second Anykey");
				//waitBetweenTime = 0.1f;
				NextTexts();

			} 

		}






	}






   IEnumerator AnimateText(string strComplete){
		int i = 0;
		str = "";
		while (i < strComplete.Length) {
			str += strComplete [i++];
			yield return new WaitForSeconds (waitTime);
		}
	}

		void NextTexts(){
		//yield return new WaitForSeconds (waitBetweenTime);
		if (signature != null) {
			if (!lastInput) {
				gameObject.SetActive (false);
			}
			signature.SetActive (true);

		}
		if (signature == null && SceneManager.GetActiveScene().name != "NotInTime") {

		//	yield return new WaitForSeconds (waitBetweenTime);

			int sceneNumber = SceneManager.GetActiveScene ().buildIndex;
			SceneManager.LoadScene (sceneNumber + 1);
		}

		if (signature == null && SceneManager.GetActiveScene().name != "Warnings") {

			//	yield return new WaitForSeconds (waitBetweenTime);

			int sceneNumber = SceneManager.GetActiveScene ().buildIndex;
			SceneManager.LoadScene (sceneNumber + 1);
		}


		if (signature == null && SceneManager.GetActiveScene ().name == "NotInTime" || signature == null && SceneManager.GetActiveScene ().name == "Warnings") {
			SceneManager.LoadScene(0);

		} 
	}

		

}
