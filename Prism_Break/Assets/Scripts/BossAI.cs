using UnityEngine;
using System.Collections;
public class BossAI : MonoBehaviour
{
    public Rigidbody2D fireball;                // Prefab of the fireball.
    public float speed = 10f;                   // The speed the rocket will fire at.
    int direction;
    Random rnd = new Random();
    private bool fired;
    private int shots;

    void Start()
    {
        fired = false;
    }
    void Update()
    {
        if (!fired)
        {
            Invoke("bossAttack", Random.Range(.1f,1));
            fired = true;
        }
        direction = Random.Range(0,2);
       
    }
    void bossAttack()
    {
        shots = Random.Range(1, 11);
        Rigidbody2D fireballInstance;
        for(int i = 0; i < shots; i++)
        {
            direction = Random.Range(0, 2);
            if (direction == 1)
                direction = 1;
            else
                direction = -1;
             fireballInstance = Instantiate(fireball, transform.position, Quaternion.Euler(new Vector3(0, 0, 0))) as Rigidbody2D;
            fireballInstance.position = new Vector2(fireballInstance.position.x, fireballInstance.position.y);
            fireballInstance.velocity = new Vector2(speed * direction, Random.Range(-50, 50));
        }
        fired = false;
    }
}