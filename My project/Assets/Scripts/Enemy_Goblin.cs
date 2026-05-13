using UnityEngine;
using UnityEngine.AI;

public class Enemy_Goblin : MonoBehaviour
{
    //public bool Destroyed{ get; set; }
    //public Vector3 Position { get; set; }
    //[SerializeField] GameObject coin;

    [SerializeField] AudioClip enemyDeath;
    AudioSource audiosource;

    private void Awake()
    {
        audiosource = GetComponent<AudioSource>();
    }

    private void OnDestroy()
    {
        //Position = transform.position;
        //Destroyed = true;
        //audiosource.PlayOneShot(enemyDeath);
        //Instantiate(coin, transform.position, Quaternion.identity);
    }




    void Start()
    {
    }


    void Update()
    {

    }

}
