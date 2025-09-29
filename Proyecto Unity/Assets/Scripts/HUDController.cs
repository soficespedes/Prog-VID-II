using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class HUDController : MonoBehaviour
{
    [SerializeField] GameObject iconoVida;
    [SerializeField] GameObject contenedorIconosVida;


    public void ActualizarVidasHUD(int vida)
    {
        Debug.Log("ESTAS ACTUALIZANDO VIDAS");

        int diferencia = CantidadIconosVidas() - vida;

        if (diferencia > 0)
        {
            for (int i = 0; i < diferencia; i++)
                EliminarUltimoIcono();
        }
        else if (diferencia < 0)
        {
            for (int i = 0; i < -diferencia; i++)
                CrearIcono();
        }


    }

    private bool EstaVacioContenedor()
    {
        return contenedorIconosVida.transform.childCount == 0;
    }

    private int CantidadIconosVidas()
    {
        return contenedorIconosVida.transform.childCount;
    }

    private void EliminarUltimoIcono()
    {
        Transform contenedor = contenedorIconosVida.transform;
        GameObject.Destroy(contenedor.GetChild(contenedor.childCount - 1).gameObject);
    }
    private void CargarContenedor(int vida)
    {
        for (int i = 0; i < vida; i++)
        {
            CrearIcono();
        }
    }

    private void CrearIcono()
    {
        Instantiate(iconoVida, contenedorIconosVida.transform);
    }
}