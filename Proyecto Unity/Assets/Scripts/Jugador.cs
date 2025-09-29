using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class Jugador : MonoBehaviour
{
    [Header("Configuración")]
    [SerializeField] private int vida = 3;  
    [SerializeField] private TextMeshProUGUI textoVidas; // Referencia al UI TextMeshPro
    [SerializeField] private GameObject gameOverPanel;   // Panel de Game Over (UI)
    [SerializeField] private UnityEvent<int> OnLivesChanged;
    [SerializeField] private HUDController hud;


    private void Start()
    {
        ActualizarUI();
        if (gameOverPanel != null)
            gameOverPanel.SetActive(false); // Aseguramos que empiece oculto

        OnLivesChanged.Invoke(vida);
    }

    public void ModificarVida(int puntos)
    {
        vida += puntos;

        // Evitamos que baje de 0
        if (vida < 0) vida = 0;

        ActualizarUI();

        Debug.Log(EstasVivo());

        if (hud != null)
            hud.ActualizarVidasHUD(vida);

        OnLivesChanged.Invoke(vida);
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

    public void Restart()
    {
        Time.timeScale = 1f; // Reanudamos el tiempo antes de recargar
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}