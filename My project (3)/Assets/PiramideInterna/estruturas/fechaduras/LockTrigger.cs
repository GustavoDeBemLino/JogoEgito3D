using UnityEngine;
using TMPro;
using System.Collections;

public class LockTrigger : MonoBehaviour
{
    public LockColor lockColor;

    public GameObject doorToOpen;
    public GameObject messageBox;

    public AudioSource musicaBossSource; // Somente 1 AudioSource aqui

    private Vector3 originalPosition;

    void Start()
    {
        if (messageBox != null)
        {
            messageBox.SetActive(false);
            originalPosition = messageBox.transform.position;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            bool hasKey = false;

            switch (lockColor)
            {
                case LockColor.Red: hasKey = KeyPickup.hasRedKey; break;
                case LockColor.Green: hasKey = KeyPickup.hasGreenKey; break;
                case LockColor.Blue: hasKey = KeyPickup.hasBlueKey; break;
            }

            if (hasKey)
            {
                Debug.Log($"Fechadura {lockColor} aberta com chave!");
                
                if (doorToOpen != null)
                    doorToOpen.transform.Translate(Vector3.up * 30f);

                if (messageBox != null)
                {
                    messageBox.SetActive(true);
                    messageBox.GetComponent<TextMeshProUGUI>().text = "Você entrou no santuário, agora irá morrer!!";

                    StartCoroutine(ShakeUI());
                    Invoke("HideMessage", 3f);
                }

                if (musicaBossSource != null && !musicaBossSource.isPlaying)
                {
                    musicaBossSource.Play();
                }
            }
            else
            {
                Debug.Log($"Você não tem a chave {lockColor}!");
            }
        }
    }

    IEnumerator ShakeUI()
    {
        float duration = 2f;
        float magnitude = 5f;
        float elapsed = 0f;

        while (elapsed < duration)
        {
            Vector3 offset = new Vector3(Random.Range(-magnitude, magnitude), Random.Range(-magnitude, magnitude), 0);
            messageBox.transform.position = originalPosition + offset;
            elapsed += Time.deltaTime;
            yield return null;
        }

        messageBox.transform.position = originalPosition;
    }

    void HideMessage()
    {
        if (messageBox != null)
            messageBox.SetActive(false);
    }
}
