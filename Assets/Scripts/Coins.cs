using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour
{
    private bool valor = false;
    
    void Start()
    {
        valor = false;
    }

    
    void Update()
    {
        if (valor == true)
        {
            Destroy(this.gameObject, 0);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Ninja")
        {
            valor = true;
        }
    }
}
