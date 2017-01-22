using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{	
	public float health = 500000f;					// The player's health.
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
		GemCreate ();
	}


	void GemCreate(){
		switch (health)
		{
		case 0:
			Application.LoadLevel ("sceneKill");
			break;
		case 1:
			Console.WriteLine("Case 1");
			break;
		case 2:
			Console.WriteLine("Case 2");
			break;
		case 3:

		case 4:

		case 5:
			
		default:
			Console.WriteLine("Default case");
			break;
		}
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
		UpdateHealthBar();

		// Play a random clip of the player getting hurt.
		int i = Random.Range (0, ouchClips.Length);
		AudioSource.PlayClipAtPoint(ouchClips[i], transform.position);
	}


	public void UpdateHealthBar ()
	{
        
	}
}
