using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Movement : MonoBehaviour

{
   [SerializeField] float mainThrust = 100f;
   [SerializeField] float rotationThrust = 50f;
   Rigidbody rb;
   AudioSource audioSource;   
   
   // Start is called before the first frame update
   void Start()
   {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
   }

   // Update is called once per frame
   void Update()
   {
       ProcessThrust();
       ProcessRotation();
   }

   void ProcessThrust()
   {
       if (Input.GetKey(KeyCode.Space))
       {
           rb.AddRelativeForce(Vector3.up * mainThrust * Time.deltaTime);
           if(!audioSource.isPlaying)
           { 
                audioSource.Play();
           }
       }   
       else
       {
            audioSource.Stop();
       }
   }

    void ProcessRotation()
   {
     if (Input.GetKey(KeyCode.A))
       {
           ApplyRotation(rotationThrust);
       }
       else if (Input.GetKey(KeyCode.D))
       {
          ApplyRotation(-rotationThrust);
       }
    }

    void ApplyRotation(float rotationThisFrame)
        {
            rb.freezeRotation = true; // Freezing roataion so we can manually rotate
            transform.Rotate(Vector3.forward * rotationThisFrame * Time.deltaTime);
            rb.freezeRotation = false; // Unfreeezing so the physisc system can take over
        }       
}
