using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class Manejador_Jugador : MonoBehaviour
{
    private Rigidbody2D rb2D;

    /** Variables que se usaran para poder ejecutar la funcion 
    * que mueva al personaje
    */

    private float movimientoHorizontal = 0f;
    private float velocidadDeMovimiento = 400f;
    private float suavizadoDeMovimiento = 0.248f;
    private Vector3 velocidad = Vector3.zero;
    private bool mirandoDerecha = true;


    /** Variables que se usaran para poder ejecutar la funcion 
    * que salte el personaje
    */

    [Header("Salto")]
    private float fuerzaDeSalto = 300f;
    [SerializeField] private LayerMask queEsSuelo;
    [SerializeField] private Transform controladorSuelo;
    [SerializeField] private Vector3 dimensionesCaja;
    [SerializeField] private bool enSuelo;
    private bool salto = false;


    /** Variables que se usaran para poder ejecutar las
    * animaciones del personaje
    */

    [Header("Animacion")]
    private Animator animator;

    private void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {

        movimientoHorizontal = Input.GetAxisRaw("Horizontal") * velocidadDeMovimiento;

        animator.SetFloat("Horizontal", Mathf.Abs(movimientoHorizontal));

        animator.SetFloat("VelocidadY", rb2D.velocity.y);

        if (Input.GetButtonDown("Jump"))
        {
            salto = true;
        }
    }

    private void FixedUpdate()
    {
        enSuelo = Physics2D.OverlapBox(controladorSuelo.position, dimensionesCaja, 0f, queEsSuelo);
        animator.SetBool("enSuelo", enSuelo);

        Mover(movimientoHorizontal * Time.fixedDeltaTime, salto);

        salto = false;
    }



    /**
    * Metodo privado que ayudara en interactuar el usuario con el personaje
    */
    private void Mover(float mover, bool saltar)
    {
        Vector3 velocidadObjetivo = new Vector2(mover, rb2D.velocity.y);
        rb2D.velocity = Vector3.SmoothDamp(rb2D.velocity, velocidadObjetivo, ref velocidad, suavizadoDeMovimiento);

        if (mover > 0 && !mirandoDerecha)
        {
            Girar();
        }
        else if (mover < 0 && mirandoDerecha)
        {
            Girar();
        }

        if (enSuelo && saltar)
        {
            enSuelo = false;
            rb2D.AddForce(new Vector2(0f, fuerzaDeSalto));
        }
    }

    /**
    * Metodo privado que gira la orientacion del personaje entre el eje x (negativo y positivo)
    *
    */
    private void Girar()
    {
        mirandoDerecha = !mirandoDerecha;
        Vector3 escala = transform.localScale;
        escala.x *= -1;
        transform.localScale = escala;
    }


    /**
    * Metodo privado que ayuda de forma grafica a la hora de reconocer lo que esta pisando el perosnaje
    */
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(controladorSuelo.position, dimensionesCaja);
    }
}

