using UnityEngine;

public class Altar : MonoBehaviour
{
    public Sphere currentSphere;

    public void Interact(PlayerInterno player)
    {
        if (currentSphere != null && player.carriedSphere == null)
        {
            player.carriedSphere = currentSphere;
            currentSphere.gameObject.SetActive(false);
            currentSphere.isHeld = true;
            currentSphere = null;
        }
        else if (currentSphere == null && player.carriedSphere != null)
        {
            player.carriedSphere.transform.position = transform.position + Vector3.up * 0.5f;
            player.carriedSphere.gameObject.SetActive(true);
            player.carriedSphere.isHeld = false;
            currentSphere = player.carriedSphere;
            player.carriedSphere = null;
        }
    }
}
