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
    [SerializeField]
    private GameController gameController;
    private int actual;
    private int actualText;
    public static bool inTuto = true;
    [SerializeField]
    private byte[] quests;
    float media;
    // Use this for initialization
    void Start ()
    {
        actual = 0;
        actualText = 0;
        quests = new byte[2];
        ballons[0].SetActive(true);
        textBox[0].text = texts[0];
        ActualizeTutorial();

    }
	
	// Update is called once per frame
	void Update ()
    {
        if (!inTuto)
        {
            media = (gameController.props.x + gameController.props.y + gameController.props.z) / 3;
            if (media >= 8 && myImage.sprite != sprites[2])
                myImage.sprite = sprites[2];
            else if (myImage.sprite != sprites[2] && media <= 8 && media >= 6)
                myImage.sprite = sprites[2];
            else if (myImage.sprite != sprites[0] && media < 6 && media >= 3)
                myImage.sprite = sprites[0];
            else if (myImage.sprite != sprites[1] && media < 3)
                myImage.sprite = sprites[1];
        }
        else
        {
            if (Input.GetMouseButtonUp(0))
            {
                if (actual.Equals(6))
                {
                    ballons[4].SetActive(true);
                    ballons[3].SetActive(false);
                    actualText = 4;
                    ActualizeTutorial();
                    actual++;
                }
                if (actual < 3)
                {
                    actual++;
                    if (actual.Equals(3))
                    {
                        ballons[0].SetActive(false);
                        ballons[2].SetActive(true);
                        myImage.sprite = sprites[2];
                    }
                    ActualizeTutorial();
                }
                else if(actual > 3 && actual < 6)
                {
                    ActualizeTutorial();
                    actual++;
                }
                if(actual.Equals(7))
                {
                    Camera.main.GetComponent<Animator>().SetBool("back", false);
                }

            }
        }

    }
    public void CompleteBag()
    {
        ballons[3].SetActive(true);
        ballons[2].SetActive(false);
        actualText = 3;
        ActualizeTutorial();
        actual = 4;
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
