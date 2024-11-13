using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public GameObject explosion;
    public GameObject coins;
    public GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D whatDidIHit)
    {
        if (whatDidIHit.tag == "Player")
        {
            GameObject.Find("GameManager").GetComponent<GameManager>().LiveScore(1);
            GameObject.Find("Player(Clone)").GetComponent<Player>().LoseALife();
            Debug.Log("No shield, so live -1");
            Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
        else if (whatDidIHit.tag == "Weapon")
        {
            GameObject.Find("GameManager").GetComponent<GameManager>().EarnScore(5);
            Destroy(whatDidIHit.gameObject);
            Instantiate(explosion, transform.position, Quaternion.identity);
            Instantiate(coins, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
        else if (whatDidIHit.tag == "Shield")
        {
            GameObject.Find("Player(Clone)").GetComponent<Player>().LoseALife();
            Debug.Log("it touched the shield and didn't minus player's lives");
            Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
}