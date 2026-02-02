using UnityEngine;
using UnityEngine.SceneManagement;
using System.Threading.Tasks;
using UnityEngine.UI;

public class EndScreenLogic : MonoBehaviour
{

    public RawImage congratsVideo;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameObject.SetActive(false);
        congratsVideo.gameObject.SetActive(false);
        WaitSeconds(3);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    async void WaitSeconds(int seconds)
    {
        int ticks = seconds * 1000;
        await Task.Delay(ticks);
        gameObject.SetActive(true);
        congratsVideo.gameObject.SetActive(true);
    }
}
