using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] private PerfilJugador perfilJugador;
    // Variables de uso interno en el script
    private float moverHorizontal;
    private Vector2 direccion;

    // Variable para referenciar otro componente del objeto
    private Rigidbody2D miRigidbody2D;
    private Animator miAnimator;
    private SpriteRenderer miSprite;

    // Codigo ejecutado cuando el objeto se activa en el nivel
    private void OnEnable()
    {
        miRigidbody2D = GetComponent<Rigidbody2D>();
        miAnimator = GetComponent<Animator>();
        miSprite = GetComponent<SpriteRenderer>();
        
    }

    // Codigo ejecutado en cada frame del juego (Intervalo variable)
    private void Update()
    {
        moverHorizontal = Input.GetAxis("Horizontal");
        
        direccion = new Vector2(moverHorizontal, 0f);
        //Debug.Log("Input: " + moverHorizontal);

        int velocidadX = (int)miRigidbody2D.linearVelocity.x;
        miSprite.flipX = velocidadX > 0;
        miAnimator.SetInteger("Velocidad", velocidadX);
        
    }
    private void FixedUpdate()
    {
        miRigidbody2D.AddForce(direccion * perfilJugador.Velocidad);
    }
}