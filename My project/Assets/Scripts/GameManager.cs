using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class GameManager : MonoBehaviour
{
    [SerializeField] TMP_Text coinsCollectedText;
    //[SerializeField] GameObject winMsg;

    int coinsCollected = 0;
    
    public Collectables shared;

    const string COINS_COLLECTED_STRING = "Coins: ";

    public void AdjustCoinCount(int count)
    {
        coinsCollected += count;

        coinsCollectedText.text = COINS_COLLECTED_STRING + coinsCollected.ToString();
    }







}
