using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {
    public GameObject enemyPrefab;
    public float width = 10f;
    public float height = 5f;
    public float speed = 5f;
    public float spawnDelay = 0.5f;
    private bool movingRight = true;
    private float xmax;
    private float xmin;

    // Use this for initialization
    void Start() {
        float distanceToCamera = transform.position.z - Camera.main.transform.position.z;
        Vector3 leftBoundry = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distanceToCamera));
        Vector3 rightEdge = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, distanceToCamera));
        xmax = rightEdge.x;
        xmin = leftBoundry.x;
        SpawnUntilFull();
    }
    void SpawnEnemies()
    {
        foreach (Transform child in transform)
        {
            GameObject enemy = Instantiate(enemyPrefab, child.transform.position, Quaternion.identity)as GameObject;
            enemy.transform.parent = child;
        }
    }
    void SpawnUntilFull()
    {
        Transform freePosiotion = NextFreePosition();
        if (freePosiotion)
        {
            GameObject enemy = Instantiate(enemyPrefab, freePosiotion.position, Quaternion.identity) as GameObject;
            enemy.transform.parent = freePosiotion;
        }
        if (NextFreePosition()) {
            Invoke("SpawnUntilFull", spawnDelay);
        }
    }

    public void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position, new Vector3(width, height));
    }
    // Update is called once per frame
    void Update () {
		if(movingRight)
        {
            transform.position += Vector3.right *speed * Time.deltaTime;
        }
        else
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
        }
        float rightedgeofformation = transform.position.x + (0.5f * width);
        float leftedgeofformation = transform.position.x - (0.5f * width);
        if (leftedgeofformation<xmin)
        {
            movingRight = true;
        }
        else if (rightedgeofformation > xmax)
        {
            movingRight = false;
        }
        if (AllMembersDead())
        {
            Debug.Log("Empty Formation");
            SpawnUntilFull();
        }
        
    }
    Transform NextFreePosition()
    {
        foreach (Transform childPositionGAmeObject in transform)
        {
            if (childPositionGAmeObject.childCount == 0)
            {
                return childPositionGAmeObject;
            }

        }
        return null;
    }
    bool AllMembersDead()
    {

        foreach (Transform childPositionGAmeObject in transform)
        {
            if (childPositionGAmeObject.childCount > 0)
            {
                return false;
            }

        }
        return true;
    }
}
