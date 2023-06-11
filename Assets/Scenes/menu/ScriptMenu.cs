using UnityEngine;

public class ScriptMenu : MonoBehaviour
{
    [SerializeField]
    public AudioClip soundClipMain;
    public AudioClip soundClipSecond;

    [SerializeField]
    private AudioSource mainAudioSource;

    [SerializeField]
    private AudioSource secondaryAudioSource;

    [SerializeField]
    private GameObject btnBurgerMenu;

    [SerializeField]
    private GameObject btnPanelMenu;

    [SerializeField]
    private GameObject btnPause;

    [SerializeField]
    private GameObject btnPlay;
    private bool isMusicPlaying = true;

    [SerializeField]
    private Animator sceneAnimation;

    private void Awake()
    {
        btnPanelMenu.SetActive(false);
        mainAudioSource.Play();
        sceneAnimation.SetTrigger("fadeOut");
        secondaryAudioSource = gameObject.AddComponent<AudioSource>();
    }

    public void NextScene(int scene)
    {
        ManagerScene.Instance.LoadSceneManager(scene);
    }

    public void ClickRj45()
    {
        if (soundClipSecond != null)
        {
            secondaryAudioSource.clip = soundClipSecond;
            secondaryAudioSource.Play();
        }
    }

    public void PauseThemeHome()
    {
        if (isMusicPlaying)
        {
            isMusicPlaying = false;
            btnPlay.SetActive(false);
            btnPause.SetActive(true);
            mainAudioSource.Pause();
        }
        else
        {
            isMusicPlaying = true;
            btnPause.SetActive(false);
            btnPlay.SetActive(true);
            mainAudioSource.UnPause();
        }
    }

    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("Exit");
    }

    public void ShowBurger()
    {
        btnBurgerMenu.SetActive(false);
        btnPanelMenu.SetActive(true);
    }

    public void CloseBurger()
    {
        btnBurgerMenu.SetActive(true);
        btnPanelMenu.SetActive(false);
    }
}
