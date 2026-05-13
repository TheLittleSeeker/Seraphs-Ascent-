using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject prefab;

    //public GameObject[] enemy;


    public void Awake()
    {
        instance = this;
    }

    public void Update()
    {
        Check();
    }

    public void Check()
    {
        //if (enemy.Destroyed)
        //{
        //    Instantiate(prefab, enemy.Position, Quaternion.identity);
        //}
    }



    ////[SerializeField] TMP_Text coinText;
    ////[SerializeField] GameObject winMsg;

    //private int Coin = 0;

    //public TextMeshProUGUI coinText;

    //const string COINS_COLLECTED_STRING = "Coins: ";

    ////public void AdjustCoinCount(int count)
    ////{
    ////    coins += count;

    ////    coinsText.text = COINS_COLLECTED_STRING + coins.ToString();
    ////}

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.transform.tag == "Collectable")
    //    {
    //        //AddCoin();
    //        Coin++;
    //        coinText.text = "Coin: " + Coin.ToString();
    //        Debug.Log(Coin);
    //        Destroy(other.gameObject);
    //    }
    //}
    //public void AddCoin()
    //{
    //    Coin++;

    //    if (Coin == 30)
    //    {
    //        //insert code for 'good job' message here
    //    }

    //}






}
