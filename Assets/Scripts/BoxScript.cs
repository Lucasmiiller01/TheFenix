using UnityEngine;
using System.Collections;

public class BoxScript : MonoBehaviour {

    [SerializeField]
    private GameObject[] money;
    [SerializeField]
    private BarController[] bars;
    [SerializeField]
    private GameController gameController;
    [SerializeField]
    private TutorialFirst tutorial;
    [SerializeField]
    private string myType;

    private int myMoney;
    public static int totalMoney;

    void Start()
    {
        myMoney = 0;
        totalMoney = 7;
    }

    public void SumMoney()
    {
        money[myMoney].SetActive(true);
        myMoney++;
        totalMoney--;
        switch (myType)
        {
            case "Hospital":
                if (gameController.props.x < 8)
                {
                    gameController.props.x++;
                    bars[0].PosDesactive();
                    tutorial.ChangeFace(true);
                }
                else
                {
                    gameController.props.y--;
                    gameController.props.z--;
                    bars[1].DecDesactive();
                    bars[2].DecDesactive();
                    tutorial.ChangeFace(false);
                }
                break;
            case "School":
                if (gameController.props.y < 8)
                {
                    gameController.props.y++;
                    bars[1].PosDesactive();
                    tutorial.ChangeFace(true);
                }
                else
                {
                    gameController.props.x--;
                    gameController.props.z--;
                    bars[0].DecDesactive();
                    bars[2].DecDesactive();
                    tutorial.ChangeFace(false);
                }
                break;
            case "Police":
                if (gameController.props.z < 8)
                {
                    gameController.props.z++;
                    bars[2].PosDesactive();
                    tutorial.ChangeFace(true);
                }
                else
                {
                    gameController.props.x--;
                    gameController.props.y--;
                    bars[0].DecDesactive();
                    bars[1].DecDesactive();
                    tutorial.ChangeFace(false);
                }
                break;
        }

        if (totalMoney <= 0 || gameController.props.z > 7 && gameController.props.x > 7 && gameController.props.y > 7)
            Camera.main.GetComponent<Animator>().enabled = true;
    }

}
