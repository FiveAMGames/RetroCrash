using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class StartMenuScript : MonoBehaviour {
	
	PerformanceQualityScript qualityScript;
	// Use this for initialization
	void Start () {
		qualityScript = GameObject.Find ("PrformanceQuality").GetComponent<PerformanceQualityScript> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.Escape)) {
			GameOver ();
		}
	}

	public void NewGame(){
		SceneManager.LoadScene ("InputTutorial");
	}
	public void GameOver(){
		Application.Quit ();
	}
	public void SkipTutorial(){
		SceneManager.LoadScene ("InputDayOne");
		qualityScript.skipTutorial = true;
	}

	public void KnowYourEnemy(){
		SceneManager.LoadScene ("KnowYourEnemy");
	}
	public void Menu(){
		SceneManager.LoadScene ("FirstScreen");
	} 
}
