using UnityEngine;
using UnityEngine.UI; // Para usar UI

public class Lever : MonoBehaviour
{
    public bool isOn = false;
    public LeverPuzzle puzzleManager;
    public Transform player;
    public float interactionDistance = 5f;
    public GameObject interactionUI; // Refer�ncia ao texto da UI

    private Vector3 originalRotation;
    private Vector3 downRotation;

    void Start()
    {
        originalRotation = transform.eulerAngles;
        downRotation = originalRotation + new Vector3(-45, 0, 0);

        if (interactionUI != null)
            interactionUI.SetActive(false); // Garante que come�a escondido
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
                Debug.Log("E pressionado");
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