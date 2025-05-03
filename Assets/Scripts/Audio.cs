using UnityEngine;

public class Audio : MonoBehaviour
{
    public static Audio audioscript;
    [System.Serializable]
    public struct BgmType
    {
        public string name;
        public AudioClip audio;
    }
    AudioSource BGM;

    public BgmType[] BGMList;

    bool bgmPaused;

    private void Awake()
    {
        if (audioscript == null) audioscript = this;
        else Destroy(this);
    }

    void Start()
    {
        DontDestroyOnLoad(this);

        BGM = gameObject.GetComponent<AudioSource>();

        BGM.loop = true;
        bgmPaused = false;

        PlayBGM("Lobby");
    }
    public void PlayBGM(string name)
    {
        for (int i = 0; i < BGMList.Length; i++)
            if (BGMList[i].name.Equals(name))
            {
                BGM.clip = BGMList[i].audio;
                BGM.Play();
            }
    }

    public void PauseBGM()
    {
        bgmPaused = !bgmPaused;

        if (bgmPaused) BGM.Pause();
        else BGM.Pause(); BGM.UnPause();
    }

    public void StopBGM() { BGM.Stop(); }

    public void RoundBGM()
    {
        int round = GameManager.round;
        if (round == 0) PlayBGM("Round1");
        if (round == 1) PlayBGM("Round2");
        if (round == 2) PlayBGM("Round3");
        if (round == 3) PlayBGM("Round4");
        if (round == 4) PlayBGM("Round5");
    }
}
