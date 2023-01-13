using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Vector3 spawnPos;
    public GameObject Bullet;
    public Transform[] children;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        Debug.Log("shoot");
        children = GetComponentsInChildren<Transform>();
        Instantiate(Bullet, children[1].position, transform.rotation);
        children[3].GetComponent<ParticleSystem>().Play();
    }
}