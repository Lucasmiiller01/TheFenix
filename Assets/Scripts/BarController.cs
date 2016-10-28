using UnityEngine;
using System.Collections;

public class BarController : MonoBehaviour {

    [SerializeField]
    private Sprite[] sprites;
    [SerializeField]
    private GameController gameController;
    [SerializeField]
    private GameObject childP;
    [SerializeField]
    private GameObject childD;
    public string myType;
    void Update()
    {
        ChangeSprite();
    }
    public void PosDesactive()
    {
        childP.SetActive(false);
        Invoke("PosActive", 0.001f);
    }
    void PosActive()
    {
        childP.SetActive(true);
    }

    public void DecDesactive()
    {
        childD.SetActive(false);
        Invoke("DecActive", 0.001f);
    }
    void DecActive()
    {
        childD.SetActive(true);
    }
    public void ChangeSprite()
    {
        switch (myType)
        {
            case "Hospital":
                if (gameController.props.x > 7)
                {
                    this.GetComponent<SpriteRenderer>().sprite = sprites[4];
                }
                else if (gameController.props.x > 6)
                {
                    this.GetComponent<SpriteRenderer>().sprite = sprites[3];

                }
                else if (gameController.props.x > 5)
                {
                    this.GetComponent<SpriteRenderer>().sprite = sprites[2];
                }

                else if (gameController.props.x > 4)
                {
                    this.GetComponent<SpriteRenderer>().sprite = sprites[1];
             
                }
                else if (gameController.props.x > 3)
                {
                    this.GetComponent<SpriteRenderer>().sprite = sprites[0];
                }
                break;
            case "School":
                if (gameController.props.y > 7)
                {
                    this.GetComponent<SpriteRenderer>().sprite = sprites[4];
                }
                else if (gameController.props.y > 6)
                {
                    this.GetComponent<SpriteRenderer>().sprite = sprites[3];

                }
                else if (gameController.props.y > 5)
                {
                    this.GetComponent<SpriteRenderer>().sprite = sprites[2];
                }

                else if (gameController.props.y > 4)
                {
                    this.GetComponent<SpriteRenderer>().sprite = sprites[1];

                }
                else if (gameController.props.y > 3)
                {
                    this.GetComponent<SpriteRenderer>().sprite = sprites[0];
                }

                break;
            case "Police":
                if (gameController.props.z > 7)
                {
                    this.GetComponent<SpriteRenderer>().sprite = sprites[4];
                }
                else if (gameController.props.z > 6)
                {
                    this.GetComponent<SpriteRenderer>().sprite = sprites[3];

                }
                else if (gameController.props.z > 5)
                {
                    this.GetComponent<SpriteRenderer>().sprite = sprites[2];
                }

                else if (gameController.props.z > 4)
                {
                    this.GetComponent<SpriteRenderer>().sprite = sprites[1];

                }
                else if (gameController.props.z > 3)
                {
                    this.GetComponent<SpriteRenderer>().sprite = sprites[0];
                }
                break;
        }
    }

}
