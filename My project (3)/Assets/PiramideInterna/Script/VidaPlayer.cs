using UnityEngine;

public class VidaPlayer : MonoBehaviour
{
    public int vidaMaxima = 100;
    public int vidaAtual;

    void Start()
    {
        vidaAtual = vidaMaxima;
    }

    // Método para o personagem tomar dano
    public void TomarDano(int quantidade)
    {
        vidaAtual -= quantidade;
        Debug.Log($"Vida atual: {vidaAtual}");

        if (vidaAtual <= 0)
        {
            Morrer();
        }
    }

    void Morrer()
    {
        Debug.Log("Personagem morreu!");
    }
}