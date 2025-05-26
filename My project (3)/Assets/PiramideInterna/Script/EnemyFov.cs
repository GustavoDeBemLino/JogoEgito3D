using TreeEditor;
using UnityEngine;

public class EnemyFov : MonoBehaviour
{
    public Transform jogador;            
    public float raioVisao = 5f;         
    public float anguloVisao = 90f;       
    public LayerMask obstaculos;          

    void Update()
    {
        if (jogador == null)
        {
            Debug.LogWarning("Jogador não está atribuído no inspetor!");
            return;
        }

        Vector3 direcaoJogador = jogador.position - transform.position;

        
        direcaoJogador.y = 0;
        Vector3 forward = transform.forward;
        forward.y = 0;

        float distancia = direcaoJogador.magnitude;

        if (distancia < raioVisao)
        {
            float angulo = Vector3.Angle(forward, direcaoJogador);

            if (angulo < anguloVisao / 2f)
            {
                RaycastHit hit;
                if (Physics.Raycast(transform.position, direcaoJogador.normalized, out hit, distancia, ~0))
                {
                    if (hit.transform == jogador)
                    {
                        Debug.Log("Inimigo vê o jogador (sem obstáculos).");
                    }
                    else
                    {
                        Debug.Log("Inimigo não vê o jogador (obstáculo na frente).");
                    }
                }
            }
            else
            {
                Debug.Log("Jogador fora do ângulo de visão.");
            }
        }
        else
        {
            Debug.Log("Jogador está muito longe.");
        }
    }

}
