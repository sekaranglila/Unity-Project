using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using LitJson;
using UnityEngine.SceneManagement;


public class loginController : MonoBehaviour {

	public InputField email;
	public InputField pass;
	public static string em;
	public static string p;
	public string fbEmail;
	public string fbPass;
	public static bool valid = false;

	void Awake(){
		email = GameObject.Find ("Email").GetComponent<InputField> ();
		pass = GameObject.Find ("Password").GetComponent<InputField> ();

		string db = "https://travster-cbe42.firebaseio.com/user.json";
		WWW www = new WWW (db);
		StartCoroutine (GetKey (www));
		valid = false;
	}

	public void submit(){
		em = email.text;
		p = pass.text;

		if (fbEmail.Equals (em) && fbPass.Equals (p)) {
			valid = true;
		}

		if (valid) {
			SceneManager.LoadScene ("MainMenu");
			Debug.Log ("Valid");
		} else {
			email.text = "";
			pass.text = "";
			Debug.Log ("Not Valid");
		}
	}
	
	IEnumerator GetKey(WWW www) {
		yield return www;
		JsonData a = null;
		//check for errors
		if (www.error == null) {
			if (www.text != "null") {
				a = LitJson.JsonMapper.ToObject (www.text);
				fbEmail = a ["aku"]["email"].ToString ();
				fbPass = a ["aku"]["password"].ToString ();
			} else {
				Debug.Log("CANNOT EXTRACT KEY");
			}
		} else {
			Debug.Log("WWW Error! " + www.error);
		}
	}
}
