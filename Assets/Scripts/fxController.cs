using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fxController : MonoBehaviour
{
    Rigidbody rb;
    public float fxSpeed;   // Kur�unlar�n h�z�
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = transform.forward*fxSpeed;   // Kur�un nesnesi ileri hareket eder
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "LeadBorder")
        {    // Kur�unlar e�er "LeadBorder"a temas ederse yok et  
            Destroy(gameObject);    // Scriptin ba�l� oldu�u nesne "LeadBorder"a temas ederse yok et 
        }
    }

}
