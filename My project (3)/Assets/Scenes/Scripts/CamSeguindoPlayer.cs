using UnityEngine;
public class CamSeguindoPlayer : MonoBehaviour
{
    public Transform player;
    public Vector3 offset = new Vector3(0, 3, -6);
    public float suavidade = 5f;

    void LateUpdate()
    {
        if (player == null) return;

        Vector3 posicaoDesejada = player.position + offset;
        transform.position = Vector3.Lerp(transform.position, posicaoDesejada, Time.deltaTime * suavidade);
        // Removido o LookAt
    }
}
  

