using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class gameController : MonoBehaviour
{
    public GameObject asteroid; // Asteroid nesnesi
    public Vector3 randomPos;   // Asteroid nesnesinin random pozisyonu
    public float randomSpeed;   // Asteroid nesnesinin doðma hýzý
    public float randomWait;    // Asteroid nesnesinin doðma süresi

    int score;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI resetGameText;

    bool gameOverController = false;
    bool resetController = false;

    public static gameController instance = null;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    void Start()
    {
        score = 0;  // Oyun baþladýðýnda score 0 olarak baþlar
        scoreText.text = "Skor: " + score;  // Score deðiþkenin içindeki deðerleri scoreText içine yazar       
        StartCoroutine (createAsteroid());     //  Asteroid oluþturur  
    }

     void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) && resetController) // Oyunu yeniden baþlatma aktif ise ve "R" tuþuna basýlmýþsa oyun yeniden baþlar
        {
            SceneManager.LoadScene("Level1");   // Level 1 sahnesi yeniden açar
        }    
    }

    IEnumerator createAsteroid()
    {
        yield return new WaitForSeconds(randomWait);    // Belirtilen saniyeden sonra döngüye girsin
        while (true)    // Sonsuz döngü oluþturur
        {
            for(int i = 0; i < 10; i++) // 10 adet Asteroid oluþturur
            {
                Vector3 vec = new Vector3(Random.Range(-randomPos.x, randomPos.x), 0, randomPos.z);
                // Oluþturulacak Asteroid nesneleri random pozisyon deðerleri 
                Instantiate(asteroid, vec, Quaternion.identity);
                // Asteroid nesneleri belirtilen random pozisyonda oluþturulur
                yield return new WaitForSeconds(randomSpeed);   // Belirtilen saniyeden sonra döngüden çýk ve yeniden Asteroid oluþtursun
            }          

            if (gameOverController)
            {   // Eðer gameOverController true ise                
                resetController = true; // Oyunu yeniden baþlatmak aktif hale gelir
                break;  // Eðer oyun bittiyse döngüyü bitir
            }
            yield return new WaitForSeconds(randomWait);    // Belirtilen saniyeden sonra döngüden çýk
        }
        
    }

    public void scoreIcreases(int incomingScore)    // Dýþardan deðer alýr
    {   // Fonksiyon her çalýþtðýnda score belitilen "incomingScore" deðer kadar score deðiþkenine ekler
        score += incomingScore;
        scoreText.text = "Skor: " + score;
    }

    public void gameOver()
    {   // Player nesnesi yandýðý zman çalýþýr
        gameOverText.text = "Game Over";
        scoreText.transform.position = new Vector3(240,600,0);  // scoreText yazýsý belirtilen pozisyon deðerlierini alýr
        resetGameText.text = "Yeniden baþlatmak için 'R' tuþuna basýnýz...";
        gameOverController = true;
    }
}
