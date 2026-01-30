using UnityEngine;

public class InvisiblePlaneController : MonoBehaviour
{
    private void OnTriggerEnter(Collider obj)
    {
        if (!obj.CompareTag("Player")) return; //looks for an object with a Player tag

        //sets the momentum back to zero
        Rigidbody rb = obj.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.linearVelocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }
        //sets the players location back to the beginning
        obj.transform.position = new Vector3(0.31687f, .5f, 0.31687f);
    }
}
