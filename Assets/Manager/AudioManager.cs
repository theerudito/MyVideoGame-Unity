using UnityEngine;

public class AudioManager : MonoBehaviour
{
  [SerializeField] private AudioSource sfxSource, musicSource;
  public static AudioManager Instance { get; private set; }
  private bool isMusicPlaying;

  public bool GetIsMusicPlaying()
  {
    return isMusicPlaying;
  }

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

  public void PlayThemeHome(AudioClip clip)
  {
    sfxSource.PlayOneShot(clip);
  }

  public void ClickSound(AudioClip clip)
  {
    sfxSource.PlayOneShot(clip);
  }

  public void PauseMusic()
  {
    musicSource.Pause();
  }
  public void PlayMusic()
  {
    musicSource.UnPause();
  }


  private void SoundHitToEmeny()
  {

  }

  public void SoundHitToPlayer()
  {

  }

  private void SoundRun()
  {

  }

  private void SoundJump()
  {

  }

  private void SoundDeadEmenyOne()
  {

  }

  private void SoundDeadPlayer()
  {

  }
}
