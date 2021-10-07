using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlarKunai : MonoBehaviour
{
    private Rigidbody2D rb;
    public GameObject Ninja;
    private PuntajeController puntajeCoins;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Destroy(this.gameObject, 1);
        puntajeCoins = FindObjectOfType<PuntajeController>();
        Debug.Log(puntajeCoins.GetPoints());
    }

    // Update is called once per frame
    void Update()
    {
        var a = Ninja.transform.position.x;
        rb.velocity = new Vector2(10, rb.velocity.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Zombie")
        {
            Destroy(this.gameObject, 0);
            puntajeCoins.AddPoints(10);
            Debug.Log(puntajeCoins.GetPoints());
        }
    }
}
