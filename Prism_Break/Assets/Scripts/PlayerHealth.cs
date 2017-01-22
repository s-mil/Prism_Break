using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{	

	public float health = 5f;					// The player's health.

	//public float health = 5;					// The player's health.
 
	public float repeatDamagePeriod = 2f;		// How frequently the player can be damaged.
	public AudioClip[] ouchClips;				// Array of clips to play when the player is damaged.
	public float hurtForce = 400f;				// The force with which the player is pushed when hurt.
	public float damageAmount = 1f;		    	// The amount of damage to take when enemies touch the player

	private SpriteRenderer healthBar;			// Reference to the sprite renderer of the health bar.
	private float lastHitTime;					// The time at which the player was last hit.
	private PlayerControl playerControl;		// Reference to the PlayerControl script.
	private Animator anim;						// Reference to the Animator on the player


	void Awake ()
	{
		// Setting up references.
		playerControl = GetComponent<PlayerControl>();
		//healthBar = GameObject.Find("HealthBar").GetComponent<SpriteRenderer>();
		anim = GetComponent<Animator>();
		//UpdateHealthBar ();
	}


	void OnCollisionEnter2D (Collision2D col)
	{
		if (col.gameObject.tag == "Enemy")
			TakeDamage();
	}

	public void AssessDamage()
	{
		// ... and if the time exceeds the time of the last hit plus the time between hits...
		if (Time.time > lastHitTime + repeatDamagePeriod) 
		{
			// ... and if the player still has health...
			if(health > 0f)
			{
				// ... take damage and reset the lastHitTime.
				TakeDamage(); 
				lastHitTime = Time.time; 
			}
			// If the player doesn't have health, kill him
			else
			{
				// ... disable user Player Control script
				GetComponent<PlayerControl>().enabled = false;

				// ... Trigger the 'Die' animation state
				anim.SetTrigger("Die");

				// Go to killscreen
				Application.LoadLevel("sceneKill");
			}
		}
	}


	public void TakeDamage ()
	{
		// Reduce the player's health by 1.
		health -= damageAmount;
		print("health: " + health);
		// Update what the health bar looks like.
		//UpdateHealthBar();

		// Play a random clip of the player getting hurt.
		int i = Random.Range (0, ouchClips.Length);
		//AudioSource.PlayClipAtPoint(ouchClips[i], transform.position);
	}


	public void Update ()
	{
		GameObject health1 = GameObject.FindGameObjectWithTag ("health1");
		Destroy (health1);
		/*
		if (health < 1)
			Application.LoadLevel ("sceneKill");
		else if (health < 2) {
			GameObject health0 = GameObject.FindGameObjectWithTag ("health0");
			Destroy (health0);
		} else if (health < 3) {
			GameObject health1 = GameObject.FindGameObjectWithTag ("health1");
			Destroy (health1);
		} else if (health < 4) {
			GameObject health2 = GameObject.FindGameObjectWithTag ("health2");
			Destroy (health2);
		} else if (health < 5) {
			GameObject health3 = GameObject.FindGameObjectWithTag ("health3");
			Destroy (health3);
		}
		*/
	}

		/*
		int intHealth = (int) health;
		switch (intHealth)
		{
		case 0:
			Application.LoadLevel ("sceneKill");
			break;
		case 1:
			GameObject health0 = GameObject.FindGameObjectWithTag ("health0");
			Destroy (health0);
			break;
		case 2:
			GameObject health1 = GameObject.FindGameObjectWithTag ("health1");
			Debug.Log (intHealth);
			Destroy (health1);
			break;
		case 3:
			GameObject health2 = GameObject.FindGameObjectWithTag ("health2");
			Debug.Log (intHealth);
			Destroy (health2);
			break;
		case 4:
			GameObject health3 = GameObject.FindGameObjectWithTag ("health3");
			Debug.Log (intHealth);
			Destroy (health3);
			break;
		case 5:
			GameObject health4 = GameObject.FindGameObjectWithTag ("health4");
			Debug.Log (intHealth);
			Destroy (health4);
			break;
		default:
			Debug.Log (intHealth);
			break;
		}

	}
*/
}
