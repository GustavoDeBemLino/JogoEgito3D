using UnityEngine;

public class Lever : MonoBehaviour
{
    public bool isOn = false;
    public LeverPuzzle puzzleManager;

    private Vector3 originalRotation;
    private Vector3 downRotation;

    void Start()
    {
        originalRotation = transform.eulerAngles;
        downRotation = originalRotation + new Vector3(-45, 0, 0); // alavanca pra baixo
    }

    void OnMouseDown()
    {
        Toggle();
    }

    public void Toggle()
    {
        isOn = !isOn;
        transform.eulerAngles = isOn ? downRotation : originalRotation;
        puzzleManager.CheckSolution();
    }
}