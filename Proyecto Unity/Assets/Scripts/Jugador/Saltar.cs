using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saltar : MonoBehaviour
{

    // Variables a configurar desde el editor
    [SerializeField] private PerfilJugador perfilJugador;

    // Variables de uso interno en el script
    private bool puedoSaltar = true;
    private bool saltando = false;
    [Header ("Configuraci�n Audio")]
    [SerializeField] private AudioClip jumpSFX;

    // Variable para referenciar otro componente del objeto
    private Rigidbody2D miRigidbody2D;

    private AudioSource miAudioSource;

    // Codigo ejecutado cuando el objeto se activa en el nivel
    private void OnEnable()
    {
        miRigidbody2D = GetComponent<Rigidbody2D>();
        miAudioSource = GetComponent<AudioSource>();
    }

    // Codigo ejecutado en cada frame del juego (Intervalo variable)
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && puedoSaltar)
        {
            puedoSaltar = false;
            ReproducirSFX(jumpSFX);
        }
    }

    private void FixedUpdate()
    {
        if (!puedoSaltar && !saltando)
        {
            miRigidbody2D.AddForce(Vector2.up * perfilJugador.Fuerzasalto, ForceMode2D.Impulse);
            saltando = true;
        }
    }

    // Codigo ejecutado cuando el jugador colisiona con otro objeto
    private void OnCollisionEnter2D(Collision2D collision)
    {
        puedoSaltar = true;
        saltando = false;
        
    }
    private void ReproducirSFX(AudioClip clip)
    {
        if (miAudioSource != null && clip != null)
        {
            // Usa PlayOneShot para reproducir el clip sin interrumpir otros que puedan estar sonando
            miAudioSource.PlayOneShot(clip);
        }
    }

}