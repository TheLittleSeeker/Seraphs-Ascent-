using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] ParticleSystem successParticles;
    [SerializeField] ParticleSystem deathParticles;


    [SerializeField] AudioClip success;
    [SerializeField] AudioClip death;

    AudioSource audiosource;

    public float coinCount = 0;
    //const string PLAYER_TAG = "Player";

    bool isControllable = true;

    private void Start()
    {
        if (successParticles.isPlaying)
        {
            successParticles.Stop();
        }

        if (deathParticles.isPlaying)
        {
            deathParticles.Stop();
        }
    }
    private void Awake()
    {
        audiosource = GetComponent<AudioSource>();
        GetComponent<Player_Health>();
    }

    private void OnCollisionEnter(Collision other)
    {
        if (!isControllable) { return; }

        switch (other.gameObject.tag)
        {
            case "Finish":
                StartSuccessSequence();
                break;
            case "Unfriendly":
                //if (Player_Health <= 0)
                //{
                    StartDeathSequence();
                //}
                break;
            case "Collectable":
                Debug.Log("You found a coin!");
                //if (other.CompareTag(PLAYER)
                //Destroy(gameObject);
                break;
            case "Pickup":
                Debug.Log("You got a pickup!");
                break;
            case "JumpableWall":
                //Debug.Log("You're touching a wall");
                //default:
                //    Debug.Log("Something happens");
                break;
        }
    }


    private void StartSuccessSequence()
    {
        audiosource.PlayOneShot(success);
        successParticles.Play();
        GetComponent<Movement>().enabled = false;
        Invoke("LoadNextScene", 2f);
        
    }
    private void StartDeathSequence()
    {
        audiosource.PlayOneShot(death);
        deathParticles.Play();
        GetComponent<Movement>().enabled = false;
        Invoke("ReloadScene", 2f);
    }
    void ReloadScene()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentScene);
    }

    void LoadNextScene()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        int nextScene = currentScene + 1;
        if (nextScene == SceneManager.sceneCountInBuildSettings)
        {
            nextScene = 0;
        }
        SceneManager.LoadScene(nextScene);
    }

    //public void CoinsCollected(int count)
    //{
    //    coinCount += count;
    //}
}
