using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EfectoSonido : MonoBehaviour
{
    [SerializeField] private AudioClip colectar;

    private void OnTriggerEnter2D(Collider2D other){
        if(other.CompareTag("Player")){
            ControladorSonido.Instance.EjecutarSOnido(colectar);
        }
    }
}
