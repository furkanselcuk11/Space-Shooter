using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explosionDestroy : MonoBehaviour
{
    
    void Start()
    {
        Destroy(gameObject, 3); // Nesneyi 3 saniye sonra yok eder
    }

    
}
