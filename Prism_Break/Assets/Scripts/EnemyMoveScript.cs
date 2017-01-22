using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveScript : MonoBehaviour {

	public float moveSpeed;
	public int HP = 2;
    public bool type = true;
    public Sprite WhiteEnemy;
    public Sprite BlackEnemy;

    // Use this for initialization
    void Start () {
		Flip ();
	}
	
	// Update is called once per frame
	void Update () {
        //calculates the motion of the sin curve
        float testx = this.transform.position.x / (64 / Mathf.PI);
        float line = Mathf.Cos(Time.realtimeSinceStartup * Mathf.PI + 0.5890486f + testx);
        
        if (line > this.transform.position.y / 36 != this.type)
            this.type = !this.type;     //Executes when enemy changes type, or close

        transform.Translate (new Vector3 (moveSpeed, 0, 0) * Time.deltaTime);
		if (transform.position.x <= -100 || transform.position.x >= 100) {
			Flip ();
			moveSpeed *= -1;
		}

        if (this.type == true)
            this.gameObject.GetComponent<SpriteRenderer>().sprite = WhiteEnemy;
        else
            this.gameObject.GetComponent<SpriteRenderer>().sprite = BlackEnemy;
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
