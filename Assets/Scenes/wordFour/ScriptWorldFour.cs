using UnityEngine;
using UnityEngine.SceneManagement;


public class ScriptWorldFour : MonoBehaviour
{
  [SerializeField] private Animator sceneAnimation;

  void Awake()
  {
    sceneAnimation.SetTrigger("fadeOut");
  }
  public void PreviousScene(int scene)
  {
    GameManager.Instance.PreviousScene(scene);
  }

  public void PauseGame()
  {
    GameManager.Instance.PauseGame();
  }

  public void RestartGame()
  {
    string sceneName = SceneManager.GetActiveScene().name;
    GameManager.Instance.RestartGame(sceneName);
  }

  public void SaveGame()
  {
    GameManager.Instance.SaveGame();
  }

  public void ExitGame()
  {
    GameManager.Instance.ExitGame();
  }

  public void ClosePanel()
  {
    GameManager.Instance.ClosePanel();
  }

  public void SoundPlay()
  {
    GameManager.Instance.SoundPlay();
  }
}
