using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public GameObject howToPlay;
    public GameObject selectRound, settingImage;

    bool ruleOn;
    bool selectRoundOn, settingOn;

    private void Start()
    {
        ruleOn = false;
        selectRoundOn = false;
        settingOn = false;
    }
    public void SelectRound()
    {
        FindObjectOfType<AudioEffect>().ClickSound();
        if (selectRoundOn == false)
        {
            selectRoundOn = true;
            selectRound.SetActive(true);
        }
        else
        {
            selectRoundOn = false;
            selectRound.SetActive(false);
        }
    }
    public void Setting()
    {
        FindObjectOfType<AudioEffect>().ClickSound();
        if (settingOn == false)
        {
            settingOn = true;
            settingImage.SetActive(true);
        }
        else
        {
            settingOn = false;
            settingImage.SetActive(false);
        }
    }
    public void StartGame(int round)
    {
        FindObjectOfType<AudioEffect>().ClickSound();
        GameManager.DecideRound(round);
        SceneManager.LoadScene("Shooting");
        FindObjectOfType<Audio>().RoundBGM();
    }
    public void ExitGame()
    {
        FindObjectOfType<AudioEffect>().ClickSound();
        Application.Quit();
    }
    public void HowToPlay()
    {
        FindObjectOfType<AudioEffect>().ClickSound();
        if (ruleOn == false)
        {
            ruleOn = true;
            howToPlay.SetActive(true);
        }
        else
        {
            ruleOn = false;
            howToPlay.SetActive(false);
        }
    }
    public void RestartGame()
    {
        FindObjectOfType<Audio>().StopBGM();
        FindObjectOfType<AudioEffect>().ClickSound();
        SceneManager.LoadScene("Start");
        FindObjectOfType<Audio>().PlayBGM("Lobby");
    }
}
