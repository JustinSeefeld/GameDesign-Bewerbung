using Unity.Mathematics;
using UnityEngine;

public class PalmenWedeln : MonoBehaviour
{
    public float wedelSpeed = 1f;
    public float wedelAmount = 2f;
    
    private quaternion startRotation;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startRotation = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        float wedel = Mathf.Sin(Time.time * wedelSpeed) * wedelAmount;
        transform.rotation = startRotation * Quaternion.Euler(0, 0, wedel);
    }
}
