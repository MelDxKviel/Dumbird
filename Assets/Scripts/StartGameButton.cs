using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGameButton : MonoBehaviour
{
    public int gameStartSceneIndex;
    // Start is called before the first frame update
    public void StartGame()
    {
        SceneManager.LoadScene(gameStartSceneIndex);
    }
    
}
