/// <summary>
/// Main Menu
/// attached to Main Camera
/// </summary>

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour {

	public Texture backgroundTexture;

	void OnGUI(){

		//Display background texture
		GUI.DrawTexture(new Rect(0,0,Screen.width,Screen.height), backgroundTexture);
	}

	void Update(){
		if (Input.GetButtonDown ("AButton")) {
			Application.LoadLevel ("sceneBoss");
		}
	}
}
