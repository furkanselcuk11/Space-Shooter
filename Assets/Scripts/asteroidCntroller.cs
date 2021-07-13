using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class asteroidCntroller : MonoBehaviour
{
    Rigidbody rb;
    public float rotateSpeed;   // Dönme hýzý
    public float asteroidSpeed; // Asteroid hýzý

    public GameObject explosion;    // Asteroid patlama efekti
    public GameObject palyerExplosion;  // Player patlama efekti
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.angularVelocity = Random.insideUnitSphere*rotateSpeed;  // Nesne random þekilde döner
        rb.velocity = transform.forward * -asteroidSpeed;   // Nesne geriye doðru hareket eder
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag== "Lightning")
        {   // Temas edilen nesnenin tagý "Lightning" ise          
            Destroy(gameObject);    // Scriptin baðlý olduðu nesneyi yok eder - Asteroid'i yok eder
            Instantiate(explosion, transform.position, transform.rotation); // Asteroid patlama efekti oluþtur
            gameController.instance.scoreIcreases(10);  // Her asteroid vurulmasýnda Score 10 puan artar
        }
        if (other.tag == "Player")
        {   // Temas edilen nesnenin tagý "Player" ise          
            Destroy(other.gameObject);    // Scriptin baðlý olduðu nesneye temas eden nesneyi yok eder - Player'ý yok eder   
            Instantiate(palyerExplosion, other.transform.position, other.transform.rotation);   // Player patlama efekti oluþtur
            gameController.instance.gameOver();  // "gameController" üzerinden "gameOver" fonksiyonu çalýþýr
        }
        if (other.tag == "Asteroid")
        {   // Temas edilen nesnenin tagý "Asteroid" ise  
            Destroy(gameObject);    // Kodun baðlý olduðu nesneyi yok eder - Harita dýþýna çýkan Asteroid'i yok eder
            
        }
    }

}
