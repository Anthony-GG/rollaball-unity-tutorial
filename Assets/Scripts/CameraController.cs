using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player; //the player object
    private Vector3 offset; //distance from player to camera


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        offset = transform.position - player.transform.position; //offset is calculated by using the current position of the camera minus the player position
    }

    // Update is called once per frame
    void LateUpdate() //late update does the frame update as the last action in the stack
    {
        transform.position = player.transform.position + offset; //transform is calculated using the offset distance plus the current player position
    }
}
