using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    private Vector2 puntoInicio = new Vector2(-28.94f,-4.22f);
    void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag == "Enemigo") {
            // El player ha tocado un enemigo
            EjecutarAnimacion();
            StartCoroutine(ResetearPosicionDespuesDeAnimacion());
        }
    }
    void ResetearPosicion() {
        transform.position = puntoInicio; // Usa la variable que almacena las coordenadas del punto de inicio
    }
    void EjecutarAnimacion() {
        // Accede al animador del player
        Animator animator = GetComponent<Animator>();
        // Dispara el estado de animación de daño
        animator.SetTrigger("Daño");
    }
    IEnumerator ResetearPosicionDespuesDeAnimacion() {
        yield return new WaitForSeconds(0.5f);
        ResetearPosicion();
    }
}
