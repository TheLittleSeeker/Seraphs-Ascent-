using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] ParticleSystem successParticles;

    [SerializeField] AudioClip success;
    [SerializeField] AudioClip death;

    AudioSource audiosource;

    bool isControllable = true;

    private void Start()
    {
        if (successParticles.isPlaying)
        {
            successParticles.Stop();
        }
    }
    private void Awake()
    {
        audiosource = GetComponent<AudioSource>();
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
                StartDeathSequence();
                break;
            case "Collectable":
                Debug.Log("You found a coin!");
                break;
            case "Pickup":
                Debug.Log("You got a pickup!");
                break;
            default:
                Debug.Log("Something happens");
                break;
        }
    }

    private void StartSuccessSequence()
    {
        audiosource.PlayOneShot(success);
        successParticles.Play();
        GetComponent<movement>().enabled = false;
        Invoke("LoadNextScene", 2f);
        
    }
    private void StartDeathSequence()
    {
        audiosource.PlayOneShot(death);
        GetComponent<movement>().enabled = false;
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
}
