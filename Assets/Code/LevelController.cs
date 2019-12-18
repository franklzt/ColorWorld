using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    public int levelIndex = 0;

    public void LoadNextLevel()
    {
        SceneManager.LoadScene(levelIndex);
    }
}
