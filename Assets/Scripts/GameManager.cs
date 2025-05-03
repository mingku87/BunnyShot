using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Text timeText, recordText, roundText;
    public GameObject clearImage, clearImage1, clearImage2;
    public GameObject gameoverImage, pausedImage, boosterImage, shieldImage;
    public GameObject Life0, Life1, Life2, Life3;

    float survivalTime;
    string printTime;
    bool isGameover, isClear, isPaused;

    public static int round = 1;
    public static void DecideRound(int i) { round = i; }
    public static void RoundUp() { round++; }

    void Start()
    {
        survivalTime = 0;
        isGameover = false;
        isClear = false;
        isPaused = false;

        roundText.text = "Round " + round;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            FindObjectOfType<AudioEffect>().ClickSound();
            if (isPaused == true)
            {
                Continue();
            }
            else
            {
                FindObjectOfType<Audio>().PauseBGM();
                pausedImage.SetActive(true);
                Time.timeScale = 0;
                isPaused = true;
            }
        }
        if ((isGameover == false) && (isClear == false))
        {
            survivalTime += Time.deltaTime;
            printTime = survivalTime.ToString("f1");
            timeText.text = "Time: " + printTime;
        }
        if (isClear == true)
        {
            if (Input.GetKeyDown(KeyCode.N) == true)
            {
                Nextgame();
            }
        }
        if (isGameover == true)
        {
            if (Input.GetKeyDown(KeyCode.R) == true)
            {
                Retry();
            }
        }
    }

    public void Life()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused == true)
            {
                Continue();
            }
            else
            {
                pausedImage.SetActive(true);
                Time.timeScale = 0;
                isPaused = true;
            }
        }
        if ((isGameover == false) && (isClear == false))
        {
            survivalTime += Time.deltaTime;
            printTime = survivalTime.ToString("f1");
            timeText.text = "Time: " + printTime;
        }
        if (isClear == true)
        {
            if (Input.GetKeyDown(KeyCode.N) == true)
            {
                Nextgame();
            }
        }
        if (isGameover == true)
        {
            if (Input.GetKeyDown(KeyCode.R) == true)
            {
                Retry();
            }
        }
        if (Player.life == 1)
        {
            Life0.SetActive(false);
            Life1.SetActive(true);
            Life2.SetActive(false);
            Life3.SetActive(false);
        }
        else if (Player.life == 2)
        {
            Life0.SetActive(false);
            Life1.SetActive(false);
            Life2.SetActive(true);
            Life3.SetActive(false);
        }
        else if (Player.life == 3)
        {
            Life0.SetActive(false);
            Life1.SetActive(false);
            Life2.SetActive(false);
            Life3.SetActive(true);
        }
    }
    public void PlayGame()
    {
        FindObjectOfType<AudioEffect>().ClickSound();
        SceneManager.LoadScene("Shooting1");
    }

    public void Endgame()
    {
        FindObjectOfType<Audio>().StopBGM();
        FindObjectOfType<AudioEffect>().DieSound();
        isGameover = true;
        Life1.SetActive(false);
        Life0.SetActive(true);
        gameoverImage.SetActive(true);
    }

    public void Cleargame(int life)
    {
        FindObjectOfType<Audio>().StopBGM();
        round++;
        if (round == 5)
        {
            FindObjectOfType<Audio>().PlayBGM("Finish");
            SceneManager.LoadScene("Finish");
        }
        else
        {
            FindObjectOfType<AudioEffect>().ClearSound();
            RoundUp();
            clearImage.SetActive(true);
            if (life == 1)
            {
                clearImage1.SetActive(true);
            }
            if (life == 2)
            {
                clearImage2.SetActive(true);
            }
            recordText.text = "" + survivalTime.ToString("f1");
            isClear = true;
        }
    }

    public void Nextgame()
    {
        FindObjectOfType<AudioEffect>().ClickSound();
        SceneManager.LoadScene("Shooting1");
        FindObjectOfType<Audio>().RoundBGM();
        Time.timeScale = 1;
        isClear = false;
    }
    public void Retry()
    {
        SceneManager.LoadScene("Shooting1");
        FindObjectOfType<Audio>().RoundBGM();
    }
    public void Continue()
    {
        FindObjectOfType<Audio>().PauseBGM();
        pausedImage.SetActive(false);
        Time.timeScale = 1;
        isPaused = false;
    }
    public void ExitGame()
    {
        FindObjectOfType<AudioEffect>().ClickSound();
        Application.Quit();
    }
    public void MainMenu()
    {
        FindObjectOfType<Audio>().PauseBGM();
        FindObjectOfType<AudioEffect>().ClickSound();
        Time.timeScale = 1;
        FindObjectOfType<Audio>().PlayBGM("Lobby");
        SceneManager.LoadScene("Start");
    }
}
