using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickObject : MonoBehaviour {
	public static string myObject;
	public GameObject objectText;
	public AudioClip sound;

	public AudioSource source { get { return GetComponent<AudioSource>(); } }

	public static int totalPoints = 0;
	public static float timeBonus = 50;
	public static int remainItems = 5;

	public int randNumb = 0;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if (MascotHint.hintused == "y") {
			randNumb = Random.Range (1, 5);
			if (((gameObject.name == "blue-flower") || (gameObject.name == "Jar") || (gameObject.name == "snowflake-blue")) && (randNumb == 1)) {
				GetComponent<SpriteRenderer> ().color = new Color (1, 0, 0);
				MascotHint.hintused = "n";
			}
			if (((gameObject.name == "Pencils") || (gameObject.name == "Chicken") || (gameObject.name == "spiderweb")) && (randNumb == 2)) {
				GetComponent<SpriteRenderer> ().color = new Color (1, 0, 0);
				MascotHint.hintused = "n";
			}
			if (((gameObject.name == "brown-crayon") || (gameObject.name == "Pie") || (gameObject.name == "picture")) && (randNumb == 3)) {
				GetComponent<SpriteRenderer> ().color = new Color (1, 0, 0);
				MascotHint.hintused = "n";
			}
			if (((gameObject.name == "Book")|| (gameObject.name == "Wine glass") || (gameObject.name == "crown-red")) && (randNumb == 4)) {
				GetComponent<SpriteRenderer> ().color = new Color (1, 0, 0);
				MascotHint.hintused = "n";
			}
			if (((gameObject.name == "Blue-Star")|| (gameObject.name == "Lizard") || (gameObject.name == "pillow")) && (randNumb == 5)) {
				GetComponent<SpriteRenderer> ().color = new Color (1, 0, 0);
				MascotHint.hintused = "n";
			}
		}
	}

	void OnMouseDown() {
		gameObject.AddComponent<AudioSource>();
		source.clip = sound;
		source.playOnAwake = false;
		PlaySound ();

		myObject = gameObject.name;
		Debug.Log (myObject);
		Destroy (gameObject);
		Destroy (objectText);

		remainItems -= 1;
	}

	void PlaySound() {
		source.PlayOneShot(sound);
	}
}
