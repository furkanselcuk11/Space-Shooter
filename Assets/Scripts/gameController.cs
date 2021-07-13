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
    public float randomSpeed;   // Asteroid nesnesinin do�ma h�z�
    public float randomWait;    // Asteroid nesnesinin do�ma s�resi

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
        score = 0;  // Oyun ba�lad���nda score 0 olarak ba�lar
        scoreText.text = "Skor: " + score;  // Score de�i�kenin i�indeki de�erleri scoreText i�ine yazar       
        StartCoroutine (createAsteroid());     //  Asteroid olu�turur  
    }

     void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) && resetController) // Oyunu yeniden ba�latma aktif ise ve "R" tu�una bas�lm��sa oyun yeniden ba�lar
        {
            SceneManager.LoadScene("Level1");   // Level 1 sahnesi yeniden a�ar
        }    
    }

    IEnumerator createAsteroid()
    {
        yield return new WaitForSeconds(randomWait);    // Belirtilen saniyeden sonra d�ng�ye girsin
        while (true)    // Sonsuz d�ng� olu�turur
        {
            for(int i = 0; i < 10; i++) // 10 adet Asteroid olu�turur
            {
                Vector3 vec = new Vector3(Random.Range(-randomPos.x, randomPos.x), 0, randomPos.z);
                // Olu�turulacak Asteroid nesneleri random pozisyon de�erleri 
                Instantiate(asteroid, vec, Quaternion.identity);
                // Asteroid nesneleri belirtilen random pozisyonda olu�turulur
                yield return new WaitForSeconds(randomSpeed);   // Belirtilen saniyeden sonra d�ng�den ��k ve yeniden Asteroid olu�tursun
            }          

            if (gameOverController)
            {   // E�er gameOverController true ise                
                resetController = true; // Oyunu yeniden ba�latmak aktif hale gelir
                break;  // E�er oyun bittiyse d�ng�y� bitir
            }
            yield return new WaitForSeconds(randomWait);    // Belirtilen saniyeden sonra d�ng�den ��k
        }
        
    }

    public void scoreIcreases(int incomingScore)    // D��ardan de�er al�r
    {   // Fonksiyon her �al��t��nda score belitilen "incomingScore" de�er kadar score de�i�kenine ekler
        score += incomingScore;
        scoreText.text = "Skor: " + score;
    }

    public void gameOver()
    {   // Player nesnesi yand��� zman �al���r
        gameOverText.text = "Game Over";
        scoreText.transform.position = new Vector3(240,600,0);  // scoreText yaz�s� belirtilen pozisyon de�erlierini al�r
        resetGameText.text = "Yeniden ba�latmak i�in 'R' tu�una bas�n�z...";
        gameOverController = true;
    }
}
