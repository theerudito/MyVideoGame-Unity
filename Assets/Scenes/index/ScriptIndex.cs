using UnityEngine;

public class ScriptIndex : MonoBehaviour
{
  [SerializeField] private AudioClip soundMain;
  [SerializeField] private AudioClip soundClick;

  public void PlayGame()
  {
    AudioManager.Instance.ClickSound(soundClick);
    ManagerScene.Instance.LoadSceneManager(1);
    Debug.Log("Play Game");
  }

  public void ConfigGame()
  {
    AudioManager.Instance.ClickSound(soundClick);
    Debug.Log("Config Game");
  }

  public void ExitGame()
  {
    AudioManager.Instance.ClickSound(soundClick);
    ManagerScene.Instance.QuitGame();
    Debug.Log("Exit Game");
  }
}
