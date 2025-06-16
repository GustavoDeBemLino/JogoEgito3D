using UnityEngine;

public class AutoOpenDoor : MonoBehaviour
{
    public GameObject doorToOpen;

    void OnEnable()
    {
        VidaBoss.OnBossDefeated += AbrirPorta;
    }

    void OnDisable()
    {
        VidaBoss.OnBossDefeated -= AbrirPorta;
    }

    void AbrirPorta()
    {
        Debug.Log("A porta abriu após o boss ser derrotado!");
        doorToOpen.transform.Translate(Vector3.up * 30f);
    }
}
