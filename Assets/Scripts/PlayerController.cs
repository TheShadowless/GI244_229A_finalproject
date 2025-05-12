using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
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
    private InputAction moveAction;
    private InputAction jumpAction;

    void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        //moveAction = playerInput.actions[playerPrefix + "/Move"];
        jumpAction = playerInput.actions[playerPrefix + "/Jump"];
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        //Vector2 move = moveAction.ReadValue<Vector2>();
        // คุณอาจใช้ move.x หรือ move.z ตามแนวของคุณ

        if (jumpAction.triggered && isOnGround && !isGameOver)
        {
            rb.AddForce(Vector3.up * 10f, ForceMode.Impulse);
            isOnGround = false;
        }
    }

    void Start()
    {
        Physics.gravity *= gravityMultiplier;
        playerAnim.SetFloat("Speed_f", 1.0f);

        // Subscribe to jump action from this Player's own input
        playerInput.actions["Jump"].performed += ctx => OnJump();
    }

    private void OnJump()
    {
        if (isOnGround && !isGameOver)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
            playerAnim.SetTrigger("Jump_trig");
            playerAudio.PlayOneShot(jumpSfx, 1.0f);
            dirtFx.Stop();
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            dirtFx.Play();
        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            isGameOver = true;
            playerAnim.SetBool("Death_b", true);
            playerAudio.PlayOneShot(crashSfx);
            explosionFx.Play();
            dirtFx.Stop();
        }
    }
}
