using UnityEngine;
using UnityEngine.AI; // necess�rio para usar o NavMeshAgent

public class EnemyFov : MonoBehaviour
{
    public Transform jogador;
    public float raioVisao = 15f;
    public float anguloVisao = 360f;
    public LayerMask obstaculos;

    private NavMeshAgent agente;
    private Animator animator;

    void Start()
    {
        agente = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();

        if (jogador == null)
        {
            Debug.LogWarning("Jogador n�o est� atribu�do no inspetor!");
        }
    }

    void Update()
    {
        if (jogador == null) return;

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
                if (Physics.Raycast(transform.position, direcaoJogador.normalized, out hit, distancia, ~obstaculos))
                {
                    if (hit.transform == jogador)
                    {
                        Debug.Log("Inimigo v� o jogador (sem obst�culos).");

                        agente.SetDestination(jogador.position);

                        // Ativa anima��o de andar
                        animator.SetInteger("transitions", 1);
                        return;
                    }
                }
            }
        }

        // Se n�o v� o jogador, para
        agente.ResetPath();

        // Volta pra Idle
        animator.SetInteger("transitions", 0);
    }
}
