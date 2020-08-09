using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public float speed = 15.0f;
    public float padding = 1f;
    public GameObject projectile;
    public float projectileSpeed;
    public float firinigRate = 0.2f;
    public float health = 250f;
    public AudioClip fireSound;
    private Rigidbody2D rigi;
    private void Awake()
    {
        rigi = GetComponent<Rigidbody2D>();
    }
    float xmin ;
    float xmax ;
	// Use this for initialization
	void Start () {
        float distance = transform.position.z - Camera.main.transform.position.z;
        Vector3 leftmost=Camera.main.ViewportToWorldPoint(new Vector3(0,0,distance));
        Vector3 rightmost = Camera.main.ViewportToWorldPoint(new Vector3(1,0, distance));
        xmin = leftmost.x+padding;
        xmax = rightmost.x-padding;
    }
	public void Fire()
    {
        Vector3 offset = new Vector3(0, 1, 0);
        GameObject beam = Instantiate(projectile, transform.position+offset, Quaternion.identity) as GameObject;
        beam.GetComponent<Rigidbody2D>().velocity = new Vector3(0, projectileSpeed, 0);
        AudioSource.PlayClipAtPoint(fireSound, transform.position);
    }
    public void Lefting()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;
    }
    public void Righting()
    {
        transform.position += Vector3.right * speed * Time.deltaTime;
    }
    // Update is called once per frame
    void Update () {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            InvokeRepeating("Fire", 0.000001f, firinigRate);
        }
        if(Input.GetKeyUp(KeyCode.Space))
        {
            CancelInvoke("Fire");
        }
		if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position += Vector3.left *speed* Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
                {
            transform.position += Vector3.right *speed* Time.deltaTime;
        }
        //player ro be gamespace mahdud krdn
        float newX = Mathf.Clamp(transform.position.x, xmin, xmax);
        transform.position = new Vector3(newX, transform.position.y, transform.position.z);
	}
    void OnTriggerEnter2D(Collider2D collider)
    {
        
        Projrctile missile = collider.gameObject.GetComponent<Projrctile>();
        if (missile)
        {
            Debug.Log("they met");
            health -= missile.getDamage();
            missile.Hit();
            if (health <= 0)
            {
                Die();
                Destroy(gameObject);

            }

        }
    }
    void Die()
    {
        LevelManager man = GameObject.Find("LevelManager").GetComponent<LevelManager>();
        man.LoadLevel("Win Screen");
        Destroy(gameObject);
    }
}
