using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollScript : MonoBehaviour {

	public float speed;
	public float x;
	//public float increment;
	Renderer ren;

	void Start () {
/*		x = 0f;
*/		ren = GetComponent<Renderer>();
	}


	void Update () {
/*		float h = Input.GetAxis ("LeftJoystickHorizontal");

		if (h > 0) {
			x += increment;
			if (x > 1.0f) {
				x -= 1.0f;
			}
		}
		else if(h < 0){
			x -= increment;
			if (x < -1.0f) {
				x += 1.0f;
			}
		}
*/
		x = Mathf.Repeat (Time.time * speed, 1);
		ren.material.mainTextureOffset = new Vector2 (x, 0);
	}
}
