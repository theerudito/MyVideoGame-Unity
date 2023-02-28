
using UnityEngine;

public class Enemy_One : MonoBehaviour
{
  [SerializeField] private Transform Player;
  [SerializeField] private GameObject startPointObj;
  [SerializeField] private GameObject endPointObj;
  [SerializeField] private GameObject pointSpawnObj;
  [SerializeField] private float speedEnemy = 1f;
  [SerializeField] private float healthEnemy = 100f;
  [SerializeField] private bool goRight = true;
  private Rigidbody2D enemyOneRB;
  private SpriteRenderer enemySpriteSR;

  private string namePlayer = "Player";
  private string nameBullerPlayer = "BulletPlayer";
  void Start()
  {
    enemyOneRB = GetComponent<Rigidbody2D>();
    enemySpriteSR = GetComponent<SpriteRenderer>();
  }


  void Update()
  {
    if (goRight)
    {
      transform.position = Vector3.MoveTowards(transform.position, endPointObj.transform.position, speedEnemy * Time.deltaTime);
      if (transform.position == endPointObj.transform.position)
      {
        goRight = false;
        enemySpriteSR.flipX = true;
        transform.eulerAngles = new Vector3(0, 180, 0);
      }
    }
    else
    {
      transform.position = Vector3.MoveTowards(transform.position, startPointObj.transform.position, speedEnemy * Time.deltaTime);
      if (transform.position == startPointObj.transform.position)
      {
        goRight = true;
        enemySpriteSR.flipX = false;
        transform.eulerAngles = new Vector3(0, 0, 0);
      }
    }

  }
  void OnCollisionEnter2D(Collision2D other)
  {
    if (other.gameObject.CompareTag(nameBullerPlayer))
    {
      Destroy(gameObject);
    }
  }

  void OnTriggerEnter2D(Collider2D other)
  {
    if (other.gameObject.CompareTag(namePlayer))
    {
      Debug.Log("El Player esta en el rango de ataque");
    }
  }

  void OnTriggerExit2D(Collider2D other)
  {
    if (other.gameObject.CompareTag(namePlayer))
    {
      Debug.Log("El Player esta fuera del rango de ataque");
    }
  }

}
