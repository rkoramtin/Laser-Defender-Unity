using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shreder : MonoBehaviour {
     void OnTriggerEnter2D(Collider2D col)
    {
        Destroy(col.gameObject);
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
