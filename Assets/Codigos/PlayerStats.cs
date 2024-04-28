using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{

    [SerializeField] private int vida;
    [SerializeField] private int monedas;
    // Start is called before the first frame update
    
    void Start()
    {
        this.vida = 3;
        this. monedas = 0;
    }

    public void perderVida(){
        this.vida --;
    }

    public void recogerMoneda(){
        this.monedas++;
    }
}
