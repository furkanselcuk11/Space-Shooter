using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fxController : MonoBehaviour
{
    Rigidbody physics;
    public float fxSpeed;
    void Start()
    {
        physics = GetComponent<Rigidbody>();
        physics.velocity = transform.forward*fxSpeed;   // Nesne ileri hareket eder
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "LeadBorder")
        {    // Kur�unlar e�er LeadBorder temas ederse yok et  
            Destroy(gameObject);    // Kodun ba�l� oldu�u objeye �arpan objeleri yok eder
        }
    }

}
