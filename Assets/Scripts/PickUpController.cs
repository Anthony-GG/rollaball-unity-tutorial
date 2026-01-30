using System.Threading;
using Unity.VisualScripting;
using UnityEngine;
using TMPro; //for text updates

public class PickUpController : MonoBehaviour
{
    private void OnTriggerEnter(Collider obj)
    {
        if (!obj.CompareTag("Player")) return; //checks to make sure it's only the player that can interact
        gameObject.SetActive(false); //makes pickup object vanish
    }

    //void SetCountText()
    //{
    //    countText.text = "Count: " + count.ToString();
    //}

}
