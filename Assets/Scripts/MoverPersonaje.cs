using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MoverPersonaje : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator animator;
    private SpriteRenderer sr;
    private Transform _transform;
    private AudioSource _audioSource;

    public GameObject bullet;
    public PuntajeController puntajeCoins;
    public AudioClip audioJump;
    public AudioClip fireball;
    public Text textoPuntaje;
    public Text vidasTexto;

    private bool valor = false;
    private bool escalera = false;
    private int vidas = 3;
    public int numSaltos = 0;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        _transform = GetComponent<Transform>();
        _audioSource = GetComponent<AudioSource>();
        valor = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!escalera)
        {
            rb.gravityScale = 10;
            rb.velocity = new Vector2(0, rb.velocity.y);
            animator.SetInteger("Cambio", 0);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.velocity = new Vector2(10, rb.velocity.y); 
            animator.SetInteger("Cambio", 1);
            sr.flipX = false;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb.velocity = new Vector2(-10, rb.velocity.y); 
            animator.SetInteger("Cambio", 1);
            sr.flipX = true;
        }
        if (Input.GetKeyUp(KeyCode.UpArrow) && numSaltos < 2)
        {
            rb.velocity = new Vector2(rb.velocity.x, 0);
            rb.AddForce(new Vector2(0, 23), ForceMode2D.Impulse);
            _audioSource.PlayOneShot(audioJump);
            numSaltos++;
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            animator.SetInteger("Cambio", 2);
        }
        if (Input.GetKeyUp(KeyCode.X))
        {
            Instantiate(bullet, _transform.position, Quaternion.identity);
            _audioSource.PlayOneShot(fireball);
        }
        if (Input.GetKey(KeyCode.X))
            animator.SetInteger("Cambio", 3);
        
        if (valor == true || vidas == 0)
            animator.SetInteger("Cambio", 4);
        
        if (Input.GetKey(KeyCode.D))
            animator.SetInteger("Cambio", 5);

        if (escalera)
        {
            animator.SetInteger("Cambio", 0);
            rb.velocity = new Vector2(rb.velocity.x, 0);

            if (Input.GetKey(KeyCode.W))
            {
                rb.gravityScale = 0;
                rb.velocity = new Vector2(rb.velocity.x, 2);
                animator.SetInteger("Cambio", 6);
            }
            if (Input.GetKey(KeyCode.S))
            {
                rb.gravityScale = 0;
                rb.velocity = new Vector2(rb.velocity.x, -2);
                animator.SetInteger("Cambio", 6);
            }
        }
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Zombie")
        {
            valor = true;
            Debug.Log("Chocaste con un Zombie");
        }
        if (collision.gameObject.tag == "Coin")
        {
            puntajeCoins.AddPoints(5);
            Debug.Log(puntajeCoins.GetPoints());
        }
        if (collision.gameObject.tag == "Bullet")
        {
            vidas--;
            vidasTexto.text = "Vidas: " + vidas;
        }
        if (collision.gameObject.layer == 8)
            numSaltos = 0;
        if (collision.gameObject.name == "Tree_2")
        {
            Debug.Log("Cambio de escena");
            SceneManager.LoadScene("Goku");
        }
    }

    public void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Escalera")
            escalera = true;
    }
    public void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Escalera")
            escalera = false;
    }
}
