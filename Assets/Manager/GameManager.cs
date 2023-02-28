using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
  public static GameManager Instance { get; private set; }

  [SerializeField] private Animator sceneAnimation;
  [SerializeField] private GameObject panelDialog;
  [SerializeField] private GameObject btnPause;
  [SerializeField] private GameObject btnBack;
  [SerializeField] private GameObject btnLeft;
  [SerializeField] private GameObject btnRight;
  [SerializeField] private GameObject imgSoundPlay;
  [SerializeField] private GameObject imgSoundPause;
  [SerializeField] private GameObject btnFire;
  [SerializeField] private GameObject btnJump;
  [SerializeField] private AudioClip soundClick;
  [SerializeField] private AudioSource audioMainMap;
  private bool isMusicPlaying = true;

  private void Awake()
  {

    if (Instance == null)
    {
      Instance = this;
      //DontDestroyOnLoad(gameObject);
    }
    else
    {
      Destroy(gameObject);
    }
    panelDialog.SetActive(false);
    imgSoundPause.SetActive(false);
  }

  public void PreviousScene(int scene)
  {
    AudioManager.Instance.ClickSound(soundClick);
    ManagerScene.Instance.LoadSceneManager(scene);
  }

  public void PauseGame()
  {
    // nombre de la escena actual
    AudioManager.Instance.ClickSound(soundClick);
    panelDialog.SetActive(true);
    btnPause.SetActive(false);
    btnBack.SetActive(false);
    btnLeft.SetActive(false);
    btnRight.SetActive(false);
    btnFire.SetActive(false);
    btnJump.SetActive(false);
    Time.timeScale = 0;
  }

  public void RestartGame(string sceneName)
  {
    ClosePanel();
    ManagerScene.Instance.ReloadSceneManager(sceneName);
    AudioManager.Instance.ClickSound(soundClick);
  }

  public void SaveGame()
  {
    AudioManager.Instance.ClickSound(soundClick);
  }

  public void ExitGame()
  {
    AudioManager.Instance.ClickSound(soundClick);
    ManagerScene.Instance.QuitGame();
  }

  public void ClosePanel()
  {
    AudioManager.Instance.ClickSound(soundClick);
    panelDialog.SetActive(false);
    btnPause.SetActive(true);
    btnBack.SetActive(true);
    btnLeft.SetActive(true);
    btnRight.SetActive(true);
    btnFire.SetActive(true);
    btnJump.SetActive(true);
    Time.timeScale = 1;
  }

  public void SoundPlay()
  {
    if (isMusicPlaying)
    {
      isMusicPlaying = false;
      imgSoundPlay.SetActive(false);
      imgSoundPause.SetActive(true);
      audioMainMap.Pause();
    }
    else
    {
      isMusicPlaying = true;
      imgSoundPause.SetActive(false);
      imgSoundPlay.SetActive(true);
      audioMainMap.UnPause();
    }
  }
}
