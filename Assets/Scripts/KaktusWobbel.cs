using UnityEngine;

public class KaktusWobbel : MonoBehaviour
{
    public float wobbleSpeed = 2f;
    public float wobbleAmount = 10f;

    Quaternion startRotation;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startRotation = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        float wobble = Mathf.Sin(Time.time * wobbleSpeed) * wobbleAmount;
        transform.rotation = startRotation * Quaternion.Euler(wobble, 0f, 0f);
    }
}
