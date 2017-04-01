using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text;

public class bonusRound : MonoBehaviour {
	public int timeLeft = 60;
	public static int totalPoints = 0;
	public static int remainProb = 5;
	public 	int num = 0;
	public static bool added = false;

	public Text probText;
	public Text pointText;
	public Text totalText;
	public Text timerText;
	public Text titleText;
	public GameObject mascot;
	public GameObject ScorePanel;

	// Use this for initialization
	void Start () {
		StartCoroutine ("LoseTime");
		if (PlayerPrefs.HasKey ("totalPoints")) {
			totalPoints = PlayerPrefs.GetInt ("totalPoints");
		} else {
			totalPoints = 0;
		}
		probText.text = RandomString ();
		ScorePanel.SetActive (false);
		added = false;
	}
	
	// Update is called once per frame
	void Update () {
		timerText.text = ("Time Left = " + timeLeft);

		if (inputController.txt.Length > 0) {
			if (inputController.txt.Equals (probText.text)) {
				remainProb -= 1;
				probText.text = RandomString ();
			}
		}

		if (timeLeft <= 0) {
			StopCoroutine ("LoseTime");
			timerText.text = "Times Up!";

			if (remainProb == 0) {
				if (!added) {
					addPoints ();
				}
				titleText.text = "C O M P L E T E";
				pointText.text = "P O I N T S : 50";
				totalText.text = "T O T A L  P O I N T S : " + totalPoints;
				mascot.SetActive (true);
			} else {
				titleText.text = "F A I L E D";
				totalText.text = "P O I N T S : 0";
				totalText.text = "T O T A L  P O I N T S : " + totalPoints;
			}
			ScorePanel.SetActive (true);
		} else {
			if (remainProb == 0) {
				StopCoroutine ("LoseTime");
				if (!added) {
					addPoints ();
				}
				titleText.text = "C O M P L E T E";
				pointText.text = "P O I N T S : 50";
				totalText.text = "T O T A L  P O I N T S : " + totalPoints;
				mascot.SetActive (true);
				ScorePanel.SetActive (true);
			}
		}
	}

	void addPoints(){
		totalPoints += 50;
		PlayerPrefs.SetInt("totalPoints", totalPoints);
		added = true;
	}
		
	IEnumerator LoseTime(){
		while (true){
			yield return new WaitForSeconds(1);
			timeLeft--;
		}
	}

	string RandomString(){
		StringBuilder sb = new StringBuilder ();
		char c;

		for (int i = 0; i < 4; i++) {
			num = Random.Range (1, 16);
			c = (char)('a' + num);
			sb.Append (c);
		}
		return sb.ToString();
	}
}