using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneradorObjeto : MonoBehaviour
{
    [SerializeField] private GameObject objetoPrefab;

    [SerializeField, Range(0.5f, 5f)]
    private float tiempoEspera = 1f;

    [Header("Ajustes de posición del spawn")]
    [SerializeField] private float offsetY = -0.8f; // más abajo del tubo

    void GenerarObjeto()
    {
        // Calculamos la posición del spawn más abajo
        Vector3 posicionSpawn = new Vector3(
            transform.position.x,
            transform.position.y + offsetY,
            transform.position.z
        );

        // Instanciamos el enemigo
        GameObject nuevo = Instantiate(objetoPrefab, posicionSpawn, Quaternion.identity);

        // Aseguramos que la gravedad esté activada
        Rigidbody2D rb = nuevo.GetComponent<Rigidbody2D>();
        if (rb != null)
            rb.gravityScale = Mathf.Max(rb.gravityScale, 1f); // evita que esté en 0
    }

    private void OnBecameInvisible()
    {
        CancelInvoke(nameof(GenerarObjeto));
    }

    private void OnBecameVisible()
    {
        Invoke(nameof(GenerarObjeto), tiempoEspera);
    }
}