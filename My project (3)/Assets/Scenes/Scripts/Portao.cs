using UnityEngine;
using UnityEngine.SceneManagement;

public class Portao : MonoBehaviour
{
    

    private void OnTriggerEnter(Collider other)
    {
        // Verifica se o objeto colidido tem uma tag específica (opcional)
        if (other.CompareTag("Porta")) // ou qualquer tag que você definir
        {
            SceneManager.LoadScene("SampleScene");
        }
    }
}
