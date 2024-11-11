using UnityEngine;

public class DisappearOnClick : MonoBehaviour
{
    private void OnMouseDown()
    {
        // Deactivate the sphere or make it disappear
        gameObject.SetActive(false);
    }
}
