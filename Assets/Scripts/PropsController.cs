using UnityEngine;
using System.Collections;

public class PropsController : MonoBehaviour {

    public string myType;
    [SerializeField]
    private GameController gameController;
    [SerializeField]
    private Sprite[] sprites;
    [SerializeField]
    private Sprite[] spritesNight;
    [SerializeField]
    private GameObject[] balloon;
    [SerializeField]
    public int nBallons;
    public float decreaseValue;
    private bool actived;
    [SerializeField]
    private FadeManager fadeManager;
    void Start()
    {
        actived = false;
        //Turorial
    }
    public void OnActivedBallon()
    {
        if(!gameController.FinaleDay)
        {
            int random = Random.Range(0, 4);
            if (random.Equals(0))
            {
                int maxB = Random.Range(1, 3);
                for (int i = 0; i < maxB + nBallons; i++)
                {
                    if (balloon[i] != null && !balloon[i].activeSelf)
                    {
                        balloon[i].SetActive(true);
                    }
                }
                decreaseValue = (nBallons + maxB);
                nBallons = maxB;
            }
        }
    }
 

    void Update ()
    {
        if (!gameController.FinaleDay)
        {
            if(gameController.night && !actived)
            {
                InvokeRepeating("OnActivedBallon", 4f, 8f);
                actived = true;
            }
           
            switch (myType)
            {
                case "Hospital":
                    if (gameController.props.x >= 80)
                    {
                        if(!gameController.night && this.GetComponent<SpriteRenderer>().sprite == spritesNight[1]) this.GetComponent<SpriteRenderer>().sprite = sprites[0];
                        else if(gameController.night && fadeManager.actived) this.GetComponent<SpriteRenderer>().sprite = spritesNight[1];
                        if (this.GetComponent<Animator>().enabled) this.GetComponent<Animator>().enabled = false;
                    }
                    else if  (gameController.props.x <= 80 && gameController.props.x >= 60)
                    {
                        if (!gameController.night && this.GetComponent<SpriteRenderer>().sprite == spritesNight[1]) this.GetComponent<SpriteRenderer>().sprite = sprites[0];
                        else if(gameController.night && fadeManager.actived) this.GetComponent<SpriteRenderer>().sprite = spritesNight[1];
                        if (this.GetComponent<Animator>().enabled) this.GetComponent<Animator>().enabled = false;
                    }
                    else if (gameController.props.x < 60 && gameController.props.x >= 30)
                    {
                        if (!gameController.night)
                        {
                            this.GetComponent<SpriteRenderer>().sprite = sprites[1];
                            if (this.GetComponent<Animator>().enabled) this.GetComponent<Animator>().enabled = false;
                        }
                        else if (gameController.night && fadeManager.actived)
                        {
                            this.GetComponent<SpriteRenderer>().sprite = spritesNight[4];
                            if (!this.GetComponent<Animator>().enabled) this.GetComponent<Animator>().enabled = true;
                        }
                    }
           
                    else if (gameController.props.x < 30)
                    {
                        if (!gameController.night && this.GetComponent<SpriteRenderer>().sprite == spritesNight[8]) this.GetComponent<SpriteRenderer>().sprite = sprites[2];
                        else if(gameController.night && fadeManager.actived) this.GetComponent<SpriteRenderer>().sprite = spritesNight[8];
                        if (this.GetComponent<Animator>().enabled) this.GetComponent<Animator>().enabled = false;
                    }
                    break;
                case "School":
                    if (gameController.props.y >= 80)
                    {
                        if (!gameController.night && this.GetComponent<SpriteRenderer>().sprite == spritesNight[0]) this.GetComponent<SpriteRenderer>().sprite = sprites[3];
                        else if(gameController.night && fadeManager.actived) this.GetComponent<SpriteRenderer>().sprite = spritesNight[0];
                        if (this.GetComponent<Animator>().enabled) this.GetComponent<Animator>().enabled = false;
                    }
                    else if (gameController.props.y <= 80 && gameController.props.y >= 60)
                    {
                        if (!gameController.night && this.GetComponent<SpriteRenderer>().sprite == spritesNight[0]) this.GetComponent<SpriteRenderer>().sprite = sprites[3];
                        else if (gameController.night && fadeManager.actived) this.GetComponent<SpriteRenderer>().sprite = spritesNight[0];
                        if (this.GetComponent<Animator>().enabled) this.GetComponent<Animator>().enabled = false;

                    }
                    else if (gameController.props.y < 60 && gameController.props.y >= 30)
                    {
                        if (!gameController.night)
                        {
                            this.GetComponent<SpriteRenderer>().sprite = sprites[4];
                            if (this.GetComponent<Animator>().enabled) this.GetComponent<Animator>().enabled = false;
                        }
                        else if (gameController.night && fadeManager.actived)
                        {
                            this.GetComponent<SpriteRenderer>().sprite = spritesNight[3];
                            if (!this.GetComponent<Animator>().enabled) this.GetComponent<Animator>().enabled = true;
                        }
                    }
                    else if (gameController.props.y < 30)
                    {
                        if (!gameController.night && this.GetComponent<SpriteRenderer>().sprite == spritesNight[6]) this.GetComponent<SpriteRenderer>().sprite = sprites[5];
                        else if(gameController.night && fadeManager.actived) this.GetComponent<SpriteRenderer>().sprite = spritesNight[6];
                        if (this.GetComponent<Animator>().enabled) this.GetComponent<Animator>().enabled = false;
                    }
                  
                    break;
                case "Police":
                    if (gameController.props.z >= 80)
                    {
                        if (!gameController.night && this.GetComponent<SpriteRenderer>().sprite == spritesNight[2]) this.GetComponent<SpriteRenderer>().sprite = sprites[6];
                        else if(gameController.night && fadeManager.actived) this.GetComponent<SpriteRenderer>().sprite = spritesNight[2];
                        if (this.GetComponent<Animator>().enabled) this.GetComponent<Animator>().enabled = false;
                    }
                    else if (gameController.props.z <= 80 && gameController.props.z >= 60)
                    {
                        if (!gameController.night && this.GetComponent<SpriteRenderer>().sprite == spritesNight[2]) this.GetComponent<SpriteRenderer>().sprite = sprites[6];
                        else if (gameController.night && fadeManager.actived) this.GetComponent<SpriteRenderer>().sprite = spritesNight[2];
                    }
                    else if (gameController.props.z < 60 && gameController.props.z >= 30)
                    {
                        if (!gameController.night)
                        {
                            this.GetComponent<SpriteRenderer>().sprite = sprites[7];
                            if (this.GetComponent<Animator>().enabled) this.GetComponent<Animator>().enabled = false;
                        }
                        else if (gameController.night && fadeManager.actived)
                        {
                            this.GetComponent<SpriteRenderer>().sprite = spritesNight[5];
                            if (!this.GetComponent<Animator>().enabled) this.GetComponent<Animator>().enabled = true;
                        }
                    }
                    else if (gameController.props.z < 30)
                    {
                        if (!gameController.night && this.GetComponent<SpriteRenderer>().sprite == spritesNight[7]) this.GetComponent<SpriteRenderer>().sprite = sprites[8];
                        else if(gameController.night && fadeManager.actived) this.GetComponent<SpriteRenderer>().sprite = spritesNight[7];
                        if (this.GetComponent<Animator>().enabled) this.GetComponent<Animator>().enabled = false;
                    }
                    break;
            }

        }

    }
}
