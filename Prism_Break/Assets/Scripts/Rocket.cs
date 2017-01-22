using UnityEngine;
using System.Collections;


public class Rocket : MonoBehaviour 
{
    private Gun gun;
	public GameObject explosion;		// Prefab of explosion effect.
    public ParticleSystem[] ps;

	void Start () 
	{
        if (Gun.bulletType)
            ps[0].Stop();
        else
            ps[1].Stop();
        // Destroy the rocket after 2 seconds if it doesn't get destroyed before then.
        Destroy(gameObject, 2);
        ps = GetComponentsInChildren<ParticleSystem>();
        // If you can find a reference to the gun make a refrence
        GameObject gunObject = GameObject.Find("Gun");
        if(gunObject)    
            gun = gunObject.GetComponent<Gun>();
    }

    void OnExplode()
	{
		// Create a quaternion with a random rotation in the z-axis.
		Quaternion randomRotation = Quaternion.Euler(0f, 0f, Random.Range(0f, 360f));

		// Instantiate the explosion where the rocket is with the random rotation.
		Instantiate(explosion, transform.position, randomRotation);
	}
	
	void OnTriggerEnter2D (Collider2D col) 
	{
        Debug.Log(gameObject.name);
        // If a bullet hits an enemy of the same type
        if (col.tag == "Enemy" && (Enemy.enemyType == Gun.bulletType))
        {
            // ... find the Enemy script and call the Hurt function.
            col.gameObject.GetComponent<Enemy>().Hurt();

            // Call the explosion instantiation.
            OnExplode();

            // Destroy the rocket.
            Destroy(gameObject);
            Destroy(col.gameObject);
        }
        // If a bullet hits an enemy of the wrong type
        else if (col.tag == "Enemy" && (Enemy.enemyType != Gun.bulletType))
        {
            Debug.Log("Mis-Type Collision");
            GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x * -1f, GetComponent<Rigidbody2D>().velocity.y);
        }

        // Otherwise if the player manages to shoot himself...
        else if (col.gameObject.tag == "Player")
        {
            // Instantiate the explosion and destroy the rocket.
            OnExplode();
            Destroy(gameObject);
        }

	    // Otherwise if the player manages to shoot himself...
	    else if(col.gameObject.tag == "Player")
	    {
		    // Instantiate the explosion and destroy the rocket.
		    OnExplode();
		    Destroy (gameObject);
	    }
	}
}
