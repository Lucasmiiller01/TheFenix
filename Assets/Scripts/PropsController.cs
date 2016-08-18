using UnityEngine;
using System.Collections;

public class PropsController : MonoBehaviour {

    public string myType;
    [SerializeField]
    private GameController gameController;
    [SerializeField]
    private Sprite[] sprites;
    [SerializeField]
    private GameObject[] balloon;
    [SerializeField]
    public int nBallons;
    public float decreaseValue;
    void Start()
    {
        InvokeRepeating("OnActivedBallon", 3f, 8f);
    }
    public void OnActivedBallon()
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
 

    void Update ()
    {
        switch (myType)
        {
            case "Hospital":
                if (gameController.props.x >= 80 && this.GetComponent<SpriteRenderer>().sprite != sprites[0])
                    this.GetComponent<SpriteRenderer>().sprite = sprites[0];
                else if(this.GetComponent<SpriteRenderer>().sprite != sprites[0] && gameController.props.x <= 80 && gameController.props.x >= 60)
                    this.GetComponent<SpriteRenderer>().sprite = sprites[0];
                else if(this.GetComponent<SpriteRenderer>().sprite != sprites[1] && gameController.props.x < 60 && gameController.props.x >= 30)
                    this.GetComponent<SpriteRenderer>().sprite = sprites[1];
                else if(this.GetComponent<SpriteRenderer>().sprite != sprites[2] && gameController.props.x < 30)
                {
                    this.GetComponent<SpriteRenderer>().sprite = sprites[2];
                }
                break;
            case "School":
                if (gameController.props.y >= 80 && this.GetComponent<SpriteRenderer>().sprite != sprites[3])
                    this.GetComponent<SpriteRenderer>().sprite = sprites[3];
                else if (this.GetComponent<SpriteRenderer>().sprite != sprites[3] && gameController.props.y <= 80 && gameController.props.y >= 60)
                    this.GetComponent<SpriteRenderer>().sprite = sprites[3];
                else if (this.GetComponent<SpriteRenderer>().sprite != sprites[4] && gameController.props.y < 60 && gameController.props.y >= 30)
                    this.GetComponent<SpriteRenderer>().sprite = sprites[4];
                else if(this.GetComponent<SpriteRenderer>().sprite != sprites[5] && gameController.props.y < 30)
                {
                    this.GetComponent<SpriteRenderer>().sprite = sprites[5];
                }
                break;
            case "Police":
                if (gameController.props.z >= 80 && this.GetComponent<SpriteRenderer>().sprite != sprites[6])
                    this.GetComponent<SpriteRenderer>().sprite = sprites[6];
                else if (this.GetComponent<SpriteRenderer>().sprite != sprites[6] && gameController.props.z <= 80 && gameController.props.z >= 60)
                    this.GetComponent<SpriteRenderer>().sprite = sprites[6];
                else if (this.GetComponent<SpriteRenderer>().sprite != sprites[7] && gameController.props.z < 60 && gameController.props.z >= 30)
                    this.GetComponent<SpriteRenderer>().sprite = sprites[7];
                else if(this.GetComponent<SpriteRenderer>().sprite != sprites[8] && gameController.props.z < 30)
                {
                    this.GetComponent<SpriteRenderer>().sprite = sprites[8];
                }
                break;
        }

    }
}
