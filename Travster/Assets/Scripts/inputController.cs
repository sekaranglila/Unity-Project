using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class inputController : MonoBehaviour {

	public InputField input;
	public static string txt;

	void Awake(){
		input = GameObject.Find ("Input").GetComponent<InputField> ();
	}

	public void GetInput(string s){
		txt = s;
		input.text = "";
	}

}
