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
        DestroyAllGameObjects();
        inGameControls.SetActive(false);
        gameOverMenu.SetActive(true);
        score.gameObject.SetActive(false);
        finalScore.text = $"Your score: {score.text}";
    }
    
    
    void DestroyAllGameObjects()
    {
        GameObject[] existingEnemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in existingEnemies)
        {
            Destroy(enemy);
        }
        
        GameObject[] existingBullets = GameObject.FindGameObjectsWithTag("Bullet");
        foreach (GameObject bullet in existingBullets)
        {
            Destroy(bullet);
        }
        
        GameObject[] existingBuffs = GameObject.FindGameObjectsWithTag("Buff");
        foreach (GameObject buff in existingBuffs)
        {
            Destroy(buff);
        }
    }
}
