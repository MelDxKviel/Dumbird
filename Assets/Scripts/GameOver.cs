using TMPro;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public SpawnEnemies spawnEnemies;
    public GameObject gameOverMenu;
    public GameObject inGameControls;
    
    [Header("Score")]
    public GameObject score;
    public TextMeshProUGUI finalScore;
    public TextMeshProUGUI newRecord;

    public void OnGameOver()
    {
        var result = score.GetComponent<Score>().score;
        Time.timeScale = 0f;
        spawnEnemies.DisableSpawning();
        DestroyAllGameObjects();
        inGameControls.SetActive(false);
        gameOverMenu.SetActive(true);
        score.gameObject.SetActive(false);
        finalScore.text = $"Your score: {result}";
        if (PlayerPrefs.GetInt("HighScore") < result)
        {
            PlayerPrefs.SetInt("HighScore", result);
            newRecord.gameObject.SetActive(true);
        }
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
