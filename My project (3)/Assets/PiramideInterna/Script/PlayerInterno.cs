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

    [Header("Interação")]
    public LayerMask camadaInterativa; // defina como "Interactable"
    public float alcanceInteracao = 3f;
    public Sphere carriedSphere; // esfera que o player está carregando

    void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // Movimento
        estaNoChao = Physics.CheckSphere(checadorDeChao.position, raioChao, camadaDoChao);

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

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

        // Interação
        if (Input.GetKeyDown(KeyCode.E))
        {
            TentarInteragir();
        }
    }

    void TentarInteragir()
    {
        Ray ray = new Ray(transform.position + Vector3.up * 0.5f, transform.forward);
        if (Physics.Raycast(ray, out RaycastHit hit, alcanceInteracao, camadaInterativa))
        {
            if (hit.collider.TryGetComponent(out Altar altar))
            {
                altar.Interact(this);
            }
            else if (hit.collider.TryGetComponent(out Receptacle receptacle))
            {
                receptacle.Interact(this);
            }
        }
    }
}