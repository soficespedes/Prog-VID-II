using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Patrullar : MonoBehaviour
{
    [Header("Movimiento")]
    public float distancia = 3f;   // cuánto se mueve a izquierda y derecha
    public float speed = 2f;
    public float waitTimeAtPoint = 0f;

    [Header("Opciones visuales")]
    public bool flipSprite = true;
    public SpriteRenderer spriteRenderer;

    private Rigidbody2D rb;
    private Vector2 puntoA;
    private Vector2 puntoB;
    private Vector2 targetPoint;
    private float waitTimer;
    private Vector2 startPos;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if (flipSprite && spriteRenderer == null)
            spriteRenderer = GetComponent<SpriteRenderer>();

        // Guardar posición inicial y calcular puntos
        startPos = transform.position;
        puntoA = new Vector2(startPos.x - distancia, startPos.y);
        puntoB = new Vector2(startPos.x + distancia, startPos.y);

        targetPoint = puntoB;

        rb.gravityScale = 0f;
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
    }

    void FixedUpdate()
    {
        if (waitTimer > 0f)
        {
            waitTimer -= Time.fixedDeltaTime;
            rb.linearVelocity = Vector2.zero;
            return;
        }

        // Dirección en X (nunca 0)
        float diferencia = targetPoint.x - transform.position.x;
        float dirX = (diferencia > 0) ? 1f : -1f;
        rb.linearVelocity = new Vector2(dirX * speed, 0f);

        // Chequeo si llegó
        if (Mathf.Abs(diferencia) < 0.5f)
        {
            transform.position = new Vector2(targetPoint.x, transform.position.y);

            targetPoint = (targetPoint == puntoA) ? puntoB : puntoA;

            if (waitTimeAtPoint > 0f)
                waitTimer = waitTimeAtPoint;

            if (flipSprite && spriteRenderer != null)
                spriteRenderer.flipX = !spriteRenderer.flipX;
        }
    }

    void OnDrawGizmosSelected()
    {
        Vector2 pos = Application.isPlaying ? startPos : (Vector2)transform.position;
        Vector2 a = new Vector2(pos.x - distancia, pos.y);
        Vector2 b = new Vector2(pos.x + distancia, pos.y);

        Gizmos.color = Color.cyan;
        Gizmos.DrawLine(a, b);
        Gizmos.DrawSphere(a, 0.1f);
        Gizmos.DrawSphere(b, 0.1f);
    }
}
