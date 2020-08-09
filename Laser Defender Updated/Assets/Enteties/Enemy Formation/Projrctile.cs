using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projrctile : MonoBehaviour {
    public float damage = 100f;
    public float getDamage()
    {
        return damage;
    }
    public void Hit()
    {
        Destroy(gameObject);
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
