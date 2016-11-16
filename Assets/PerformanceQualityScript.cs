using UnityEngine;
using System.Collections;

public class PerformanceQualityScript : MonoBehaviour {

	public int warnings = 0;

	public bool skipTutorial = false;

	NprEffects nprEffectsScript;


	GameController gameControllerScript;
	GameObject gameController;
	// Use this for initialization

	public bool quality = false;


	public static  PerformanceQualityScript Instance { get; private set; }

	private void Awake() {
		if (Instance != null) {
			DestroyImmediate(gameObject);
			return;
		}
		Instance = this;
		DontDestroyOnLoad(gameObject);
	}

	

	void Start () {
		skipTutorial = false;
		quality = false;
	}
	
	// Update is called once per frame
	void Update () {
		/*nprEffectsScript =  GameObject.Find ("CameraNPR").GetComponent<NprEffects> ();


		if (Input.GetKey (KeyCode.Q) && nprEffectsScript.enabled == false) {
			nprEffectsScript =  GameObject.Find ("CameraNPR").GetComponent<NprEffects> ();
			nprEffectsScript.enabled = true;
		}
		if (Input.GetKey (KeyCode.Q) && nprEffectsScript.enabled == true) {
			nprEffectsScript =  GameObject.Find ("CameraNPR").GetComponent<NprEffects> ();
			nprEffectsScript.enabled = false;
		}*/

	}

	public void Warning(int count){
		warnings = count;
		Debug.Log ("Performace script");
	}

	public void QualityChange(){
		quality = !quality;
	}


}
