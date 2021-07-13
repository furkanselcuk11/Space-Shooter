using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class asteroidCntroller : MonoBehaviour
{
    Rigidbody physics;
    public float rotateSpeed;
    public float asteroidSpeed;

    public GameObject explosion;
    public GameObject palyerExplosion;

    GameObject GameController;
    gameController controllerCode;
    void Start()
    {
        physics = GetComponent<Rigidbody>();
        physics.angularVelocity = Random.insideUnitSphere*rotateSpeed;  // Obje random þekilde döner
        physics.velocity = transform.forward * -asteroidSpeed;   // Nesne ileri hareket eder

        GameController = GameObject.FindGameObjectWithTag("GameController");
        controllerCode = GameController.GetComponent<gameController>();
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag== "Lightning") 
        {            
            Destroy(gameObject);    // Kodun baðlý olduðu objeyi yok eder - Asteroid'i yok eder
            Instantiate(explosion, transform.position, transform.rotation); // Eðer çarpýlan nesne Asteroid ise patlama efekti oluþtur
            controllerCode.scoreIcreases(10);
        }
        if (other.tag == "Player")
        {            
            Destroy(other.gameObject);    // Kodun baðlý olduðu objeye çarpan objeleri yok eder - Player'ý yok eder   
            Instantiate(palyerExplosion, other.transform.position, other.transform.rotation);   // Eðer çarpýlan nesne Player ise patlama efekti oluþtur
            controllerCode.gameOver();  // Oyun bitti fonk. çalýþýr
        }
        if (other.tag == "Asteroid")
        { 
            Destroy(gameObject);    // Kodun baðlý olduðu objeyi yok eder - Harita dýþýna çýkan Asteroid'i yok eder
            
        }
    }

}
