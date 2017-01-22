using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireball : MonoBehaviour {
    private PlayerHealth player;
	// Use this for initialization
	void Start () {
        player = GameObject.Find("Player").GetComponent<PlayerHealth>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            print ("player took damage from fireball");
            player.AssessDamage();
        }
    }
}
