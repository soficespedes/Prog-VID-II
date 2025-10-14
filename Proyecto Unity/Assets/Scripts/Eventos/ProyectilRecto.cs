using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ProyectilRecto : MonoBehaviour
{
    [SerializeField]
    [Range(1f, 30f)]
    private float speed = 10f;

    private Rigidbody2D rb; 
  
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void OnEnable()
    {
        Mover();
    }

    private void Mover()
    {
        Vector2 direction = Vector2.left;
        rb.linearVelocity = direction * speed;
    }
}
