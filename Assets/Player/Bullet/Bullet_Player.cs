using UnityEngine;

public class Bullet_Player : MonoBehaviour
{
  [SerializeField] private float speedBuller = 10f;
  [SerializeField] private float timeDestroyBullet = 1f;
  [SerializeField] private Animator animatorBullet;
  [SerializeField] private float damageToEnemyOne = 10f;
  [SerializeField] private float damageToEnemyTwo = 10f;
  [SerializeField] private float damageToEnemyThree = 10f;


  private string nameDoor = "Door";
  private string nameEnemyOne = "EnemyOne";
  private Rigidbody2D bulleOnetRB;

  private void Start()
  {
    animatorBullet = GetComponent<Animator>();
    bulleOnetRB = GetComponent<Rigidbody2D>();
  }
  void Update()
  {
    bulleOnetRB.velocity = transform.right * speedBuller;
    Destroy(gameObject, timeDestroyBullet);
  }
}
