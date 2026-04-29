using UnityEngine;

public class Coin : MonoBehaviour
{
    int coinCount;

    private void Awake()
    {
        //coinCount = <Collectables>.coinsCollected;
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
