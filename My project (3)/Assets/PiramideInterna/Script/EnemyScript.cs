using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();

        // Define o valor do par�metro "transition" como 0 para tocar Idle
        animator.SetInteger("transition", 0);
    }
}