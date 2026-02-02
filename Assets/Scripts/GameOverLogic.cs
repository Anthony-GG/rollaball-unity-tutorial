using System.Threading.Tasks;
using Unity.VectorGraphics;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameOverLogic : MonoBehaviour

{

    private int i = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        WaitSeconds(8);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    async void WaitSeconds(int seconds)
    {
        int ticks = seconds * 1000;
        await Task.Delay(ticks);
        SceneManager.LoadScene("MiniGame");
    }

}
