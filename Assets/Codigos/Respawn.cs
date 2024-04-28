using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour

{
    private int contador = 0;
    private bool daño = false;
    private Vector2 puntoInicio = new Vector2(37.4098f,106.5364f);
    
    
    void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag == "Enemigo") {
            // El player ha tocado un enemigo
            GameManager.Instance.PerderVida();
            contador++;
            if(contador == 1){
                EjecutarAnimacion();
            }else if(contador == 2){
                CancelarAnimacion();
            }

            StartCoroutine(ResetearPosicionDespuesDeAnimacion());
        }
    }
    void ResetearPosicion() {
        transform.position = puntoInicio; // Usa la variable que almacena las coordenadas del punto de inicio
    }

    void EjecutarAnimacion() {
        this.daño = true;
        // Accede al animador del player
        Animator animator = GetComponent<Animator>();
        // Dispara el estado de animación de daño
        animator.SetBool("Daño",daño); //FIXME: Agregar la animacion de daño al animator de unity
    }

        void CancelarAnimacion() {
        this.daño = false;
        // Accede al animador del player
        Animator animator = GetComponent<Animator>();
        // Dispara el estado de animación de daño
        animator.SetBool("Daño",daño); //FIXME: Agregar la animacion de daño al animator de unity
    }
    IEnumerator ResetearPosicionDespuesDeAnimacion() {
        yield return new WaitForSeconds(1f);
        ResetearPosicion();
    }
}
