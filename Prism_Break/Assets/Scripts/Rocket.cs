using UnityEngine;
using System.Collections;


public class Rocket : MonoBehaviour
{
    private Gun gun;
    public GameObject explosion;		// Prefab of explosion effect.
    public ParticleSystem[] ps;
    public AudioClip playerDeath;
    public AudioClip enemyDeath;
    private PlayerHealth player;
    private BossAI boss;




    void Start()
    {
        boss = GameObject.Find("RedBoss").GetComponent<BossAI>();
        player = GameObject.Find("Player").GetComponent<PlayerHealth>();
        if (Gun.bulletType)
            ps[0].Stop();
        else
            ps[1].Stop();
        // Destroy the rocket after 2 seconds if it doesn't get destroyed before then.
        Destroy(gameObject, 2);
        ps = GetComponentsInChildren<ParticleSystem>();
        // If you can find a reference to the gun make a refrence
        GameObject gunObject = GameObject.Find("Gun");
        if (gunObject)
            gun = gunObject.GetComponent<Gun>();
    }

    void OnExplode()
    {
        // Create a quaternion with a random rotation in the z-axis.
        Quaternion randomRotation = Quaternion.Euler(0f, 0f, Random.Range(0f, 360f));

        // Instantiate the explosion where the rocket is with the random rotation.
        Instantiate(explosion, transform.position, randomRotation);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        //if (col.tag == "Boss")
           // Destroy(col.gameObject);
        // If a bullet hits an enemy of the same type
        EnemyMoveScript enemy = col.gameObject.GetComponent<EnemyMoveScript>();

        if (enemy != null)
        {
            if (col.tag == "Enemy" && (enemy.type == Gun.bulletType))
            {
				Destroy(col.gameObject);
                StartCoroutine(enemyDing());
                // ... find the Enemy script and call the Hurt function.
                col.gameObject.GetComponent<Enemy>().Hurt();

                // Call the explosion instantiation.
                OnExplode();

                // Destroy the rocket.


            }
            // If a bullet hits an enemy of the wrong type
            else if (col.tag == "Enemy" && (enemy.type != Gun.bulletType))
                {
                    Debug.Log("Mis-Type Collision");
                    GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x * -1f, GetComponent<Rigidbody2D>().velocity.y);
                }
            
            // Otherwise if the player manages to shoot himself...
            else if (col.gameObject.tag == "Player")
            {
                player.AssessDamage();
                StartCoroutine(playerDing());
                // Instantiate the explosion and destroy the rocket.
                OnExplode();
            }
        }
    }
    IEnumerator playerDing()
    {
        AudioSource audio = GetComponent<AudioSource>();
        audio.PlayOneShot(playerDeath);
        yield return new WaitForSeconds(1.4f);
        Destroy(gameObject);
    }
    IEnumerator enemyDing()
    {
        AudioSource audio = GetComponent<AudioSource>();
        audio.PlayOneShot(enemyDeath);
        yield return new WaitForSeconds(1.4f);
        Destroy(gameObject);
    }
}
