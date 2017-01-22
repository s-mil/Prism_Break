

	using System.Collections;
	using System.Collections.Generic;
	using UnityEngine;

	public class Win: MonoBehaviour {

		public Texture backgroundTexture;

		void OnGUI(){

			//Display background texture
			GUI.DrawTexture(new Rect(0,0,Screen.width,Screen.height), backgroundTexture);
		}
}
