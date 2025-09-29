using UnityEngine;

public class Key : MonoBehaviour
{
    [SerializeField] private string keyName = "Llave1";

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Inventory.Instance.AddItem(keyName);
            Destroy(gameObject); // la recogemos
        }
    }
}