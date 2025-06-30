using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    // Cargar una escena espec�fica
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

    // Volver al men� principal
    public void VolverAlMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
