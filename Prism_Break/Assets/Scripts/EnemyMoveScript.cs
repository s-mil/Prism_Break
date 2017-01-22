using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveScript : MonoBehaviour {

	public float moveSpeed;
	public int HP = 2;
    public bool type = true;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        float testx = this.transform.position.x / (64 / Mathf.PI);
        float line = Mathf.Cos(Time.realtimeSinceStartup * Mathf.PI + 0.5890486f + testx);
        
        if (line > this.transform.position.y / 36 != this.type)
        {
            this.type = !this.type;
            //Executes when flips (Or reasonably close)
        }

        transform.Translate (new Vector3 (moveSpeed, 0, 0) * Time.deltaTime);
		if (transform.position.x <= -100 || transform.position.x >= 100) {
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
