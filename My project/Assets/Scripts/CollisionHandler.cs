using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        switch (other.gameObject.tag)
        {
            case "Finish":
                //Debug.Log("Everything is awesome!");
                LoadNextScene();
                break;
            case "Unfriendly":
                //Debug.Log("Everything is NOT awesome!");
                ReloadScene();
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
