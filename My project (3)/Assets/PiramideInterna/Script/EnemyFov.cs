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
            Debug.LogWarning("Jogador n�o est� atribu�do no inspetor!");
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
                        Debug.Log("Inimigo v� o jogador (sem obst�culos).");
                    }
                    else
                    {
                        Debug.Log("Inimigo n�o v� o jogador (obst�culo na frente).");
                    }
                }
            }
            else
            {
                Debug.Log("Jogador fora do �ngulo de vis�o.");
            }
        }
        else
        {
            Debug.Log("Jogador est� muito longe.");
        }
    }

}
