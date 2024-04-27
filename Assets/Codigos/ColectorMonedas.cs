using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColectorMonedas : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision) {
    if (collision.gameObject.tag == "Moneda") {
    // El player ha tocado un enemigo
        Destroy(collision.gameObject);
        }

    }
}
