using UnityEngine;
using UnityEngine.UI;

public class MuteButton : MonoBehaviour
{
    public Sprite muted;
    public Sprite unmuted;
    
    public void Mute()
    {
        AudioListener.pause = !AudioListener.pause;
        if (AudioListener.pause)
        {
            GetComponent<Image>().sprite = muted;
        }
        else
        {
            GetComponent<Image>().sprite = unmuted;
        }
        PlayerPrefs.SetInt("Muted", AudioListener.pause ? 1 : 0);
    }

    private void Awake()
    {
        if (PlayerPrefs.HasKey("Muted"))
        {
            AudioListener.pause = PlayerPrefs.GetInt("Muted") == 1;
            if (AudioListener.pause)
            {
                GetComponent<Image>().sprite = muted;
            }
            else
            {
                GetComponent<Image>().sprite = unmuted;
            }
        }
    }
}
