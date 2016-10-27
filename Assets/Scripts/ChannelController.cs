using UnityEngine;
using System.Collections;

public class ChannelController : MonoBehaviour {

    [SerializeField]
    private GameObject[] channels;
    private int actualChannel;

    void Start()
    {
        actualChannel = 1;
        Invoke("NewChannel", 0.2f);
    }

    void ChannelStatic()
    {
        channels[0].SetActive(true);
        channels[actualChannel].SetActive(false);
        actualChannel++;
        if (actualChannel >= channels.Length)
            actualChannel = 1;
        Invoke("NewChannel", 0.3f);
    }
    void NewChannel()
    {
        channels[actualChannel].SetActive(true);
        channels[actualChannel].GetComponent<PropsController>().ChangeSprite();
        channels[0].SetActive(false);
        Invoke("ChannelStatic", 2f);
    }
}
