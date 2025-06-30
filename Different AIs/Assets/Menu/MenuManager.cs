using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    // Cargar una escena específica
    public void CargarEscena(string nombreEscena)
    {
        SceneManager.LoadScene(nombreEscena);
    }

    // Salir del juego
    public void SalirDelJuego()
    {
        Application.Quit();
        Debug.Log("Saliendo del juego...");
    }

    // Volver al menú principal
    public void VolverAlMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
