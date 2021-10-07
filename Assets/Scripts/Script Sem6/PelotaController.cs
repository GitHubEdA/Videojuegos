using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PelotaController : MonoBehaviour
{
    private Rigidbody2D rb;
    public float VelocidadX = 5f;
    public float VelocidadY = 5f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(VelocidadX, VelocidadY);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ParedHorizontal")
            VelocidadY *= -1;
        if (collision.gameObject.tag == "ParedLateral")
            VelocidadX *= -1;


    }
}
