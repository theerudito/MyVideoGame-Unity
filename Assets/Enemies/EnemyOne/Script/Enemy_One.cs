using UnityEngine;

public class Enemy_One : MonoBehaviour
{
    [SerializeField]
    private Transform player;

    [SerializeField]
    private GameObject startPointObj;

    [SerializeField]
    private GameObject endPointObj;

    [SerializeField]
    private Transform pointSpawnObj;

    [SerializeField]
    private float speedEnemy = 1f;

    [SerializeField]
    private float healthEnemy = 100f;

    [SerializeField]
    private bool goRight = true;
    private Rigidbody2D enemyOneRB;
    private SpriteRenderer enemySpriteSR;

    [SerializeField]
    private GameObject _bulletEnemyOne;

    public bool _playerOnRange;
    private string namePlayer = "Player";
    private string nameBullerPlayer = "BulletPlayer";

    void Start()
    {
        enemyOneRB = GetComponent<Rigidbody2D>();
        enemySpriteSR = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        EnemyMovement();
    }

    public void EnemyMovement()
    {
        if (_playerOnRange == false)
        {
            if (goRight)
            {
                transform.position = Vector3.MoveTowards(
                    transform.position,
                    endPointObj.transform.position,
                    speedEnemy * Time.deltaTime
                );

                if (transform.position == endPointObj.transform.position)
                {
                    goRight = false;
                    enemySpriteSR.flipX = false;
                }
            }
            else
            {
                transform.position = Vector3.MoveTowards(
                    transform.position,
                    startPointObj.transform.position,
                    speedEnemy * Time.deltaTime
                );

                if (transform.position == startPointObj.transform.position)
                {
                    goRight = true;
                    enemySpriteSR.flipX = true;
                }
            }
        }
    }

    public void FlipEnemy()
    {
        float playerDirection = Mathf.Sign(player.position.x - transform.position.x);

        if (playerDirection > 0)
        {
            Debug.Log("Player en la derecha");
            enemySpriteSR.flipX = true;
        }
        else if (playerDirection < 0)
        {
            Debug.Log("Player en la izquierda");
            enemySpriteSR.flipX = false;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag(namePlayer))
        {
            //Debug.Log("El Player esta en el rango de ataque");
            FlipEnemy();
            _playerOnRange = true;
            FireToPlayer();
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag(namePlayer))
        {
            _playerOnRange = false;
        }
    }

    public void FireToPlayer()
    {
        Instantiate(_bulletEnemyOne, pointSpawnObj.position, pointSpawnObj.rotation);
    }
}
