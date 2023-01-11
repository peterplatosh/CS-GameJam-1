using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPlacer : MonoBehaviour
{
    public int playerCount;
    public GameObject player;
    public float circRadius;
    public float rotationSpeed;
    // Start is called before the first frame update
    void Start()
    {
        SpawnPlayers(playerCount, circRadius);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0f, 0f, -Input.GetAxis("Horizontal") * rotationSpeed) * Time.deltaTime);
    }

    void SpawnPlayers(int playerCount, float circRadius)
    {
        for (int i = 0; i < playerCount; i++)
        {
            float pi = Mathf.PI;
            float angleInRads = i * 2 * pi / playerCount;
            float angleInDegs = angleInRads * 180 / pi;
            Vector3 pos = new Vector3(Mathf.Cos(angleInRads), Mathf.Sin(angleInRads), 0) * circRadius;
            Vector3 rotation = new Vector3(0, 0, angleInDegs);
            Instantiate(player, pos, Quaternion.Euler(rotation), transform);
        }
    }
}
