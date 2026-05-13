using TMPro;
using UnityEngine;

public class Collectables : MonoBehaviour
{
    public TextMeshProUGUI coinText;

    private int Coin = 0;

    [SerializeField] AudioClip coinGet;
    AudioSource audiosource;

    private void Awake()
    {
        audiosource = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Collectable")
        {
            AddCoin();
            coinText.text = "Coins: " + Coin.ToString();
            audiosource.PlayOneShot(coinGet);
            //Debug.Log(Coin);
            Destroy(other.gameObject);
        }
    }
    public void AddCoin()
    {
        Coin++;

        if (Coin == 30)
        {
            //insert code for 'good job' message here
        }

    }
}


