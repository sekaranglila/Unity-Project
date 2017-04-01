using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class loginController : MonoBehaviour {

	public InputField email;
	public InputField pass;
	public static string em;
	public static string p;

	void Awake(){
		email = GameObject.Find ("Email").GetComponent<InputField> ();
		pass = GameObject.Find ("Password").GetComponent<InputField> ();
	}

	public void submit(){
		em = email.text;
		email.text = "";

		p = pass.text;
		pass.text = "";

		Debug.Log (em);
		Debug.Log (p);
	}
}
