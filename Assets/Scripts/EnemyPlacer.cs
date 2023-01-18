using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPlacer : MonoBehaviour
{
    public float xWidth, yHeight;

    public int enemyCount;
    public int enemyMax;
    public GameObject enemy;

    // Start is called before the first frame update
    void Start()
    {
        xWidth = Camera.main.pixelWidth;
        yHeight = Camera.main.pixelHeight;
    }

    // Update is called once per frame
    void Update()
    {
        GameObject[] getCount = GameObject.FindGameObjectsWithTag("Enemy");
        enemyCount = getCount.Length;

        if (enemyCount <= enemyMax)
        {
            SpawnEnemy();
        }
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
