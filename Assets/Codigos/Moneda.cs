using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moneda : MonoBehaviour
{
    private AudioSource audioSource;
    [SerializeField] private AudioClip colectar1;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void OnTriggerEnter2D(Collider2D collision) {
    if (collision.CompareTag ("Player")) {
        audioSource.PlayOneShot(colectar1);
        collision.gameObject.GetComponent<ColectorMonedas>().agarrar();
        Debug.Log("colectada la moneda");
    // El player ha tocado un enemigo
        Destroy(this.gameObject);
        }

    }

}
