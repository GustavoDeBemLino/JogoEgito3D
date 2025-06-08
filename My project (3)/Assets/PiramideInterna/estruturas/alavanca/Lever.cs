using UnityEngine;
<<<<<<< Updated upstream
<<<<<<< Updated upstream
=======
using UnityEngine.UI;
>>>>>>> Stashed changes
=======
using UnityEngine.UI;
>>>>>>> Stashed changes

public class Lever : MonoBehaviour
{
    public bool isOn = false;
    public LeverPuzzle puzzleManager;
<<<<<<< Updated upstream
=======
    public Transform player;
    public float interactionDistance = 3f;
    public GameObject interactionUI; // Objeto de UI (ex: texto "Pressione E")
<<<<<<< Updated upstream
>>>>>>> Stashed changes
=======
>>>>>>> Stashed changes

    private Vector3 originalRotation;
    private Vector3 downRotation;

    private bool playerNear = false;

    void Start()
    {
        originalRotation = transform.eulerAngles;
<<<<<<< Updated upstream
<<<<<<< Updated upstream
        downRotation = originalRotation + new Vector3(-45, 0, 0); // alavanca pra baixo
=======
=======
>>>>>>> Stashed changes
        downRotation = originalRotation + new Vector3(-45f, 0f, 0f);

        if (interactionUI != null)
            interactionUI.SetActive(false); // Esconde o texto no início
<<<<<<< Updated upstream
>>>>>>> Stashed changes
=======
>>>>>>> Stashed changes
    }

    void OnMouseDown()
    {
<<<<<<< Updated upstream
<<<<<<< Updated upstream
        Toggle();
=======
=======
>>>>>>> Stashed changes
        if (player == null) return;

        float distance = Vector3.Distance(transform.position + Vector3.up, player.position + Vector3.up);
        playerNear = distance <= interactionDistance;

        if (interactionUI != null)
            interactionUI.SetActive(playerNear);

        if (playerNear && Input.GetKeyDown(KeyCode.E))
        {
            Toggle();
        }
>>>>>>> Stashed changes
    }

    public void Toggle()
    {
        isOn = !isOn;
        transform.eulerAngles = isOn ? downRotation : originalRotation;
        puzzleManager.CheckSolution();
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position + Vector3.up, interactionDistance);
    }
}
