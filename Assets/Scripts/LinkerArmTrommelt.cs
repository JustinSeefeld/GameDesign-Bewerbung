using TMPro;
using UnityEngine;


public class LinkerArmTrommelt : MonoBehaviour
{
   
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    private AudioSource audiosource;
    void Update()
    {
        float hitU = Input.GetAxis("Fire2");
        if (Input.GetButtonDown("Fire2"))
        {
            transform.Rotate(0, 0, 26);
            audiosource = gameObject.GetComponent<AudioSource>();
            
            if (Input.GetButtonDown("Fire2"))
            {
                audiosource.Play();
            } //play Audio Sound
        }
        else if (Input.GetButtonUp("Fire2"))
        {
            transform.Rotate(0,0,-26);
        }

        float hitI = Input.GetAxis("Fire4");
        if (Input.GetButtonDown("Fire4"))
        {
            transform.Rotate(0, 0, 26);
            //play Audio Sound
        }
        else if (Input.GetButtonUp("Fire4"))
        {
            transform.Rotate(0, 0, -26);
        }
    }
}
