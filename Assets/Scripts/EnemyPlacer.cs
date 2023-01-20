using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPlacer : MonoBehaviour
{
    public float xWidth, yHeight;

    public int enemyCount;
    public int enemyMax;
    public int spawnPoint;
    public GameObject enemy;
    public List<Transform> listOspawns;

    // Start is called before the first frame update
    void Start()
    {
        xWidth = Camera.main.pixelWidth / 20;
        yHeight = Camera.main.pixelHeight / 20;
    }

    // Update is called once per frame
    void Update()
    {
        GameObject[] getCount = GameObject.FindGameObjectsWithTag("Enemy");
        enemyCount = getCount.Length;

        if (enemyCount <= enemyMax)
        {
            PlaceEnemy();
        }
    }


    void PlaceEnemy()
    {
        spawnPoint = Random.Range(1, 15);
        Instantiate(enemy, new Vector3(listOspawns[spawnPoint].transform.position.x, listOspawns[spawnPoint].transform.position.y, listOspawns[spawnPoint].transform.position.z) , Quaternion.identity);
    }







    void SpawnEnemy()
    {
        Vector3 pos = new();

        float percentage = Random.Range(0, 1);
        int side = Random.Range(0, 3);
        switch (side)
        {
            case 0:
                pos = new(-0.5f * xWidth, percentage * yHeight);
                break;
            case 1:
                pos = new(percentage * xWidth, -0.5f * yHeight);
                break;
            case 2:
                pos = new(0.5f * xWidth, percentage * yHeight);
                break;
            case 3:
                pos = new(percentage * xWidth, 0.5f * yHeight);
                break;
        }

        Instantiate(enemy, pos, Quaternion.identity);
    }
}
