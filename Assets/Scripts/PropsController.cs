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
        InvokeRepeating("OnActivedBallon", 2f, 5f);
    }
    public void OnActivedBallon()
    {
        int random = Random.Range(0, 4);
        if (random.Equals(1))
        {
            int maxB = Random.Range(1, 3);
            for (int i = 0; i < maxB + nBallons; i++)
            {
                if (balloon[i] != null && !balloon[i].activeSelf)
                {
                    balloon[i].SetActive(true);
                }
            }
            decreaseValue = (nBallons + maxB) * 0.1f;
            nBallons = maxB;
        }

    }
 

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
