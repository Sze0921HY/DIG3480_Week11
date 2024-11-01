using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject player;
    public GameObject enemy;
    public GameObject enemy2; // Enemy2 object will be attached here si it can spawn 
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(player, transform.position, Quaternion.identity);
        InvokeRepeating("CreateEnemy", 1f, 3f);
        InvokeRepeating("CreateEnemy2", 1f, 1f);
    }
    // Update is called once per frame
    void Update()
    {
    }
    void CreateEnemy()
    {
        Instantiate(enemy, new Vector3(Random.Range(-9f, 9f), 8f, 0),
        Quaternion.identity);


    }

    void CreateEnemy2()
    {
        // they spawn at the edge of the scrren at the right
        Instantiate(enemy2, new Vector3(11.5f, Random.Range(-6f, 0.5f), 0),
        Quaternion.identity);

    }
}
