using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Firebutton : MonoBehaviour {
    public float speed = 15.0f;
    public float padding = 1f;
    public GameObject projectile;
    public float projectileSpeed;
    public float firinigRate = 0.2f;
    public float health = 250f;
    public AudioClip fireSound;
    private Rigidbody2D rigi;
    // Use this for initialization
    void Start () {
		
	}
    void Fire()
    {
        Vector3 offset = new Vector3(0, 1, 0);
        GameObject beam = Instantiate(projectile, transform.position + offset, Quaternion.identity) as GameObject;
        beam.GetComponent<Rigidbody2D>().velocity = new Vector3(0, projectileSpeed, 0);
        AudioSource.PlayClipAtPoint(fireSound, transform.position);
    }
    // Update is called once per frame
    void Update () {
		
	}
}
