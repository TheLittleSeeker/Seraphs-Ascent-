using TMPro;
using UnityEngine;

public class Collectables : MonoBehaviour
{
    public TextMeshProUGUI coinText;

    private int Coin = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Collectable")
        {
            AddCoin();
            coinText.text = "Coins: " + Coin.ToString();
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


