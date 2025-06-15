using UnityEngine;
using UnityEngine.SceneManagement;

public class Portao : MonoBehaviour
{
    

    private void OnTriggerEnter(Collider other)
    {
        // Verifica se o objeto colidido tem uma tag espec�fica (opcional)
        if (other.CompareTag("Porta")) // ou qualquer tag que voc� definir
        {
            SceneManager.LoadScene("SampleScene");
        }
    }
}
