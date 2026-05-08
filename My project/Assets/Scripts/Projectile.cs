using UnityEngine;

public class Projectile : MonoBehaviour
{

    [SerializeField] float speed = 30f;


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
        Destroy(this.gameObject);
    }
}
