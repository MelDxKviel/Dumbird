using TMPro;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public SpawnEnemies spawnEnemies;
    public GameObject gameOverMenu;
    public GameObject inGameControls;
    public TextMeshProUGUI score;
    public TextMeshProUGUI finalScore;

    public void OnGameOver()
    {
        Time.timeScale = 0f;
        spawnEnemies.DisableSpawning();
        DestroyAllEnemies();
        DestroyAllBullets();
        inGameControls.SetActive(false);
        gameOverMenu.SetActive(true);
        score.gameObject.SetActive(false);
        finalScore.text = $"Your score: {score.text}";
    }
    
    void DestroyAllEnemies()
    {
        GameObject[] existingEnemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in existingEnemies)
        {
            Destroy(enemy);
        }
    }
    
    void DestroyAllBullets()
    {
        GameObject[] existingEnemies = GameObject.FindGameObjectsWithTag("Bullet");
        foreach (GameObject bullet in existingEnemies)
        {
            Destroy(bullet);
        }
    }
}
