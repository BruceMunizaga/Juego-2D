using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ColectorMonedas : MonoBehaviour
{
    
    public int monedas;

    public void agarrar(){
        monedas += 1;
        GameManager.Instance.SumarPuntos(monedas);
    }

    public int Enviarmonedas(){
        return this.monedas;
    }
}
