using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform goal;
    public float moveSpeed;
    public ParticleSystem explosion;
    public bool hit = false;
    public float time;
    public ParticleSystem trail;

    // Start is called before the first frame update
    void Start()
    {
        moveSpeed = Random.Range(1f,3f);
        goal = GameObject.FindGameObjectWithTag("Goal").transform;
        //explosion = GetComponentInChildren<ParticleSystem>();
        trail = transform.GetChild(1).GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 Point_2 = new Vector2(goal.position.x, goal.position.y);
        Vector2 Point_1 = new Vector2(transform.position.x,transform.position.y);
        float angle = Mathf.Atan2(Point_2.y - Point_1.y, Point_2.x - Point_1.x) * 180 / Mathf.PI;

        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        if (hit)
        {
            time += Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, goal.position, moveSpeed * Time.deltaTime / 4);
        } else
        {
            transform.position = Vector3.MoveTowards(transform.position, goal.position, moveSpeed * Time.deltaTime);
        }

        if (time > 1)
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision");
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Debug.Log("hit!");
            explosion.Play();
            //Destroy(gameObject);
            hit = true;
            trail.Stop();
            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<CircleCollider2D>().enabled = false;
            
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