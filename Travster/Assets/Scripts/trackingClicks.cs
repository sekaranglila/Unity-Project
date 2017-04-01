using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class trackingClicks : MonoBehaviour {
	public static int totalClicks = 0;
	public KeyCode mouseClick;
	public int timeLeft = 120;

    public int totalPoints;

	public Text pointText;
	public Text bonusText;
	public Text totalText;
	public Text timerText;
	public Text titleText;
	public GameObject mascothint;
	public GameObject mascot;
	public GameObject ScorePanel;

	// Use this for initialization
	void Start () {
		StartCoroutine("LoseTime");
        if (PlayerPrefs.HasKey("totalPoints")) {
            totalPoints = PlayerPrefs.GetInt("totalPoints");
        } else {
            totalPoints = 0;
        }
		totalClicks = 0;
    }

    // Update is called once per frame
    void Update () {
		timerText.text = ("Time Left = " + timeLeft);
		ClickObject.timeBonus -= Time.deltaTime;

		if (timeLeft <= 0) {
			StopCoroutine ("LoseTime");
			timerText.text = "Times Up!";

			if (ClickObject.remainItems == 0) {
				ClickObject.totalPoints += (50 + (Mathf.RoundToInt (ClickObject.timeBonus)));
				titleText.text = "C O M P L E T E";
				pointText.text = "P O I N T S : " + 50;
				bonusText.text = "B O N U S / P E N A L T Y : " + (Mathf.RoundToInt (ClickObject.timeBonus));
				totalText.text = "T O T A L  P O I N T S : " + ClickObject.totalPoints;
                totalPoints += ClickObject.totalPoints;
                PlayerPrefs.SetInt("totalPoints", totalPoints);
				mascot.SetActive (true);
				mascothint.SetActive (false);
			} else {
				titleText.text = "F A I L E D";
				pointText.text = "P O I N T S : " + 0;
				bonusText.text = "B O N U S / P E N A L T Y : " + 0;
				totalText.text = "T O T A L  P O I N T S : " + ClickObject.totalPoints;
			}
			ScorePanel.SetActive (true);
			ClickObject.remainItems = -1;
		} else {
			if (ClickObject.remainItems == 0) {
				StopCoroutine ("LoseTime");
				ClickObject.totalPoints += (50 + (Mathf.RoundToInt (ClickObject.timeBonus)));
				titleText.text = "C O M P L E T E";
				pointText.text = "P O I N T S : " + 50;
				bonusText.text = "B O N U S / P E N A L T Y : " + (Mathf.RoundToInt (ClickObject.timeBonus));
				totalText.text = "T O T A L  P O I N T S : " + ClickObject.totalPoints;
				mascothint.SetActive (false);
				mascot.SetActive (true);
				ScorePanel.SetActive (true);
				ClickObject.remainItems = -1;
                totalPoints += ClickObject.totalPoints;
                PlayerPrefs.SetInt("totalPoints", totalPoints);
            }
		}

		if (Input.GetKeyDown(mouseClick)){
			totalClicks += 1;
		}
	}

	IEnumerator LoseTime()
	{
		while (true)
		{
			yield return new WaitForSeconds(1);
			timeLeft--;
		}
	}
}
