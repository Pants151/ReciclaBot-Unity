using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [Header("Ajustes de Movimiento")]
    public float speed = 10f;
    public float xLimit = 8.5f;

    [Header("Referencias UI")]
    public Text scoreText;
    public GameObject gameOverPanel;
    private int score = 0;

    [Header("Sonidos y Música")]
    public AudioSource musicSource; // Altavoz para la música de fondo
    public AudioSource sfxSource;   // NUEVO: Altavoz para los efectos (SFX)
    public AudioClip pointSound;
    public AudioClip bombSound;

    void Start()
    {
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(false);
        }
        Time.timeScale = 1f;
    }

    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        transform.Translate(Vector2.right * moveX * speed * Time.deltaTime);

        float clampedX = Mathf.Clamp(transform.position.x, -xLimit, xLimit);
        transform.position = new Vector3(clampedX, transform.position.y, transform.position.z);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Detectamos la colisión con los Tags configurados
        if (other.CompareTag("Punto"))
        {
            score++;
            scoreText.text = "Puntos: " + score;

            // --- Reproducir sonido de punto ---
            if (sfxSource != null && pointSound != null)
            {
                sfxSource.PlayOneShot(pointSound);
            }

            Destroy(other.gameObject);
        }
        else if (other.CompareTag("Obstaculo"))
        {
            // --- Reproducir sonido de obstáculo ---
            if (sfxSource != null && bombSound != null)
            {
                sfxSource.PlayOneShot(bombSound);
            }

            Destroy(other.gameObject);
            GameOver();
        }
    }

    void GameOver()
    {
        if (musicSource != null)
        {
            musicSource.Stop();
        }

        Time.timeScale = 0f;
        gameOverPanel.SetActive(true);
    }

    public void ReiniciarJuego()
    {
        Time.timeScale = 1f; // Reseteamos el tiempo para que el juego se mueva
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void VolverAlMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MenuScene");
    }
}