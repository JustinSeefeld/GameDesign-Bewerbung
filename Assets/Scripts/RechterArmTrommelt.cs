using UnityEngine;


public class Nächsterversuch : MonoBehaviour
{
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    private AudioSource audiosource;

    void Update()
    {
        
        float hitW = Input.GetAxis("Fire1");
        if (Input.GetButtonDown("Fire1"))
        {
            transform.Rotate(0, 0, 27);
            audiosource = gameObject.GetComponent<AudioSource>();
            
            if (Input.GetButtonDown("Fire1"))
            {
                audiosource.Play();
            }

        }
        else if (Input.GetButtonUp("Fire1"))
        {
            transform.Rotate(0, 0, -27);
        }

        float hitE = Input.GetAxis("Fire3");
        if (Input.GetButtonDown("Fire3"))
        {
            transform.Rotate(0, 0, 27);
            //play Audio Sound
        }
        else if (Input.GetButtonUp("Fire3"))
        {
            transform.Rotate(0, 0, -27);
        }
    }
}
