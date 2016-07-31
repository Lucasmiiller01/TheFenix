using UnityEngine;
using System.Collections;

public class PropsController : MonoBehaviour {

    [SerializeField]
    private string myType;
    [SerializeField]
    private GameController gameController;
    [SerializeField]
    private Sprite[] sprites;

	void Update ()
    {
        switch (myType)
        {
            case "Hospital":
                if (gameController.props.x >= 8 && this.GetComponent<SpriteRenderer>().sprite != sprites[0])
                    this.GetComponent<SpriteRenderer>().sprite = sprites[0];
                else if(this.GetComponent<SpriteRenderer>().sprite != sprites[0] && gameController.props.x <= 8 && gameController.props.x >= 6)
                    this.GetComponent<SpriteRenderer>().sprite = sprites[0];
                else if(this.GetComponent<SpriteRenderer>().sprite != sprites[1] && gameController.props.x < 6 && gameController.props.x >= 3)
                    this.GetComponent<SpriteRenderer>().sprite = sprites[1];
                else if(this.GetComponent<SpriteRenderer>().sprite != sprites[2] && gameController.props.x < 3)
                {
                    this.GetComponent<SpriteRenderer>().sprite = sprites[2];
                }
                break;
            case "School":
                if (gameController.props.y >= 8 && this.GetComponent<SpriteRenderer>().sprite != sprites[3])
                    this.GetComponent<SpriteRenderer>().sprite = sprites[3];
                else if (this.GetComponent<SpriteRenderer>().sprite != sprites[3] && gameController.props.y <= 8 && gameController.props.y >= 6)
                    this.GetComponent<SpriteRenderer>().sprite = sprites[3];
                else if (this.GetComponent<SpriteRenderer>().sprite != sprites[4] && gameController.props.y < 6 && gameController.props.y >= 3)
                    this.GetComponent<SpriteRenderer>().sprite = sprites[4];
                else if(this.GetComponent<SpriteRenderer>().sprite != sprites[5] && gameController.props.y < 3)
                {
                    this.GetComponent<SpriteRenderer>().sprite = sprites[5];
                }
                break;
            case "Police":
                if (gameController.props.z >= 8 && this.GetComponent<SpriteRenderer>().sprite != sprites[6])
                    this.GetComponent<SpriteRenderer>().sprite = sprites[6];
                else if (this.GetComponent<SpriteRenderer>().sprite != sprites[6] && gameController.props.z <= 8 && gameController.props.z >= 6)
                    this.GetComponent<SpriteRenderer>().sprite = sprites[6];
                else if (this.GetComponent<SpriteRenderer>().sprite != sprites[7] && gameController.props.z < 6 && gameController.props.z >= 3)
                    this.GetComponent<SpriteRenderer>().sprite = sprites[7];
                else if(this.GetComponent<SpriteRenderer>().sprite != sprites[8] && gameController.props.z < 3)
                {
                    this.GetComponent<SpriteRenderer>().sprite = sprites[8];
                }
                break;
        }

    }
}
