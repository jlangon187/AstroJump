using UnityEngine;
using UnityEngine.SceneManagement;

public class ControladorJugador : MonoBehaviour
{
    public float fuerzaSalto = 8f;

    // NUEVO: Variable para arrastrar el panel de Game Over aquí
    public GameObject pantallaGameOver;

    private Rigidbody miRigidbody;
    private Animator miAnimador;

    void Start()
    {
        miRigidbody = GetComponent<Rigidbody>();
        miAnimador = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        // NUEVO: Añadimos "&& Time.timeScale == 1"
        // Esto significa: Solo salta si el juego NO está pausado.
        if (Input.GetMouseButtonDown(0) && Time.timeScale == 1)
        {
            Saltar();
        }
    }

    void Saltar()
    {
        // Nota: Si usas Unity 6 usa linearVelocity, si usas versiones anteriores usa velocity
        miRigidbody.linearVelocity = Vector3.zero;
        miRigidbody.AddForce(Vector3.up * fuerzaSalto, ForceMode.Impulse);

        if (miAnimador != null)
        {
            miAnimador.SetTrigger("Salto");
        }
    }

    void OnCollisionEnter(Collision choque)
    {
        if (choque.gameObject.tag == "Enemigo")
        {
            // NUEVO: En vez de reiniciar, llamamos a la función de perder
            GameOver();
        }
    }

    // NUEVO: Función para gestionar la derrota
    void GameOver()
    {
        // 1. Activamos el panel visual
        if (pantallaGameOver != null)
        {
            pantallaGameOver.SetActive(true);
        }

        // 2. Congelamos el tiempo del juego
        Time.timeScale = 0;
    }
}