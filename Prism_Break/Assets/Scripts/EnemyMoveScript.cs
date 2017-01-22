using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveScript : MonoBehaviour {

	public float moveSpeed;
	public int HP = 2;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		transform.Translate (new Vector3 (moveSpeed, 0, 0) * Time.deltaTime);
		if (transform.position.x <= -2880 || transform.position.x >= 2880) {
			Flip ();
			moveSpeed *= -1;
		}
	}

	void OnCollisionEnter2D(Collision2D col) {
		if (col.gameObject.tag == "Player")
		{
			Flip ();
			moveSpeed *= -1;
		}
    }


    public void Flip()
	{
		// Multiply the x component of localScale by -1.
		Vector3 enemyScale = transform.localScale;
		enemyScale.x *= -1;
		transform.localScale = enemyScale;
	}
}
