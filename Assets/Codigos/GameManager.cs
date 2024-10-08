using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance { get; private set; }
    
	[SerializeField] public HUD hud;

    public int PuntosTotales {get; private set;}

	private int vidas = 2;

    private void Awake()
    {

        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Debug.Log("Cuidado! Mas de un GameManager en escena.");
        }



    }
    public void SumarPuntos(int puntosASumar)
    {
        PuntosTotales = puntosASumar;
        Debug.Log("llevas "+ PuntosTotales + "monedas");
		hud.ActualizarPuntos(PuntosTotales);
    }

	public void PerderVida() {
		vidas -= 1;

		if(vidas == 0)
		{
			// Reiniciamos el nivel.
			SceneManager.LoadScene(0);
		}

		hud.DesactivarVida(vidas);
	}

	public bool RecuperarVida() {
		if (vidas == 3)
		{
			return false;
		}

		hud.ActivarVida(vidas);
		vidas += 1;
		return true;
	}

}
