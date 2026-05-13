using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] float rotationSpeed = 100f;

    private void Awake()
    {
        //coinCount = <Collectables>.coinsCollected;
    }

    void Update()
    {
        transform.Rotate(0f, rotationSpeed * Time.deltaTime, 0f);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //GetComponent<Collectables>;
            Destroy(gameObject);
        }
    }

}
