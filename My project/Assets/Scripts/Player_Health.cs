using UnityEngine;

public class Player_Health : MonoBehaviour
{
    [SerializeField] int starthealth = 3;
    public int currenthealth;
    //int gameOverPriority = 20;
    //[SerializeField] Cinemachine.CinemachineVirtualCamera gameOverCamera;
    //[SerializeField] Transform weaponCamera;
    //[SerializeField] GameObject gameOverContainer;
    //[Range(1, 10)][SerializeField] Image[] healthBars; //Didn't work at first, needed to add "Using UnityEngine.UI;"

    private void Awake()
    {
        currenthealth = starthealth;
        //AdjustHealthUI();
    }

    public void TakeDamage(int damageamount)
    {
        currenthealth -= damageamount;
        //AdjustHealthUI();
        //if (currenthealth <= 0)
        //{
        //    //weaponCamera.parent = null;
        //    //gameOverCamera.Priority = gameOverPriority;
        //    //PlayerGameOver();
        //}
    }

    //private void AdjustHealthUI()
    //{
    //    for (int i = 0; i < healthBars.Length; i++)

    //        if (i < currenthealth)
    //        {
    //            healthBars[i].gameObject.SetActive(true);
    //        }
    //        else
    //        {
    //            healthBars[i].gameObject.SetActive(false);
    //        }
    //}
}
