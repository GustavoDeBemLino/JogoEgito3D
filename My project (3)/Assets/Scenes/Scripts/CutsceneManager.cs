using UnityEngine;
using UnityEngine.Playables;
using System.Collections;

public class CutsceneManager : MonoBehaviour
{
    public GameObject cutsceneCamera;
    public GameObject PlayerCamera;
    public PlayableDirector timeline;

    void Start()
    {
        StartCoroutine(EsperarFimDaCutscene());
    }

    IEnumerator EsperarFimDaCutscene()
    {
        yield return new WaitForSeconds((float)timeline.duration);
        FinalizarCutscene();
    }

    void FinalizarCutscene()
    {
        timeline.Stop();
        cutsceneCamera.SetActive(false);
        PlayerCamera.SetActive(true);
       
    }
}
