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
    private GameObject ballon;
    private Text textBox;
    private int actual;
    // Use this for initialization
    void Start ()
    {
        textBox = ballon.GetComponentInChildren<Text>();
        actual = 0;
        ActualizeTutorial();

    }
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetMouseButtonUp(0))
        {
            if(actual < texts.Length - 1)
                actual++;
            ActualizeTutorial();

        }

    }
    void ActualizeTutorial()
    {
        textBox.text = texts[actual];
        myImage.sprite = sprites[poses[actual]];
    }
}
