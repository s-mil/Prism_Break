using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireball : MonoBehaviour
{
    public PlayerHealth health;

    // Use this for initialization
    void Start()
    {

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "player")
        {
            health.TakeDamage();
        }
    }
}
