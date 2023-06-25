using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_EnemyOne : MonoBehaviour
{
    private float speedBuller = 5f;

    private float timeDestroyBullet = 5f;

    private Animator animatorBullet;

    private Rigidbody2D bulletEnemyRB;

    private string CollitionPayerTag = "Player";

    private string CollitionWallTag = "Wall";

    void Start()
    {
        bulletEnemyRB = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        bulletEnemyRB.velocity = transform.right * speedBuller;
        Destroy(gameObject, timeDestroyBullet);
    }

    private void OnCollisionEnter2D(Collision2D player)
    {
        if (player.collider.tag == CollitionPayerTag)
        {
            //Destroy(player.gameObject);
            //Destroy(gameObject);
        }

        if (player.collider.tag == CollitionWallTag)
        {
            Destroy(gameObject);
        }
    }
}
