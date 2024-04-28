using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class Bloque : MonoBehaviour
{
    [SerializeField] private Transform[] puntosMovimiento;
    private float velocidadMovimiento = 50f;
    private int siguienteBloque = 1;
    private bool ordenBloque = true;

    private void Update(){
        if(ordenBloque && siguienteBloque +1 >=puntosMovimiento.Length){
            ordenBloque = false;
        }
        if(!ordenBloque && siguienteBloque <= 0){
            ordenBloque = true;
        }

        if(Vector2.Distance(transform.position, puntosMovimiento[siguienteBloque].position) < 0.1f){
            if(ordenBloque){
                siguienteBloque += 1;
            }else{
                siguienteBloque -= 1;
            }
        }

        transform.position = Vector2.MoveTowards(transform.position, puntosMovimiento[siguienteBloque].position, 
        velocidadMovimiento * Time.deltaTime);
    }
}
