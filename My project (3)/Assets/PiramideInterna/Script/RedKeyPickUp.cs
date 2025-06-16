using UnityEngine;

public class RedKeyPickup : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerInterno player = other.GetComponent<PlayerInterno>();
            if (player != null)
            {
                KeyPickup.hasRedKey = true;
                player.DesbloquearSuperAtaque();
                Debug.Log("Chave vermelha coletada! Super ataque desbloqueado!");
                Destroy(gameObject);
            }
        }
    }
}