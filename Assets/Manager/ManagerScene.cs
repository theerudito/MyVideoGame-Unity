using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManagerScene : MonoBehaviour
{
  public static ManagerScene Instance { get; private set; }
  [SerializeField] private Animator sceneAnimation;
  [SerializeField] float timeToWait;

  private void Awake()
  {
    if (Instance == null)
    {
      Instance = this;
      DontDestroyOnLoad(gameObject);
    }
    else
    {
      Destroy(gameObject);
    }
  }

  public void LoadSceneManager(int scene)
  {
    StartCoroutine(LoadNextScene(scene));
  }

  public void ReloadSceneManager(string scene)
  {
    StartCoroutine(ReloadScene(scene));
  }

  public void ConfigGame()
  {
    Debug.Log("Config");
  }
  public void QuitGame()
  {
    Application.Quit();
  }

  public IEnumerator LoadNextScene(int scene)
  {
    sceneAnimation.SetTrigger("fadeOut");
    yield return new WaitForSeconds(timeToWait);
    SceneManager.LoadScene(scene);
  }

  public IEnumerator ReloadScene(string scene)
  {
    sceneAnimation.SetTrigger("fadeOut");
    yield return new WaitForSeconds(timeToWait);
    SceneManager.LoadScene(scene);
  }
}
