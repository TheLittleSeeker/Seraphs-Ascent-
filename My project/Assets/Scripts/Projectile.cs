using UnityEngine;
using UnityEngine.Audio;

public class Projectile : MonoBehaviour
{

    [SerializeField] float speed = 30f;

    [SerializeField] ParticleSystem collectParticles;


    [SerializeField] AudioClip collect;

    AudioSource audiosource;



    Rigidbody rb;


    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void Start()
    {
        rb.linearVelocity = new Vector3(transform.localScale.x * speed, 0f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Unfriendly":
                EnemyDeathSequence();
                Destroy(collision.gameObject);
                break;
        }

        Destroy(this.gameObject);
    }

    private void EnemyDeathSequence()
    {
        audiosource.PlayOneShot(collect);
        collectParticles.Play();
    }
}
