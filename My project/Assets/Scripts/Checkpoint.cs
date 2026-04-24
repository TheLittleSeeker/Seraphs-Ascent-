using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Respawn respawn = other.GetComponent<Respawn>();
        }

        //if (respawn != null)

    }
}
