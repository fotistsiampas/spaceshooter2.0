using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject hazard;
    public Vector3 spawnValues;
    public int hazardCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;
    //gia tous doriforous
    public GameObject hazard2;
    public Vector3 spawnValues2;

    public Text scoreText;
    public Text restartText;
    public Text gameOverText;

    private bool gameOver;
    private bool restart;
    private int score;

    //kodikas apo to tutorial
    void Start()
    {
        gameOver = false;
        restart = false;
        restartText.text = "";
        gameOverText.text = "";
        score = 0;
        UpdateScore();
        StartCoroutine(SpawnWaves());
    }

    void Update()
    {
        if (restart)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {

                Application.LoadLevel(Application.loadedLevel);

            }
        }
    }

    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            for (int i = 0; i < hazardCount; i++)
            {
                Vector3 spawnPosition = new Vector3(spawnValues.x, Random.Range(-spawnValues.y, spawnValues.y), spawnValues.z); //ftignv diaforetikous aksones gia to diko moy game (x sth thesh tou y)
                Quaternion spawnRotation = Quaternion.identity;
                Vector3 spawnPosition2 = new Vector3(spawnValues2.x, Random.Range(-spawnValues2.y, spawnValues2.y), spawnValues2.z); //idios kodikas alla gia tous doriforous pou o paixths den prepei na katastrepsei
                Instantiate(hazard, spawnPosition, spawnRotation);
                Instantiate(hazard2, spawnPosition2, spawnRotation);//deuteros exthros
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);

            if (gameOver)
            {
                restartText.text = "Press 'R' for Restart"; //leei ston paixth pos na ksanaksekinhsei to paixnidi
                restart = true;
                break;
            }

        }
    }

    public void AddScore(int newScoreValue)
    {
        score += newScoreValue;
        UpdateScore();
    }

    void UpdateScore()
    {
        scoreText.text = "Score: " + score; //einai to keimeno tou score
    }

    public void GameOver()
    {
        gameOverText.text = "Game Over"; //to keimeno otan o paixths xasei
        gameOver = true;
    }
}
