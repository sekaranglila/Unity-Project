using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TotalScore : MonoBehaviour {

    public int totalPoints;
    public Text totalPointsText;

    // Use this for initialization
    void Start() {
        if (PlayerPrefs.HasKey("totalPoints")) {
            totalPoints = PlayerPrefs.GetInt("totalPoints");
        } else {
            totalPoints = 0;
        }
        totalPointsText.text = "Points: " + totalPoints;
    }
	
	// Update is called once per frame
	void Update () {
        if (PlayerPrefs.HasKey("totalPoints")) {
            totalPoints = PlayerPrefs.GetInt("totalPoints");
        } else {
            totalPoints = 0;
        }
        totalPointsText.text = "Points: " + totalPoints;
    }
}
