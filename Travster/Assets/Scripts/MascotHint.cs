using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MascotHint : MonoBehaviour {
	public float rb = 1f;
	public float hinttimer = 0;
	public static string hintready = "n";
	public static string hintused = "n";
	public GameObject glow;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		hinttimer += Time.deltaTime;

		if ((hinttimer >= .5) && (rb > 0)) {
			rb -= .02f;
			hinttimer = 0;
		}

		if (rb <= 0) {
			hintready = "y";
			glow.SetActive (true);
		}
	}

	void OnMouseDown(){
		if (hintready == "y") {
			hintused = "y";
			hintready = "n";
			rb = 1f;
			glow.SetActive (false);
		}
	}

	void OnMouseDrag(){
		Vector2 mousePos = new Vector2 (Input.mousePosition.x, Input.mousePosition.y);
		Vector2 objPos = Camera.main.ScreenToWorldPoint (mousePos);
		glow.transform.position = objPos;
		transform.position = objPos;
	}
}
