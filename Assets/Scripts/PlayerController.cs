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
    private InputAction jumpAction;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        playerInput = GetComponent<PlayerInput>();            
        jumpAction = playerInput.actions[playerPrefix + "/Jump"];
    }

    void Start()
    {
        Physics.gravity *= gravityMultiplier;
        playerAnim.SetFloat("Speed_f", 1.0f);
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

        if (isGameOver)
        {
            if (playerPrefix == "Player1")
            {
                Debug.Log("🎉 Player 2 wins!");
            }
            else if (playerPrefix == "Player2")
            {
                Debug.Log("🎉 Player 1 wins!");
            }
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

    public bool IsGameOver()
    { return  isGameOver; }
}

