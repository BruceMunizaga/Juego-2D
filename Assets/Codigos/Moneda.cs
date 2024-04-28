using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moneda : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision) {
    if (collision.CompareTag ("Player")) {
        collision.gameObject.GetComponent<ColectorMonedas>().agarrar();
        Debug.Log("colectada la moneda");
    // El player ha tocado un enemigo
        Destroy(this.gameObject);
        }

    }
}
