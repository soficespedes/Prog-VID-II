using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class Jugador : MonoBehaviour
{
    [Header("Configuración")]
    
    [SerializeField] private TextMeshProUGUI textoVidas; // Referencia al UI TextMeshPro
    [SerializeField] private GameObject gameOverPanel;   // Panel de Game Over (UI)
    [SerializeField] private UnityEvent<int> OnLivesChanged;
    [SerializeField] private HUDController hud;
    [SerializeField] private PerfilJugador perfilJugador;
 
    private void Start()
    {

        if (perfilJugador != null)
        {
            perfilJugador.vidas = Mathf.Max(perfilJugador.vidas, 1); // Evitar 0 al inicio
        }

        ActualizarUI();
        if (gameOverPanel != null)
            gameOverPanel.SetActive(false); // Aseguramos que empiece oculto

        OnLivesChanged.Invoke(perfilJugador.vidas);
    }

    public void ModificarVida(int puntos)
    {
        if (perfilJugador == null) return;

        perfilJugador.vidas += puntos;

        if (perfilJugador.vidas < 0)
            perfilJugador.vidas = 0;

        ActualizarUI();

        if (hud != null)
            hud.ActualizarVidasHUD(perfilJugador.vidas);

        OnLivesChanged.Invoke(perfilJugador.vidas);

        if (!EstasVivo())
        {
            GameOver();
        }
    }

    private bool EstasVivo()
    {
        return perfilJugador != null && perfilJugador.vidas > 0;
    }

    private void ActualizarUI()
    {
        if (textoVidas != null && perfilJugador != null)
        {
            textoVidas.text = perfilJugador.vidas.ToString();
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
        perfilJugador.ResetValores();
    }
}