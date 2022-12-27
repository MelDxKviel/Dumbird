using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGameButton : MonoBehaviour
{
    public int gameStartSceneIndex;
    public void StartGame()
    {
        if (PlayerPrefs.GetInt("PlayedBefore") == 1 )
        {
            SceneManager.LoadScene(gameStartSceneIndex);
        }
        else
        {
            SceneManager.LoadScene(2);
            PlayerPrefs.SetInt("PlayedBefore", 1);
        }
    }
}
