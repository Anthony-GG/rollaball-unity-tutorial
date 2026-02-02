using UnityEngine;
using System.Threading.Tasks;

public class PartyBlowerLogic : MonoBehaviour
{
    public GameObject blower1;
    public GameObject blower2;
    public GameObject blower3;
    public GameObject blower4;
    public GameObject blower5;

    public AudioSource blower1_audio;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        blower1.SetActive(false);
        blower2.SetActive(false);
        blower3.SetActive(false);
        blower4.SetActive(false);
        blower5.SetActive(false);

        WaitSeconds(1.5, blower1);
        WaitSeconds(3.5, blower2);
        WaitSeconds(4, blower3);
        WaitSeconds(4.5, blower4);
        WaitSeconds(5, blower5);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    async void WaitSeconds(double seconds, GameObject obj)
    {
        int ticks = (int)(seconds * 1000);
        await Task.Delay(ticks);
        gameObject.SetActive(true);
        AudioSource audio = obj.GetComponent<AudioSource>();
        audio.pitch = Random.Range(1.2f, 2.0f);
        obj.gameObject.SetActive(true);
    }
}
