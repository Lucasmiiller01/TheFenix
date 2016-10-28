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
    private Tutorial tutorial_;
    [SerializeField]
    private string myType;
    [SerializeField]
    private GameObject ballon;

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
                    if (gameController.props.y > 4) gameController.props.y--;
                    if (gameController.props.z > 4) gameController.props.z--;
                    bars[1].DecDesactive();
                    bars[2].DecDesactive();
                    tutorial.ChangeFace(false);
                }
                break;
            case "School":
                if (gameController.props.y < 8)
                {
                    gameController.props.y++;
                    if(Tutorial.inTuto)
                        gameController.props.y+=5;

                    bars[1].PosDesactive();
                    tutorial.ChangeFace(true);
                }
                else
                {
                    if (gameController.props.x > 4) gameController.props.x--;
                    if (gameController.props.z > 4) gameController.props.z--;
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
                    if (gameController.props.x > 4) gameController.props.x--;
                    if(gameController.props.y > 4) gameController.props.y--;
                    bars[0].DecDesactive();
                    bars[1].DecDesactive();
                    tutorial.ChangeFace(false);
                }
                break;
        }

        if (totalMoney <= 0 || gameController.props.z > 7 && gameController.props.x > 7 && gameController.props.y > 7)
        {
            if (gameController.GetEtapa().Equals(0))
            {
                Invoke("ExtraKill", 1f);

            }
            else
            {
                Camera.main.GetComponent<Animator>().SetBool("back", false);
                Invoke("Ballon", 1f);
            }
        }
    }
    void ExtraKill()
    {
        tutorial_.CompleteBag();
    }
    void Ballon()
    {
        ballon.SetActive(true);
        tutorial.ChangeFinal(gameController.props);
    }

}
