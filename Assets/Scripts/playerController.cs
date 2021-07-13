using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    Rigidbody rb;
    float horizontal=0;
    float vertical=0;
    public float playerSpeed;   // Player hýzý

    Vector3 vec;

    public float minX;  // Min x sýnýrý
    public float maxX;  // Max x sýnýrý
    public float minZ;  // Min z sýnýrý
    public float maxZ;  // Max z sýnýrý
    public float slope; // Player eðim deðeri

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
        if (Input.GetButton("Fire1")&& Time.time>fireTime)  // Oyun baþadýðýnda zaman 0'dan büyükse ateþ et
        {   // Kurþun atýlduðýnda
            fireTime = Time.time + whileFire;   // 1 saniye aralýklar ateþ eder
            Instantiate(bullet, leadOutlet.position, Quaternion.identity);  // Kurþun nesnesini oluþturur
            playerAudio.Play(); // Kurþun sesini aktif eder
        }
    }
    void FixedUpdate()
    {
        // Player hareket
        horizontal = Input.GetAxis("Horizontal");   // Yatayda hareket edeceði yön deðerini alýr
        vertical = Input.GetAxis("Vertical");   // Dikeyde hareket edeceði yön deðerini alýr
        vec = new Vector3(horizontal,0,vertical);   // Alýnan yön deðerlerini "vec" deðiþkenine atar

        rb.velocity = vec*playerSpeed;  // Alýnan deðerlere göre hareket eder

        // Nesnenin belli pozisyon dýþýna çýkmamasý (Ekran dýþýna)
        rb.position = new Vector3
            (
            Mathf.Clamp(rb.position.x,minX,maxX),   // Player X ekseni üzerinde belirtilen deðerler dýþýna çýkamaz
            0.0f, 
            Mathf.Clamp(rb.position.z,minZ,maxZ)    // Player Z ekseni üzerinde belirtilen deðerler dýþýna çýkamaz
            );
        // Nesneyi sað-sol yaparaken eðme
        rb.rotation = Quaternion.Euler(0, 0, rb.velocity.x * -slope);
            
    }
    
}
