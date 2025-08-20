using Unity.VisualScripting;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI CoinText;
    public float speed = 5.0f; 
    public int direction = 1;
    public float jumpForce = 5.0f;
    public bool isGrounded = true; 
    public SpriteRenderer spriteRenderer;
    private Rigidbody2D rb;
    private int coin;
    public GameObject Saw;
    public GameObject Trappoint;
    public TextMeshProUGUI LastScore;
    public Animator animator;
    public GameObject DeathPanel;
    [SerializeField] private GameObject LavaPanel;
    [SerializeField] private GameObject WinPanel;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();

        rb = GetComponent<Rigidbody2D>();
        coin = 0;
        Saw.SetActive(false);
        DeathPanel.SetActive(false);
        if(LavaPanel != null)
        {
            LavaPanel.SetActive(true);
        }
        if (WinPanel != null)
        {
            WinPanel.SetActive(false);
        }
    }


    void Update()
    {
        var x = Input.GetAxis("Horizontal");
        if (x != 0)
        {

            transform.Translate(new Vector2(x * speed * Time.deltaTime, 0));
        }

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            isGrounded = false;
            if (animator != null)
            {
                animator.SetBool("isJumping", true);
                animator.SetBool("isRunning", false);
                //jump.Play();
            }
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        }
        if (animator != null && isGrounded == true)
        {
            animator.SetBool("isRunning", x != 0);
            animator.SetBool("isIdie", x == 0);
        }

        Vector3 currentScale = transform.localScale;
        if (x > 0)
        {
            direction = 1;
            transform.localScale = new Vector3(Mathf.Abs(currentScale.x), currentScale.y, currentScale.z);
            //spriteRenderer.flipX = false; 
        }
        else if (x < 0)
        {
            direction = -1;
            transform.localScale = new Vector3(-Mathf.Abs(currentScale.x), currentScale.y, currentScale.z);
            //spriteRenderer.flipX = true; 
        }

        
        
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            if (animator != null)
                animator.SetBool("isJumping", false);
           
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Coin"))
        {
            coin += 10;
            CoinText.text = "" + coin;
            Destroy(collision.gameObject);
        }
        if(collision.gameObject.CompareTag("Enemy"))    
        {
            Death();
        }
        if(collision.gameObject.CompareTag("Trap"))    
        {
            Saw.SetActive(true);
            Destroy(Trappoint);
                    }
        
        if(collision.gameObject.CompareTag("Saw"))
        {
            Death();
        }
        if(collision.gameObject.CompareTag("GateMap1")) {
            SceneManager.LoadScene("Map2");
            Time.timeScale = 1;
        }
        if (collision.gameObject.CompareTag("Lava"))
        {
            Death();
        }
        if (collision.gameObject.CompareTag("GateMap2"))
        {
            Time.timeScale = 0;
            WinPanel.SetActive(true);
            LastScore.text = "" + coin;
            

        }
    }

   
    
    public void Death()
    {
        Time.timeScale = 0;
        DeathPanel.SetActive(true );
        LastScore.text = "" + coin;
        if (LavaPanel != null)
        {
            LavaPanel.SetActive(false);
        }
    }

    
}
