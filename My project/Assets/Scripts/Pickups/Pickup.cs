using UnityEngine;

public abstract class Pickup : MonoBehaviour
{
    [SerializeField] float rotationSpeed = 20f;
    const string PLAYER_TAG = "Player";


    void Update()
    {
        transform.Rotate(0f, rotationSpeed * Time.deltaTime, 0f);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(PLAYER_TAG))
        {
            ActivePower activePower = other.GetComponentInChildren<ActivePower>();
            OnPickup(activePower);
            Destroy(this.gameObject);
        }
    }

    protected abstract void OnPickup(ActivePower activePower);



}
