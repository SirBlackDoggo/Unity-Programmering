using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{   
    void OnCollisionEnter(Collision other)
    {
         switch (other.gameObject.tag)
        {
            case "Respawn":
                Debug.Log("This is were you spawn, when you fail the mission");
                break;
            case "Finish":
                LoadNextLevel();
                break;
            case "Fuel":
                Debug.Log("You Picked up fuel");
                break;
            default:
                ReloadLevel();
                break;
        }
    }

        void LoadNextLevel()
        {
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex; 
            int nextSceneIndex = currentSceneIndex + 1;
            if (nextSceneIndex == SceneManager.sceneCountInBuildSettings)
            {
            nextSceneIndex = 0;
            }
            SceneManager.LoadScene(nextSceneIndex);
        }

    void ReloadLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
}
