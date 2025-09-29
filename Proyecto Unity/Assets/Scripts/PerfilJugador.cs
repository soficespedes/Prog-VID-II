using UnityEngine;
using System.Collections;
using System.Collections.Generic;


[CreateAssetMenu (fileName = "NuevoPerfilJugador", menuName = "SO/Perfil Jugador")]
public class PerfilJugador : ScriptableObject
{
    [Header ("Datos del Jugador")]
    [Header ("Configuraciones de Atributos")]
    [SerializeField] private int vida = 3;
    public int vidas { get => vida; set => vida = value; }
    public void ResetValores()
    {
        vidas = 3;

    }
    [Header("Configuraciones de Movimiento")]
    [SerializeField] private float fuerzaSalto = 5f;
    public float Fuerzasalto {  get => fuerzaSalto; set => fuerzaSalto = value;}

    [SerializeField] private float velocidad = 5f;
    public float Velocidad { get => velocidad; set => velocidad = value; }

}
