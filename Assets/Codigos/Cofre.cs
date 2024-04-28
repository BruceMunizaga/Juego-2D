using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cofre : MonoBehaviour
{


        private Animator animator;
        private bool cofreAbierto = false;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetBool("cofreAbierto",cofreAbierto);
    }

    public void abrirCofre(int puntos){
        cofreAbierto = true;
    }

}
