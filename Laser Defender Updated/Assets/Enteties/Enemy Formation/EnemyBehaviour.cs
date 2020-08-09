using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour {
    public GameObject projectile;
    public float health = 150;
    public float projectileSpeed = 10;
    public float shotsPerSeconds = 0.5f;
    public int scoreValue = 150;
    public AudioClip firesound;
    public AudioClip deathsound;
    private Scorekepper scorkeeper;
    void OnTriggerEnter2D(Collider2D collider)
    {
        Projrctile missile = collider.gameObject.GetComponent<Projrctile>();
        if (missile)
        {
            health -= missile.getDamage();
            missile.Hit();
            if(health<=0)
            {
                Die();
            }
            
        }
    }
    void Die()
    {
        AudioSource.PlayClipAtPoint(deathsound, transform.position);
        scorkeeper.Score(scoreValue);
        Destroy(gameObject);
    }
    // Use this for initialization
    void Start () {
        scorkeeper = GameObject.Find("Score").GetComponent<Scorekepper>();
    }
	
	// Update is called once per frame
	void Update () {
        float probability = Time.deltaTime * shotsPerSeconds;
        if(Random.value<probability)
        {
            Fire();
        }
       

    }
    void Fire()
    {
        Vector3 startPosition = transform.position + new Vector3(0, -1, 0);
        GameObject missile = Instantiate(projectile, startPosition, Quaternion.identity) as GameObject;
        missile.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -projectileSpeed);
        AudioSource.PlayClipAtPoint(firesound, transform.position);
    }
}
