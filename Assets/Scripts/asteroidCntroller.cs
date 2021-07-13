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
        physics.angularVelocity = Random.insideUnitSphere*rotateSpeed;  // Obje random �ekilde d�ner
        physics.velocity = transform.forward * -asteroidSpeed;   // Nesne ileri hareket eder

        GameController = GameObject.FindGameObjectWithTag("GameController");
        controllerCode = GameController.GetComponent<gameController>();
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag== "Lightning") 
        {            
            Destroy(gameObject);    // Kodun ba�l� oldu�u objeyi yok eder - Asteroid'i yok eder
            Instantiate(explosion, transform.position, transform.rotation); // E�er �arp�lan nesne Asteroid ise patlama efekti olu�tur
            controllerCode.scoreIcreases(10);
        }
        if (other.tag == "Player")
        {            
            Destroy(other.gameObject);    // Kodun ba�l� oldu�u objeye �arpan objeleri yok eder - Player'� yok eder   
            Instantiate(palyerExplosion, other.transform.position, other.transform.rotation);   // E�er �arp�lan nesne Player ise patlama efekti olu�tur
            controllerCode.gameOver();  // Oyun bitti fonk. �al���r
        }
        if (other.tag == "Asteroid")
        { 
            Destroy(gameObject);    // Kodun ba�l� oldu�u objeyi yok eder - Harita d���na ��kan Asteroid'i yok eder
            
        }
    }

}
