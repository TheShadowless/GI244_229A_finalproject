using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerController : MonoBehaviour
{
    public int maxHP = 3;
    public int currentHP;

    public float jumpForce = 10f;
    public float gravityMultiplier = 1f;

    private Rigidbody rb;

    private bool isOnGround = true;
    public bool isGameOver = false;

    public Animator playerAnim;
    public AudioClip jumpSfx;
    public AudioClip crashSfx;
    public AudioSource playerAudio;
    public ParticleSystem explosionFx;
    public ParticleSystem dirtFx;

    [SerializeField] string playerPrefix;
    private PlayerInput playerInput;
    private InputAction jumpAction;

    private bool hasShield = false;
    private float speedBoostTimer = 0f;
    private float speedBoostDuration = 3f;
    private float originalSpeed;
    public float speedOffset = 0f;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        playerInput = GetComponent<PlayerInput>();            
        jumpAction = playerInput.actions[playerPrefix + "/Jump"];
    }

    void Start()
    {
        currentHP = maxHP;
        Physics.gravity *= gravityMultiplier;
        playerAnim.SetFloat("Speed_f", 1.0f);
        originalSpeed = GameManager.Instance.gameSpeed;
    }

    void Update()
    {
        if (jumpAction.triggered && isOnGround && !isGameOver)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
            playerAnim.SetTrigger("Jump_trig");
            playerAudio.PlayOneShot(jumpSfx, 1.0f);
            dirtFx.Stop();
        }

        if (speedBoostTimer > 0f)
        {
            speedBoostTimer -= Time.deltaTime;
            if (speedBoostTimer <= 0f)
            {
                speedOffset = 0f;
            }
        }            
    }

    void TakeDamage(int damage)
    {
        if (hasShield)
        {
            hasShield = false; 
            Debug.Log(playerPrefix + " blocked damage with shield!");
            return;
        }

        currentHP -= damage;
        if (currentHP <= 0 && !isGameOver)
        {
            isGameOver = true;
            playerAnim.SetBool("Death_b", true);
            playerAudio.PlayOneShot(crashSfx);
            explosionFx.Play();
            dirtFx.Stop();
        }
                
    }

    void Heal(int amount)
    {
        currentHP = Mathf.Min(currentHP + amount, maxHP);        
    }

    void OnCollisionEnter(Collision collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Ground":
                isOnGround = true;
                dirtFx.Play();
                break;
            case "Obstacle":
                TakeDamage(1);
                Destroy(collision.gameObject);
                break;
            case "HealItem":
                Heal(1);
                Destroy(collision.gameObject);
                break;
            case "SpeedBoost":
                speedBoostTimer = speedBoostDuration;
                speedOffset = 5f; 
                Debug.Log(playerPrefix + " got Speed Boost!");
                Destroy(collision.gameObject);
                break;
            case "Shield":
                hasShield = true;
                Debug.Log(playerPrefix + " picked up a Shield!");
                Destroy(collision.gameObject);
                break;
        }   
                        
    }

    public bool IsGameOver()
    { 
        return  isGameOver; 
    }
}

