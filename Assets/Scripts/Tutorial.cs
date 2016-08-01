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
    private int[] poses;
    [SerializeField]
    private GameObject[] ballons;
    [SerializeField]
    private Text[] textBox;
    private int actual;
    private int actualText;
    // Use this for initialization
    void Start ()
    {
        actual = 0;
        actualText = 1;
        ballons[2].SetActive(false);
        ActualizeTutorial();

    }
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetMouseButtonUp(0))
        {
            if (actual < 3)
            {
                actual++;
                ActualizeTutorial();
            }
            else
            {
                actual++;
                if (actual.Equals(4))
                {
                    ballons[1].SetActive(false);
                    ballons[2].SetActive(true);
                    myImage.sprite = sprites[2];
                    actualText = 2;
                }
                ActualizeTutorial();
            }
        }

    }
    void ActualizeTutorial()
    {
        textBox[actualText].text = texts[actual];
        myImage.sprite = sprites[poses[actual]];
    }
}
