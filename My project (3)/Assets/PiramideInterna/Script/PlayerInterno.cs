using UnityEngine;

public class PlayerInterno : MonoBehaviour
{
    private CharacterController controller;
    private Animator animator;

    public float velocidade = 5f;
    public float gravidade = -9.81f;
    private Vector3 velocidadeVertical = Vector3.zero;

    [Header("Detecção de chão")]
    public Transform checadorDeChao;
    public float raioChao = 0.3f;
    public LayerMask camadaDoChao;
    private bool estaNoChao;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        estaNoChao = Physics.CheckSphere(checadorDeChao.position, raioChao, camadaDoChao);

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // Movimento relativo ao próprio Player
        Vector3 movimento = (transform.right * horizontal + transform.forward * vertical).normalized;

        controller.Move(movimento * velocidade * Time.deltaTime);

        if (!estaNoChao)
        {
            velocidadeVertical.y += gravidade * Time.deltaTime;
        }
        else if (velocidadeVertical.y < 0)
        {
            velocidadeVertical.y = -0.1f;
        }

        controller.Move(velocidadeVertical * Time.deltaTime);

        if (movimento != Vector3.zero)
        {
            Quaternion novaRotacao = Quaternion.LookRotation(movimento);
            transform.rotation = Quaternion.Slerp(transform.rotation, novaRotacao, Time.deltaTime * 10f);
        }

        animator.SetBool("moving", movimento != Vector3.zero);
    }
}
