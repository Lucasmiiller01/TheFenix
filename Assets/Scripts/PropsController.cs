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
    [SerializeField]
    private GameObject protest;
    void Start()
    {
        actived = false;
    }
 

    public void ChangeSprite ()
    {
     
            switch (myType)
            {
                case "Hospital":
                    if (gameController.props.x >= 8)
                    {
                        if (this.GetComponent<SpriteRenderer>().sprite != sprites[0]) this.GetComponent<SpriteRenderer>().sprite = sprites[0];
                        if (this.GetComponent<Animator>().enabled) this.GetComponent<Animator>().enabled = false;
                        if (protest.activeSelf) protest.SetActive(false);
                    }
                    else if (gameController.props.x < 8 && gameController.props.x >= 6)
                    {
                        if (this.GetComponent<SpriteRenderer>().sprite != sprites[1]) this.GetComponent<SpriteRenderer>().sprite = sprites[1];
                  
                        if (this.GetComponent<Animator>().enabled) this.GetComponent<Animator>().enabled = false;
                        if (protest.activeSelf) protest.SetActive(false);
                    }
                    else if (gameController.props.x < 6)
                    {
                       
                            this.GetComponent<SpriteRenderer>().sprite = sprites[2];
                            if (this.GetComponent<Animator>().enabled) this.GetComponent<Animator>().enabled = false;
                       
                            if (!protest.activeSelf) protest.SetActive(true);
  
                    }
                    break;
                case "School":
                    if (gameController.props.y >= 8)
                    {
                        if (this.GetComponent<SpriteRenderer>().sprite != sprites[3]) this.GetComponent<SpriteRenderer>().sprite = sprites[3];
                        if (this.GetComponent<Animator>().enabled) this.GetComponent<Animator>().enabled = false;
                        if (protest.activeSelf) protest.SetActive(false);
                    }
                    else if (gameController.props.y < 8 && gameController.props.y >= 6)
                    {
                        if (this.GetComponent<SpriteRenderer>().sprite != sprites[4]) this.GetComponent<SpriteRenderer>().sprite = sprites[4];
                      
                        if (this.GetComponent<Animator>().enabled) this.GetComponent<Animator>().enabled = false;
                        if (protest.activeSelf) protest.SetActive(false);

                    }
                    else if (gameController.props.y < 6)
                    {
                        
                            this.GetComponent<SpriteRenderer>().sprite = sprites[5];
                            if (this.GetComponent<Animator>().enabled) this.GetComponent<Animator>().enabled = false;
                            if (!protest.activeSelf) protest.SetActive(true);
                    }
                  
                    break;
                case "Police":
                    if (gameController.props.z >= 8)
                    {
                        if (this.GetComponent<SpriteRenderer>().sprite != sprites[6]) this.GetComponent<SpriteRenderer>().sprite = sprites[6];
                      
                        if (this.GetComponent<Animator>().enabled) this.GetComponent<Animator>().enabled = false;
                        if (protest.activeSelf) protest.SetActive(false);
                    }
                    else if (gameController.props.z <= 8 && gameController.props.z >= 6)
                    {
                        if (this.GetComponent<SpriteRenderer>().sprite != sprites[7]) this.GetComponent<SpriteRenderer>().sprite = sprites[7];
                      
                        if (protest.activeSelf) protest.SetActive(false);
                    }
                    else if (gameController.props.z < 6)
                    {
                            this.GetComponent<SpriteRenderer>().sprite = sprites[8];
                            if (this.GetComponent<Animator>().enabled) this.GetComponent<Animator>().enabled = false;
                            if (!protest.activeSelf) protest.SetActive(true);

                    }
                    break;
            }
    }
}
