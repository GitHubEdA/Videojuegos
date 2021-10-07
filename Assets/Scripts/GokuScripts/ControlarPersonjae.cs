using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlarPersonjae : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator animator;
    private SpriteRenderer sr;
    private bool valor;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        sr.flipX = false;
        valor = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (rb.gravityScale == 10)
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
            animator.SetInteger("Cambio", 0);
        }

        if (rb.gravityScale == 0)
        {
            rb.velocity = new Vector2(0, 0);
            animator.SetInteger("Cambio", 0);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            sr.flipX = false;
            rb.velocity = new Vector2(3, rb.velocity.y);
            animator.SetInteger("Cambio", 1);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            sr.flipX = true;
            rb.velocity = new Vector2(-3, rb.velocity.y);
            animator.SetInteger("Cambio", 1);
        }
        if (valor == true)
        {
            animator.SetInteger("Cambio",2);
                rb.gravityScale = 0;
            
        }
        if (Input.GetKey(KeyCode.W) && valor)
        {
            rb.velocity = new Vector2(rb.velocity.x, 4);
        }
        if (Input.GetKey(KeyCode.S) && valor)
        {
            rb.velocity = new Vector2(rb.velocity.x, -4);
        }

        if (Input.GetKeyUp(KeyCode.UpArrow) && rb.gravityScale == 10)
        {
            rb.AddForce(new Vector2(0, 15), ForceMode2D.Impulse);
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            animator.SetInteger("Cambio", 3);
        }        
        if (Input.GetKey(KeyCode.X))
        {
            animator.SetInteger("Cambio", 0);
            rb.gravityScale = 10;
        }
        tiempo += Time.deltaTime;
        Debug.Log("El tiempo es: " + tiempo);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Mushroom")
        {
            valor = true;
            Debug.Log("Chocaste con un hongo");
        }
        
    }
    private float tiempo = 0;
}
