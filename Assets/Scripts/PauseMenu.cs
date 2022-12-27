using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    
    public GameObject pauseMenuUI;
    public GameObject inGameControls;
    
    public bool gameIsPaused = false;
    
    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        inGameControls.SetActive(false);
        Time.timeScale = 0f;
        gameIsPaused = true;
    }
    
    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        inGameControls.SetActive(true);
        Time.timeScale = 1f;
        gameIsPaused = false;
    }
}
