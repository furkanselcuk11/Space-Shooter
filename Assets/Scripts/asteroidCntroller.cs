using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class asteroidCntroller : MonoBehaviour
{
    Rigidbody rb;
    public float rotateSpeed;   // D�nme h�z�
    public float asteroidSpeed; // Asteroid h�z�

    public GameObject explosion;    // Asteroid patlama efekti
    public GameObject palyerExplosion;  // Player patlama efekti
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.angularVelocity = Random.insideUnitSphere*rotateSpeed;  // Nesne random �ekilde d�ner
        rb.velocity = transform.forward * -asteroidSpeed;   // Nesne geriye do�ru hareket eder
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag== "Lightning")
        {   // Temas edilen nesnenin tag� "Lightning" ise          
            Destroy(gameObject);    // Scriptin ba�l� oldu�u nesneyi yok eder - Asteroid'i yok eder
            Instantiate(explosion, transform.position, transform.rotation); // Asteroid patlama efekti olu�tur
            gameController.instance.scoreIcreases(10);  // Her asteroid vurulmas�nda Score 10 puan artar
        }
        if (other.tag == "Player")
        {   // Temas edilen nesnenin tag� "Player" ise          
            Destroy(other.gameObject);    // Scriptin ba�l� oldu�u nesneye temas eden nesneyi yok eder - Player'� yok eder   
            Instantiate(palyerExplosion, other.transform.position, other.transform.rotation);   // Player patlama efekti olu�tur
            gameController.instance.gameOver();  // "gameController" �zerinden "gameOver" fonksiyonu �al���r
        }
        if (other.tag == "Asteroid")
        {   // Temas edilen nesnenin tag� "Asteroid" ise  
            Destroy(gameObject);    // Kodun ba�l� oldu�u nesneyi yok eder - Harita d���na ��kan Asteroid'i yok eder
            
        }
    }

}
