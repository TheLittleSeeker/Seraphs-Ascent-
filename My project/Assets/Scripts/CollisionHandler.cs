using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] ParticleSystem successParticles;
    private void OnCollisionEnter(Collision other)
    {
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
        successParticles.Play();
        GetComponent<movement>().enabled = false;
        Invoke("LoadNextScene", 2f);
    }
    private void StartDeathSequence()
    {
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
