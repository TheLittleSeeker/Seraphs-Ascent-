using UnityEngine;
using UnityEngine.Audio;

public class Projectile : MonoBehaviour
{

    [SerializeField] float speed = 30f;

    //[SerializeField] ParticleSystem killParticles;
    [SerializeField] GameObject coin;

    [SerializeField] AudioClip enemyDeath;
    AudioSource audiosource;


    //[SerializeField] GameObject enemy;


    Rigidbody rb;

    //public Vector3 coinSpawn;


    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        audiosource = GetComponent<AudioSource>();
    }
    private void Start()
    {
        rb.linearVelocity = new Vector3(transform.localScale.x * speed, 0f);

    }

    private void OnCollisionEnter(Collision collision)
    {
        //coinSpawn = new Vector3 (Collider.transform.position);
        switch (collision.gameObject.tag)
        {
            case "Unfriendly":
                //EnemyDeathSequence();
                Destroy(collision.gameObject);
                Instantiate(coin, transform.position, Quaternion.identity);
                break;
        }
        Destroy(this.gameObject);
    }
    private void EnemyDeathSequence()
    {
        //audiosource.PlayOneShot(enemyDeath);
        //killParticles.Play();
    }
}
