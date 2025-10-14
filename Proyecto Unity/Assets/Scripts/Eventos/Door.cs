using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    [SerializeField] private string keyName = "Llave1";
    [SerializeField] private GameObject youWinPanel; // Referencia al panel de You Win

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (youWinPanel != null)
            youWinPanel.SetActive(false); // Aseguramos que empiece oculto

        if (other.CompareTag("Player"))
        {
            if (Inventory.Instance.HasItem(keyName))
            {
                Inventory.Instance.RemoveItem(keyName);
                Debug.Log("Puerta abierta!");

                // Mostramos el panel de "You Win"
                if (youWinPanel != null)
                    youWinPanel.SetActive(true);
                Time.timeScale = 0f;
            }
            else
            {
                Debug.Log("Te falta la llave!");
            }
        }
    }
}