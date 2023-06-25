using TMPro;
using UnityEngine;

public class Bullet_Player : MonoBehaviour
{
    private float speedBuller = 10f;

    private float timeDestroyBullet = 1f;

    private Animator animatorBullet;

    private Rigidbody2D bulletOneRB;

    private string CollitionEnemyOneTag = "EnemyOne";

    private string CollitionWallTag = "Wall";

    private int _score = 0;
    private int _newScore = 10;
    private string _textScore = "MyScore";

    private TextMeshProUGUI textScore;

    private void Start()
    {
        animatorBullet = GetComponent<Animator>();
        bulletOneRB = GetComponent<Rigidbody2D>();
        GameObject obj = GameObject.Find(_textScore);
        textScore = obj.GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        bulletOneRB.velocity = transform.right * speedBuller;
        Destroy(gameObject, timeDestroyBullet);
    }

    private void OnCollisionEnter2D(Collision2D bullet)
    {
        if (bullet.collider.tag == CollitionEnemyOneTag)
        {
            KillEnemy();
            Destroy(bullet.gameObject);
            Destroy(gameObject);
        }

        if (bullet.collider.tag == CollitionWallTag)
        {
            Destroy(gameObject);
        }
    }

    public void KillEnemy()
    {
        _score += _newScore;
        textScore.text = _score.ToString();
    }
}
