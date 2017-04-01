using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class clickBackground : MonoBehaviour {
	public AudioClip sound;
	public Light Lamp;

	public AudioSource source { get { return GetComponent<AudioSource>(); } }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (trackingClicks.totalClicks > 5) {
			StartCoroutine (makeDark ());
			trackingClicks.totalClicks = 0;
		}
	}

	/*void OnMouseDown() {
		gameObject.AddComponent<AudioSource>();
		source.clip = sound;
		source.playOnAwake = false;
		PlaySound ();

		StartCoroutine (makeDark ());

		trackingClicks.totalClicks = 0;

		StopCoroutine (makeDark ());
	}*/

	void PlaySound() {
		source.PlayOneShot(sound);
	}

	IEnumerator makeDark(){
		Lamp.intensity = 0;
		yield return new WaitForSeconds (5);
		Lamp.intensity = 1;
	}
}
