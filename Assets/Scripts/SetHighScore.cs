using TMPro;
using UnityEngine;

public class SetHighScore : MonoBehaviour
{
    void Start()
    {
        if (PlayerPrefs.HasKey("HighScore"))
        {
            GetComponent<TextMeshProUGUI>().text = "High Score: " + PlayerPrefs.GetInt("HighScore");
        }
    }
}
