using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    public void LoadNextLevel()
    {
        int currentIndex = SceneManager.GetActiveScene().buildIndex;
        currentIndex++;
        if(currentIndex >= SceneManager.sceneCountInBuildSettings)
        {
            currentIndex = 0;
        }
        SceneManager.LoadScene(currentIndex);
    }
}
