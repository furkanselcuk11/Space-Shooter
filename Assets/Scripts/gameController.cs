using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class gameController : MonoBehaviour
{
    public GameObject asteroid;
    public Vector3 randomPos;
    public float randomSpeed;
    public float randomWait;
    
    int score;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI resetGameText;

    bool gameOverController = false;
    bool resetController = false;
    void Start()
    {
        score = 0;
        scoreText.text = "Skor: " + score;        
        StartCoroutine (createAsteroid());        
    }

     void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) && resetController)
        {
            SceneManager.LoadScene("Level1");   // Level 1 sahnesi yeniden açar
        }    
    }

    IEnumerator createAsteroid()
    {
        yield return new WaitForSeconds(randomWait);    // Oyun baþladýktan kaç saniye sonra fonk. girsin
        while (true)
        {
            for(int i = 0; i < 10; i++)
            {
                Vector3 vec = new Vector3(Random.Range(-randomPos.x, randomPos.x), 0, randomPos.z);
                Instantiate(asteroid, vec, Quaternion.identity);
                yield return new WaitForSeconds(randomSpeed);
            }          

            if (gameOverController)
            {                
                resetController = true;
                break;  // Eðer oyun bittiyse döngüyü bitir
            }
            yield return new WaitForSeconds(randomWait);
        }
        
    }

    public void scoreIcreases(int incomingScore)
    {
        score += incomingScore;
        scoreText.text = "Skor: " + score;
    }

    public void gameOver()
    {
        gameOverText.text = "Game Over";
        scoreText.transform.position = new Vector3(240,600,0);
        resetGameText.text = "Yeniden baþlatmak için 'R' tuþuna basýnýz...";
        gameOverController = true;
    }
}
