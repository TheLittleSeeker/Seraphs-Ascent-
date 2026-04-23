using UnityEngine;

public class Enemy_Health : MonoBehaviour
{

    [SerializeField] GameObject explosionVFX;
    [SerializeField] int starthealth = 3;

    //GameManager gameManager;
    int currenthealth;

    private void Awake()
    {
        currenthealth = starthealth;
    }

    private void Start()
    {
        //gameManager = FindFirstObjectByType<GameManager>();
        //gameManager.AdjustEnemyCount(1);
    }
    public void TakeDamage(int damageamount)
    {
        currenthealth -= damageamount;
        if (currenthealth <= 0)
        {
            SelfDestruct();
        }
    }

    public void SelfDestruct()
    {
        //gameManager.AdjustEnemyCount(-1);
        Instantiate(explosionVFX, transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }
}
