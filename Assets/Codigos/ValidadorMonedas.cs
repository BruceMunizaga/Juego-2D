using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ValidadorMonedas : MonoBehaviour
{
    int monedas;
    bool abrir = false;
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
        
    }
    void OnTriggerEnter2D(Collider2D collision) {
    if (collision.CompareTag ("Player")) {
        monedas = collision.gameObject.GetComponent<ColectorMonedas>().Enviarmonedas(); 
        if(monedas == 1){
            abrir = true;
            animator.SetBool("AbrirCofre", abrir);
            StartCoroutine(CambiarEscena());            
        }
        }

    }
        IEnumerator CambiarEscena() {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
       ;
    }

}
