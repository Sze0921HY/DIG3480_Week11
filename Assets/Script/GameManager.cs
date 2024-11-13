using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

using TMPro;

public class GameManager : MonoBehaviour
{

    public GameObject player;
    public GameObject enemy;
    public GameObject cloud;
    public GameObject coin;
    public GameObject powerup;

    public AudioClip powerUp;
    public AudioClip powerDown;



    public int MovingObjectSpeed;

    private int score;
    private int lives;

    private bool isPlayerAlive;


    public TextMeshProUGUI scoreNlivesText;
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI restartText;
    public TextMeshProUGUI powerupText;
    public TextMeshProUGUI congratulationsText;
    public TextMeshProUGUI nextlevelText;



    // Start is called before the first frame update
    void Start()
    {
        ResumeGame();
        Scene scene = SceneManager.GetActiveScene();
        Debug.Log("Active Scene is '" + scene.name + "'.");

        Instantiate(player, transform.position, Quaternion.identity);
        InvokeRepeating("CreateEnemy", 1f, 3f);
        StartCoroutine(CreatePowerup());
        CreateSky();
        InvokeRepeating("CreateCoin", 1f, 3f);
        score = 0;
        lives = 3;
        scoreNlivesText.text = "Score: " + score + "\nLives: " + lives;
        isPlayerAlive = true;
        MovingObjectSpeed = 1;

    }

    // Update is called once per frame
    void Update()
    {
        if (score >= 20) 
            NextLevel();
        else
            Restart();
        
    }
    public void CreateCoin()
    {
        Instantiate(coin, new Vector3(Random.Range(-9f, 9f), 7.5f, 0), Quaternion.identity);
    }
    void CreateEnemy()
    {
        Instantiate(enemy, new Vector3(Random.Range(-9f, 9f), 7.5f, 0), Quaternion.identity);
    }

    IEnumerator CreatePowerup()
    {
        Instantiate(powerup, new Vector3(Random.Range(-9f, 9f), 7.5f, 0), Quaternion.identity);
        yield return new WaitForSeconds(Random.Range(3f, 6f));
        StartCoroutine(CreatePowerup());
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

    public void GameOver()
    {
        isPlayerAlive = false;
        //Debug.Log("GG");
        CancelInvoke();
        gameOverText.gameObject.SetActive(true);
        StartCoroutine(Blinking());

        MovingObjectSpeed = 0;
    }



    void Restart()
    {
        if (Input.GetKeyDown(KeyCode.R) && isPlayerAlive == false)
        {
            SceneManager.LoadScene("Level1");
        }
    }

    public void UpdatePowerupText(string whichPowerup)
    {
        powerupText.text = whichPowerup;
    }

    public void PlayPowerUp()
    {
        AudioSource.PlayClipAtPoint(powerUp, Camera.main.transform.position);
    }
    public void PlayPowerDown()
    {
        AudioSource.PlayClipAtPoint(powerDown, Camera.main.transform.position);
    }


    IEnumerator Blinking()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.5f);
            restartText.gameObject.SetActive(true);
            yield return new WaitForSeconds(0.5f);
            restartText.gameObject.SetActive(false);
        }
    }

    void PauseGame()
    {
        Time.timeScale = 0;
    }

    void ResumeGame()
    {
        Time.timeScale = 1;
    }

    public void NextLevelOrMainMenu()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int totalScenes = SceneManager.sceneCountInBuildSettings;

        // If current scene is the last one, go to main menu (scene index 0)
        if (currentSceneIndex == totalScenes - 1)
        {
            Debug.Log("BACK TO MAINMENU");
            SceneManager.LoadScene("MainMenu");
        }
        else
        {
            Debug.Log("Keep going");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    public void NextLevel()
    {
        PauseGame();
        CancelInvoke();
        congratulationsText.gameObject.SetActive(true);
        nextlevelText.gameObject.SetActive(true);
        MovingObjectSpeed = 0;
        if (Input.GetKeyDown(KeyCode.R))
        {
            NextLevelOrMainMenu();
        }
    }
}