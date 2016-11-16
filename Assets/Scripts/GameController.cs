using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.SceneManagement;



public class Woman {
	public int age;
	public bool pregnant;
	public bool baby;
	public bool married;

	public Woman(int aage, bool apregnant, bool ababy, bool amarried){
		age = aage;
		pregnant = apregnant;
		baby = ababy;
		married = amarried;
	}

}



public class GameController : MonoBehaviour {




	private int toHire;

	public Text toHireText;

	private bool taken = false;

	public GameObject[] enemiesArray;

	public GameObject tafel;

	public GameObject clockHour;
	public GameObject clockMinutes;
	public float clockSpeed;


	public float startWait = 10f; 
	public float spawnWait =2f;
	public int enemiesCount = 1;
	public float enemiesPosition = 11f;
	public Text scoreText;
	public Text timeText;
	private int score = 0;
	EnemyScript enemyScript;


	public List <Woman> people = new List<Woman>();


	private float warningsTimer = 0;
	private float timer = 0f;
	public GameObject noteFromSheff;

	int clockCount = 0;
	int hourMy;

	public int warningsCount = 0;

	public GameObject[] warnings;
	PerformanceQualityScript qualityScript;

	void Start () {
		StartCoroutine (EnemiesWave ());
		toHire = int.Parse (toHireText.text);
		qualityScript = GameObject.Find ("PrformanceQuality").GetComponent<PerformanceQualityScript> ();
		qualityScript.Warning (0);
	}
	

	void Update () {

		if (Input.GetKey(KeyCode.Escape)){
			SceneManager.LoadScene("FirstScreen");
		}


		warningsTimer += Time.deltaTime;

		//warningsCount++;
		Debug.Log (warningsCount);
		if (warningsCount > 3) {
			warningsTimer = 0;
			SceneManager.LoadScene (12);
		}
		if (warningsCount > 0 && warningsCount <4 ) {
			warnings [warningsCount-1].SetActive(true);
				
		}



		clockMinutes.transform.Rotate (0, 0, Time.deltaTime * clockSpeed);
		clockHour.transform.Rotate (0, 0, Time.deltaTime * clockSpeed / 12);

		if (Time.time >0 && Mathf.CeilToInt(Time.time) % 12 == 0 && Mathf.CeilToInt(Time.time) !=hourMy) {
			clockCount++;
			hourMy = Mathf.CeilToInt (Time.time);
			//clockHour.transform.Rotate (0, 0, -30f);
		}


		string time = Mathf.Abs (Time.time).ToString();
		timeText.text = time;

		timer = timer + Time.deltaTime;
		if (timer > 2f) {
			noteFromSheff.GetComponent<CanvasGroup> ().alpha -= 0.3f*Time.deltaTime;
		
		}
		if (timer > 7f) {
			noteFromSheff.SetActive (false);
		}



		if (toHire == 0) {
			Debug.Log("toHire =" + toHire);
			int sceneNumber = SceneManager.GetActiveScene ().buildIndex;
			SceneManager.LoadScene (sceneNumber + 1);
		}

		if (clockCount== 8) {
			SceneManager.LoadScene (11);
		}
	}

	public void PlayerWithPlatform(){
		taken = true;
	
	}
	public bool CheckPlayer(){
		return taken;
	}
	public void PlayerWithoutPlatform(){
		
		taken = false;
	
	}

	IEnumerator EnemiesWave(){
		yield return new WaitForSeconds (startWait);
		int j = 0;
		while (j<enemiesCount) {
			for (int i = 0; i < enemiesCount; i++) {
				
				float random = Random.Range (0.0f, 1f);
				
				if (random < 0.5f) {
					
					GameObject goody =	Instantiate (enemiesArray [0], new Vector3 (0f, -1.28f, 45f), Quaternion.identity) as GameObject;
					EnemyScript newGood = goody.GetComponent<EnemyScript> ();
					newGood.age = Mathf.Abs (Random.Range (23, 45));
					newGood.baby = false;
					newGood.pregnant = false;
					if (newGood.age <= 35) {
						newGood.married = false;
					} else if (newGood.age > 35){
						newGood.married = Random.value < 0.5;
					}

					newGood.good = true;



				} else {
					Vector3 enemiesPositions = new Vector3 (0f, -1.28f, 45f);
					int enemy = Random.Range (0, enemiesArray.Length);
					Instantiate (enemiesArray [enemy], enemiesPositions, Quaternion.identity);

				}



				yield return new WaitForSeconds (spawnWait);
				j++;
				//startWait = 1f;
			}

		}
		StartCoroutine (EnemiesWave ());
	}

	public void EmployeeAccepted(GameObject employee){
		enemyScript = employee.GetComponent<EnemyScript> ();

		if (enemyScript.good) {
			score += 100;
			scoreText.text = "Score: \n" + score;

		} else {
			warningsCount++;
			qualityScript.Warning (warningsCount);
			scoreText.text = "Wrong woman! \n";
			Woman newOne = new Woman (enemyScript.age, enemyScript.pregnant, enemyScript.baby, enemyScript.married);
			people.Add(newOne);
			int number = people.Count;

			noteFromSheff.SetActive (true);
			noteFromSheff.GetComponent<CanvasGroup> ().alpha = 1f;



			noteFromSheff.GetComponentInChildren<Text> ().text = ReturnPeople (number - 1);
			timer = 0;
		}



	}
	public void EmployeeDenied(GameObject employee){
		enemyScript = employee.GetComponent<EnemyScript> ();
		if (enemyScript.good) {
			//scoreText.text = "Oh, no! It was a good woman!";
			noteFromSheff.SetActive (true);
			noteFromSheff.GetComponent<CanvasGroup> ().alpha = 1f;
			noteFromSheff.GetComponentInChildren<Text> ().text = "She was ok, why did you denied her?!";
			timer = 0;
			warningsCount++;
			qualityScript.Warning (warningsCount);
		}
	}

	public string ReturnPeople(int id){
		string what = "";
		string old = "";
		string baby = "";
		string pregnant = "";
		//string risk = "";

		Woman wrongAccepted = people [id];
		if (wrongAccepted.age >= 45) {
			old = "She is too old \n";
		} if (wrongAccepted.baby) {
			baby = "She has little childrens\n";
		} if (wrongAccepted.pregnant) {
			pregnant = "She is pregnant!\n";
		}//if (wrongAccepted.age <= 35 && wrongAccepted.married && ! wrongAccepted.pregnant) {
		//	risk = "She is joung and married.\nHigh risk of pregnancy!\n";
		//}

		what = old + baby + pregnant +/*risk* + */"You schouldn't accept her! Grrrr!" ;

		return what;
	}

	public void Hired(){
		toHire--;
		Debug.Log (toHire);
		toHireText.text = toHire.ToString();
	}
}
