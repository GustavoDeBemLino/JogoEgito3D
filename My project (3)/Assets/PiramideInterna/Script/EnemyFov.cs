using UnityEngine;
using UnityEngine.AI; 
using UnityEngine.SceneManagement; 

public class EnemyFov : MonoBehaviour
{
    public Transform jogador;
    public float raioVisao = 15f;
    public float anguloVisao = 360f;
    public LayerMask obstaculos;

    private NavMeshAgent agente;
    private Animator animator;

    private bool playerAvistado = false; 

    void Start()
    {
        agente = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();

        if (jogador == null)
        {
            Debug.LogWarning("Jogador não está atribuído no inspetor!");
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
                        Debug.Log("Inimigo vê o jogador (sem obstáculos).");

                        agente.SetDestination(jogador.position);

                        animator.SetInteger("transitions", 1);

                        if (!playerAvistado)
                        {
                            MusicManager.Instance.PlayAlertMusic();
                            playerAvistado = true;
                        }
                        return;
                    }
                }
            }
        }

        agente.ResetPath();

        animator.SetInteger("transitions", 0);

        if (playerAvistado)
        {
            if (SceneManager.GetActiveScene().name == "SampleScene")
                MusicManager.Instance.PlayInternoMusic();
            else if (SceneManager.GetActiveScene().name == "CenarioExterno")
                MusicManager.Instance.PlayExternoMusic();

            playerAvistado = false;
        }
    }
}
