using UnityEngine;
using UnityEngine.AI;
using System;

public class VidaBoss : MonoBehaviour
{
    public int vidaMaxima = 300;
    public int vidaAtual;

    private Animator animator;
    private NavMeshAgent agente;
    private BossScript bossScript;

    public AudioSource musicaBossSource; // Controlar música da luta

    public static event Action OnBossDefeated;
    private bool estaMorto = false;

    void Start()
    {
        vidaAtual = vidaMaxima;
        animator = GetComponent<Animator>();
        agente = GetComponent<NavMeshAgent>();
        bossScript = GetComponent<BossScript>();

        if (animator == null)
            Debug.LogError("Animator do boss não encontrado em VidaBoss!");
    }

    public void TomarDano(int dano)
    {
        if (estaMorto) return;

        vidaAtual -= dano;
        Debug.Log("Boss tomou dano. Vida restante: " + vidaAtual);

        if (vidaAtual <= 0)
        {
            Morrer();
        }
        else
        {
            if (animator != null)
                animator.SetTrigger("Hit");
        }
    }

    private void Morrer()
    {
        if (estaMorto) return;
        estaMorto = true;

        Debug.Log("Boss morreu!");

        if (animator != null)
            animator.SetBool("Morto", true);

        if (bossScript != null)
            bossScript.enabled = false;

        if (agente != null)
            agente.isStopped = true;

        Collider col = GetComponent<Collider>();
        if (col != null)
            col.enabled = false;

        if (musicaBossSource != null && musicaBossSource.isPlaying)
        {
            musicaBossSource.Stop(); // Para a música da luta
        }

        OnBossDefeated?.Invoke();
    }
}
