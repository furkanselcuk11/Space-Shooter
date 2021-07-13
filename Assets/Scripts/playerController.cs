using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    Rigidbody rb;
    float horizontal=0;
    float vertical=0;
    public float playerSpeed;   // Player h�z�

    Vector3 vec;

    public float minX;  // Min x s�n�r�
    public float maxX;  // Max x s�n�r�
    public float minZ;  // Min z s�n�r�
    public float maxZ;  // Max z s�n�r�
    public float slope; // Player e�im de�eri

    float fireTime = 0; 
    public float whileFire = 0;
    public GameObject bullet;
    public Transform leadOutlet;

    AudioSource playerAudio;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        playerAudio = GetComponent<AudioSource>();
    }

     void Update()
    {
        if (Input.GetButton("Fire1")&& Time.time>fireTime)  // Oyun ba�ad���nda zaman 0'dan b�y�kse ate� et
        {   // Kur�un at�ldu��nda
            fireTime = Time.time + whileFire;   // 1 saniye aral�klar ate� eder
            Instantiate(bullet, leadOutlet.position, Quaternion.identity);  // Kur�un nesnesini olu�turur
            playerAudio.Play(); // Kur�un sesini aktif eder
        }
    }
    void FixedUpdate()
    {
        // Player hareket
        horizontal = Input.GetAxis("Horizontal");   // Yatayda hareket edece�i y�n de�erini al�r
        vertical = Input.GetAxis("Vertical");   // Dikeyde hareket edece�i y�n de�erini al�r
        vec = new Vector3(horizontal,0,vertical);   // Al�nan y�n de�erlerini "vec" de�i�kenine atar

        rb.velocity = vec*playerSpeed;  // Al�nan de�erlere g�re hareket eder

        // Nesnenin belli pozisyon d���na ��kmamas� (Ekran d���na)
        rb.position = new Vector3
            (
            Mathf.Clamp(rb.position.x,minX,maxX),   // Player X ekseni �zerinde belirtilen de�erler d���na ��kamaz
            0.0f, 
            Mathf.Clamp(rb.position.z,minZ,maxZ)    // Player Z ekseni �zerinde belirtilen de�erler d���na ��kamaz
            );
        // Nesneyi sa�-sol yaparaken e�me
        rb.rotation = Quaternion.Euler(0, 0, rb.velocity.x * -slope);
            
    }
    
}
