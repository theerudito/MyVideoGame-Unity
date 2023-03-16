using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
  [SerializeField] private float _playerSpeed;
  [SerializeField] private float checkRadius;
  [SerializeField] private float _jumpForce;
  [SerializeField] private float healthPlayer;
  [SerializeField] private int numBullet;
  [SerializeField] private TextMeshProUGUI textNumBullet;
  [SerializeField] private bool _isGrounded;
  [SerializeField] private bool _isJumping;
  [SerializeField] private bool _flipX;
  [SerializeField] private int direction;
  [SerializeField] private bool[] moveLR;
  [SerializeField] private bool _isRunning;
  [SerializeField] private Transform _playerSpawn;
  [SerializeField] private Transform _chechGroundObj;
  [SerializeField] private GameObject _bulletPlayer;
  [SerializeField] private Rigidbody2D _playerRB;
  [SerializeField] private LayerMask _floorMask;
  [SerializeField] private Animator _playerAnimator;
  [SerializeField] private SpriteRenderer _playerSpriteRenderer;

  string directionPlayer = "Horizontal";
  string jumpPlayer = "Jumping";
  string maskFloor = "Floor";
  string addBullet = "AddBullet";

  void Start()
  {
    _playerRB = GetComponent<Rigidbody2D>();
    //_animator = GetComponent<Animator>();
    _playerSpriteRenderer = GetComponent<SpriteRenderer>();
    _floorMask = LayerMask.GetMask(maskFloor);
    moveLR = new bool[2];
    textNumBullet.text = numBullet.ToString();
  }

  void Update()
  {
    MovePlayer();
    //sasas
  }

  void FixedUpdate()
  {
    _isGrounded = Physics2D.OverlapCircle(_chechGroundObj.position, checkRadius, _floorMask);

  }

  public void MovePlayer()
  {
    if (moveLR[0] || moveLR[1])
    {
      _playerRB.velocity = new Vector2(_playerSpeed * direction, _playerRB.velocity.y * Time.deltaTime);
      transform.eulerAngles = new Vector3(0, direction == 1 ? 0 : 180, 0);

    }
  }

  public void SetDirection(int d)
  {
    if (d == 0)
    {
      moveLR[0] = false;
      moveLR[1] = false;
      _isRunning = false;
    }
    else
    {
      direction = d;
      moveLR[0] = true;
      moveLR[1] = true;
      _isRunning = true;
    }
  }

  public void JumpPlayer()
  {
    _playerRB.AddForce(transform.up * _jumpForce, ForceMode2D.Impulse);
  }

  public void FirePlayer()
  {
    if (numBullet <= 0)
    {
      return;
    }
    else
    {
      numBullet--;
      textNumBullet.text = numBullet.ToString();
      Instantiate(_bulletPlayer, _playerSpawn.position, Quaternion.identity);
    }
  }

  void OnCollisionEnter2D(Collision2D other)
  {
    if (other.gameObject.CompareTag(addBullet))
    {
      numBullet += 5;
      textNumBullet.text = numBullet.ToString();
      Destroy(other.gameObject);
    }
  }

  void OnCollisionExit2D(Collision2D other)
  {
    Debug.Log("Exit");

  }

  void OnTriggerEnter2D(Collider2D other)
  {
    if (other.gameObject.CompareTag("BulletEnemy"))
    {
      Destroy(gameObject);
    }
  }
}
