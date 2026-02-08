using UnityEngine;
using UnityEngine.SceneManagement;

public class ReiniciarJuego : MonoBehaviour
{
    public void Reiniciar()
    {
        // IMPORTANTE: Descongelamos el tiempo antes de reiniciar
        Time.timeScale = 1;
        // Recargamos la escena actual
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void IrAlMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Menu"); // Asegúrate de llamar a tu escena "Menu"
    }
}