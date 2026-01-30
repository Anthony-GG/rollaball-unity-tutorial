using UnityEngine;

public class PickUpController : MonoBehaviour
{
    private void OnTriggerEnter(Collider obj)
    {
        if (!obj.CompareTag("Player")) return;

        gameObject.SetActive(false);
    }
}
