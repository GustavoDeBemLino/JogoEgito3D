using UnityEngine;
using UnityEngine.UI; // Para usar UI

public class Lever : MonoBehaviour
{
    public bool isOn = false;
    public LeverPuzzle puzzleManager;
    public Transform player;
    public float interactionDistance = 2f;
    public GameObject interactionUI; // Referência ao texto da UI

    private Vector3 originalRotation;
    private Vector3 downRotation;

    void Start()
    {
        originalRotation = transform.eulerAngles;
        downRotation = originalRotation + new Vector3(-45, 0, 0);

        if (interactionUI != null)
            interactionUI.SetActive(false); // Garante que começa escondido
    }

    void Update()
    {
        float distance = Vector3.Distance(transform.position, player.position);

        if (distance <= interactionDistance)
        {
            if (interactionUI != null)
                interactionUI.SetActive(true);

            if (Input.GetKeyDown(KeyCode.E))
            {
                Toggle();
            }
        }
        else
        {
            if (interactionUI != null)
                interactionUI.SetActive(false);
        }
    }

    public void Toggle()
    {
        isOn = !isOn;
        transform.eulerAngles = isOn ? downRotation : originalRotation;
        puzzleManager.CheckSolution();
    }
}