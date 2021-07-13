using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    Rigidbody physics;
    float horizontal=0;
    float vertical=0;
    public float playerSpeed;

    Vector3 vec;

    public float minX;
    public float maxX;
    public float minZ;
    public float maxZ;
    public float slope;

    float fireTime = 0;
    public float whileFire = 0;
    public GameObject bullet;
    public Transform leadOutlet;

    AudioSource playerAudio;
    void Start()
    {
        physics = GetComponent<Rigidbody>();
        playerAudio = GetComponent<AudioSource>();
    }

     void Update()
    {
        if (Input.GetButton("Fire1")&& Time.time>fireTime)  // Oyun baþadýðýnda zaman 0'dan büyükse ateþ et
        {
            fireTime = Time.time + whileFire;   // 1 saniye aralýklar ateþ eder
            //Instantiate(object,pozisyon,rotasyon) - yeni bir obje ekler ve konumunu belirler
            Instantiate(bullet, leadOutlet.position, Quaternion.identity);
            playerAudio.Play();
        }
    }
    void FixedUpdate()
    {
        // Player hareket
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        vec = new Vector3(horizontal,0,vertical);

        physics.velocity = vec*playerSpeed;

        // Nesnenin belli pozisyon dýþýna çýkmamasý (Ekran dýþýna)
        physics.position = new Vector3
            (
            Mathf.Clamp(physics.position.x,minX,maxX),
            0.0f, 
            Mathf.Clamp(physics.position.z,minZ,maxZ)
            );
        // Nesneyi sað-sol yaparaken eðme
        physics.rotation = Quaternion.Euler(0, 0, physics.velocity.x * -slope);
            
    }
    
}
