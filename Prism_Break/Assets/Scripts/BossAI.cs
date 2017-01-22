using UnityEngine;
using System.Collections;
public class BossAI : MonoBehaviour
{
    public Rigidbody2D fireball;                // Prefab of the fireball.
    public float speed = 25f;                   // The speed the rocket will fire at.
    int direction;
    Random rnd = new Random();


    void Update()
    {
        direction = Random.Range(0,2);
        if (direction == 1)
            direction = 1;
        else
            direction = -1;
        Rigidbody2D fireballInstance = Instantiate(fireball, transform.position, Quaternion.Euler(new Vector3(0, 0, 0))) as Rigidbody2D;
        fireballInstance.position = new Vector2(fireballInstance.position.x, fireballInstance.position.y);
        fireballInstance.velocity = new Vector2(speed * direction, Random.Range(-360,360));
    }
}