using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Tutorial : MonoBehaviour
{
    [SerializeField]
    private Image myImage;
    [SerializeField]
    private Sprite[] sprites;
    [SerializeField]
    private string[] texts;
    [SerializeField]
    private string[] textsAux;
    [SerializeField]
    private int[] poses;
    [SerializeField]
    private GameObject[] ballons;
    [SerializeField]
    private Text[] textBox;
    [SerializeField]
    private GameObject[] scenes;
    private int actual;
    private int actualText;
    private bool inTuto;
    private byte[] quests;
    // Use this for initialization
    void Start ()
    {
        actual = 0;
        inTuto = true;
        actualText = 1;
        quests = new byte[2];
        ballons[2].SetActive(false);
        textBox[0].text = textsAux[0];
        ActualizeTutorial();

    }
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetMouseButtonUp(0))
        {
            if (actual != 8 && quests[0] != 1 && inTuto)
            {
                actual++;
                if (actual.Equals(4))
                {
                    ballons[1].SetActive(false);
                    ballons[2].SetActive(true);
                    myImage.sprite = sprites[2];
                    actualText = 2;
                }
                else if (actual.Equals(8))
                {
                    textBox[0].text = textsAux[1];

                }
                else if (actual.Equals(10) && quests[1] != 2)
                {
                    ballons[1].SetActive(false);
                    ballons[2].SetActive(false);
                    actual--;
                    textBox[0].text = textsAux[2];
                    quests[1] = 1;

                }
                else if(actual.Equals(13))
                {
                    ballons[0].SetActive(false);
                    ballons[1].SetActive(false);
                    ballons[2].SetActive(false);
                    actual--; inTuto = false;

                }
                ActualizeTutorial();
            }

        }
        if (quests[0].Equals(1))
            quests[0] = 2;
        else if (quests[1].Equals(1) && Selector.quit)
        {
            quests[1] = 2;
            actual++;
            ballons[1].SetActive(true);
            textBox[0].text = textsAux[0];
            ActualizeTutorial();
        }

    }
    void ActualizeTutorial()
    {
        textBox[actualText].text = texts[actual];
        myImage.sprite = sprites[poses[actual]];
    }
    public void ChangeScene(string name)
    {
        if (!inTuto)
        {
            if (name.Equals("city"))
            {
                scenes[0].SetActive(true);
                scenes[1].SetActive(false);
            }
            else if (name.Equals("game"))
            {
                scenes[1].SetActive(true);
                scenes[0].SetActive(false);
            }
        }

        if (actual.Equals(8))
        {
            actual++;
            ballons[1].SetActive(true);
            ballons[2].SetActive(false);
            actualText = 1;
            textBox[0].text = textsAux[0];
            scenes[1].SetActive(true);
            scenes[0].SetActive(false);
            ActualizeTutorial();
            quests[0] = 1;
        }
    }
}
