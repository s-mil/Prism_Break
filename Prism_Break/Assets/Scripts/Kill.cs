/// <summary>
/// Kill Scene
/// attached to Main Camera
/// </summary>

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kill : MonoBehaviour {

	public Texture backgroundTexture;

	void OnGUI(){

		//Display background texture
		GUI.DrawTexture(new Rect(0,0,Screen.width,Screen.height), backgroundTexture);
	}

	void Update(){
		if (Input.GetButtonDown ("AButton")) {
			//retry - go where
			Application.LoadLevel ("world1");
		}
		if(Input.GetButtonDown("BButton")){
			Application.Quit ();
		}
	}
}
