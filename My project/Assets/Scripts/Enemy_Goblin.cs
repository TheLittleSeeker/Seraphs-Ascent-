using UnityEngine;
using UnityEngine.AI;

public class Enemy_Goblin : MonoBehaviour
{
    

    Rigidbody rb;

    NavMeshAgent agent;

    const string PLAYER_TAG = "Player";

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }


    void Start()
    {
        //player = FindFirstObjectByType<Rigidbody.>();
    }

    // Update is called once per frame
    void Update()
    {
        //if (!player) return;

        //agent.SetDestination(player.transform.position);
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.CompareTag(PLAYER_TAG))
    //    {
    //        EnemyHealth health = GetComponent<EnemyHealth>();
    //        health.SelfDestruct();
    //    }

    //}
}
