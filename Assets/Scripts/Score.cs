using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    public int score;
    private TextMeshProUGUI _scoreText;

    private void Start()
    {
        _scoreText = gameObject.GetComponent<TextMeshProUGUI>();
    }

    public void IncreaseScore(int amount)
    {
        score += amount;
        _scoreText.text = score.ToString();
    }
    
}
