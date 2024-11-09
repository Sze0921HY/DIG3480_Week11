using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{

    public GameObject player;
    public GameObject enemy;
    public GameObject cloud;
    private int score;
    private int lives;

    public TextMeshProUGUI scoreNlivesText;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(player, transform.position, Quaternion.identity);
        InvokeRepeating("CreateEnemy", 1f, 3f);
        CreateSky();
        score = 0;
        lives = 3;
        scoreNlivesText.text = "Score: " + score + "\nLives: " + lives;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void CreateEnemy()
    {
        Instantiate(enemy, new Vector3(Random.Range(-9f, 9f), 7.5f, 0), Quaternion.identity);
    }

    void CreateSky()
    {
        for (int i = 0; i < 30; i++)
        {
            Instantiate(cloud, transform.position, Quaternion.identity);
        }
    }

    public void EarnScore(int howMuch)
    {
        score = score + howMuch;
        scoreNlivesText.text = "Score: " + score + "\nLives: " + lives;
    }

    public void LiveScore(int minusLive)
    {
        lives = lives - minusLive;
        scoreNlivesText.text = "Score: " + score + "\nLives: " + lives;
    }

}