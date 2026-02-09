using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void CargarJuego()
    {
        // Carga la escena del juego
        SceneManager.LoadScene("GameScene");
    }
}