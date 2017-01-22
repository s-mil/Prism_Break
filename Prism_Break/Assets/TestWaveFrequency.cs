using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestWaveFrequency : MonoBehaviour {
    [SerializeField]
    float offset = 0;
    [SerializeField]
    float scale = 1;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        float testx = this.transform.position.x / (64 / Mathf.PI);
        float line = Mathf.Cos(Time.realtimeSinceStartup * Mathf.PI + 0.5890486f + testx);
        Debug.Log(line > this.transform.position.y / 36);

    }
}
