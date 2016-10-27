using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FadeManager : MonoBehaviour {
    [SerializeField]
    private Image image;
    [SerializeField]
    private Text text;
    [SerializeField]
    private GameController gameController;
    [SerializeField]
    private float fadeSpeed;
    public bool actived;
    //bool startGame;

    void Start ()
    {
        actived = false;
        //startGame = true;
    }
	
	void Update ()
    {
	   /* if(gameController.night)
        {
            text.text = "Etapa 2";
            if (image.color.a >= 0.95f)
            {
                actived = true;
            }
            if(actived)
                FadeToClear();
            else FadeToBlack();
        }*/
    }
  
    void FadeToClear()
    {
        image.color = Color.Lerp(image.color, Color.clear, fadeSpeed * Time.deltaTime);
        text.color = Color.Lerp(text.color, Color.clear, fadeSpeed * Time.deltaTime);
        if (image.color.a <= 0.05f)
        {
            image.color = Color.clear;
            image.enabled = false;
            text.color = Color.clear;
            text.enabled = false;
            gameController.fade = false;
        }

    }
    void FadeToBlack()
    {
        image.enabled = true;
        text.enabled = true;
        image.color = Color.Lerp(image.color, Color.black, fadeSpeed * Time.deltaTime);
        text.color = Color.Lerp(text.color, Color.red, fadeSpeed * Time.deltaTime);
        gameController.fade = true;

    }

}
