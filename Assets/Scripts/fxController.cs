using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fxController : MonoBehaviour
{
    Rigidbody rb;
    public float fxSpeed;   // Kurþunlarýn hýzý
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = transform.forward*fxSpeed;   // Kurþun nesnesi ileri hareket eder
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "LeadBorder")
        {    // Kurþunlar eðer "LeadBorder"a temas ederse yok et  
            Destroy(gameObject);    // Scriptin baðlý olduðu nesne "LeadBorder"a temas ederse yok et 
        }
    }

}
