using UnityEngine;

public class Collectible : MonoBehaviour
{
    public float rotationSpeed;
    public GameObject onCollectEffect;
    public AudioClip onCollectSound;
    void Start()
    {
    }

    void Update()
    {
        // Rotation
        transform.Rotate(0, rotationSpeed,0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Play sound at this object's position
            if (onCollectSound != null)
                AudioSource.PlayClipAtPoint(onCollectSound, transform.position);

            // Show collection VFX
            if (onCollectEffect != null)
                Instantiate(onCollectEffect, transform.position, transform.rotation);

            //Destroy the collectible
            Destroy(gameObject);
        }
    }
}