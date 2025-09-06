using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class Jugador : MonoBehaviour
{
    [Header("Configuración")]
    [SerializeField] private float vida = 5;  
    [SerializeField] private TextMeshProUGUI textoVidas; // Referencia al UI TextMeshPro
    [SerializeField] private GameObject gameOverPanel;   // Panel de Game Over (UI)
    [SerializeField] private GameObject winPanel; // Panel de Win (UI)

    private void Start()
    {
        ActualizarUI();
        if (gameOverPanel != null)
            gameOverPanel.SetActive(false); // Aseguramos que empiece oculto

        if (winPanel != null)
            winPanel.SetActive(false); // Aseguramos que empiece oculto
    }

    public void ModificarVida(float puntos)
    {
        vida += puntos;

        // Evitamos que baje de 0
        if (vida < 0) vida = 0;

        ActualizarUI();

        Debug.Log(EstasVivo());

        // Si la vida llega a 0, mostramos Game Over
        if (!EstasVivo())
        {
            GameOver();
        }

    }

    private bool EstasVivo()
    {
        return vida > 0;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Meta")) // Si llegamos a la meta, mostramos el mensaje de Win
        {
            YouWin();
        }
    }

    private void ActualizarUI() // Actualizamos las vidas
    {
        if (textoVidas != null)
        {
            textoVidas.text = "" + vida;
        }
    }
    private void GameOver()
    {
        Debug.Log("GAME OVER");

        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(true); // Mostramos el panel de Game Over
        }

        
        Time.timeScale = 0f;
    }

    private void YouWin()
    {
        Debug.Log("YOU WIN!");

        if (winPanel != null) // Mostramos el panel de Win
            winPanel.SetActive(true);

        Time.timeScale = 0f;
    }

    public void Restart()
    {
        Time.timeScale = 1f; // Reanudamos el tiempo antes de recargar
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}