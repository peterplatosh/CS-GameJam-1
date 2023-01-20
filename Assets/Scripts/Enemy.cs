using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform goal;
    public float moveSpeed;
    public ParticleSystem explosion;

    // Start is called before the first frame update
    void Start()
    {
        goal = GameObject.FindGameObjectWithTag("Goal").transform;
        explosion = GetComponentInChildren<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, goal.position, moveSpeed * Time.deltaTime);


    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision");
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Debug.Log("hit!");
            //Instantiate(explosion, transform.position, Quaternion.identity);
            //explosion.Play();
            Destroy(gameObject);
            
        }
        if (collision.gameObject.CompareTag("Goal"))
        {
            Debug.Log("Ran into the goal");
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("Cannon"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}