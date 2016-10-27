using UnityEngine;
using System.Collections;

public class BoxScript : MonoBehaviour {

    [SerializeField]
    private GameObject[] money;

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
        if (totalMoney <= 0)
            print("HI");
    }

}
