using UnityEngine;

public class Coin : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //Debug.Log("You found " + coinsCollected + " coins!");
            Destroy(gameObject);
        }
    }

}
