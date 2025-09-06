using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoPerseguir : MonoBehaviour
{
    // Variables a configurar desde el editor
    [Header("Configuracion")]
    [SerializeField] float velocidad = 5f;
    [SerializeField] float radio = 5f;
    // Referencia al transform del jugador serializada
    [SerializeField] Transform jugador;

    // Variable para referenciar otro componente del objeto
    private Rigidbody2D miRigidbody2D;
    private Vector2 direccion;

    private void Awake()
    {
        miRigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        float distanceToPlayer = Vector2.Distance(transform.position, jugador.position);
        if (distanceToPlayer < radio)
        {
            Vector2 direction = (jugador.position - transform.position).normalized;
            direccion = new Vector2(direction.x, 0);
        }
        else
        {
            direccion = Vector2.zero;
        }
        miRigidbody2D.MovePosition(miRigidbody2D.position + direccion * velocidad * Time.deltaTime);
    }
}