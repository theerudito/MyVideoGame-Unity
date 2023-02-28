using UnityEngine;

public class ScriptMenu : MonoBehaviour
{
  [SerializeField] private AudioClip soundMenu;
  [SerializeField] private AudioSource musicSource;
  [SerializeField] private GameObject btnBurgerMenu;
  [SerializeField] private GameObject btnPanelMenu;
  [SerializeField] private GameObject btnPause;
  [SerializeField] private GameObject btnPlay;
  private bool isMusicPlaying = true;
  [SerializeField] private Animator sceneAnimation;

  void Awake()
  {
    btnPanelMenu.SetActive(false);
    musicSource.Play();
    sceneAnimation.SetTrigger("fadeOut");
  }

  public void NextScene(int scene)
  {
    ManagerScene.Instance.LoadSceneManager(scene);
  }
  public void PauseThemeHome()
  {
    if (isMusicPlaying)
    {
      isMusicPlaying = false;
      btnPlay.SetActive(false);
      btnPause.SetActive(true);
      musicSource.Pause();
    }
    else
    {
      isMusicPlaying = true;
      btnPause.SetActive(false);
      btnPlay.SetActive(true);
      musicSource.UnPause();
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
