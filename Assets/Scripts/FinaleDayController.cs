using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FinaleDayController : MonoBehaviour {

    [SerializeField]
    private Text[] averages;
    [SerializeField]
    private Text message;
    [SerializeField]
    private GameController gameController;
    [SerializeField]
    private GameObject ScreenFinale;
    private float time;
    private int atualnumber;
    private int progress;
    public float mFinale;
    void Start () {
        progress = 1;

    }
	
	void Update ()
    {
	    if(gameController.FinaleDay)
        {
            if (mFinale.Equals(0)) mFinale = (gameController.props.x + gameController.props.y + gameController.props.z) / 3;
            ScreenFinale.SetActive(true);
            SumToMedia(int.Parse(gameController.props.x.ToString()), int.Parse(gameController.props.y.ToString()), int.Parse(gameController.props.z.ToString()), int.Parse(Mathf.Floor(mFinale).ToString()));
        }
    }
    void SumToMedia(int mHospital, int mSchool, int mPolice, int mFinale)
    {

        if (atualnumber < mHospital && atualnumber / (mHospital * (mHospital + 1 - atualnumber) - atualnumber) <= Time.fixedTime - time && progress.Equals(1))
        {
            time = Time.fixedTime;
            atualnumber++;
            averages[0].text = "Media Hospital:" + atualnumber.ToString() + "%";
        }
        else if(progress.Equals(1))
        {
            progress = 2;
            time = 0;
            atualnumber = 0;
        }

        if (atualnumber < mSchool && atualnumber / (mSchool * (mSchool + 1 - atualnumber) - atualnumber) <= Time.fixedTime - time && progress.Equals(2))
        {
            time = Time.fixedTime;
            atualnumber++;
            averages[1].text = "Media Escola:" + atualnumber.ToString() + "%";
        }
        else if(progress.Equals(2))
        {
            progress = 3;
            time = 0;
            atualnumber = 0;
        }

        if (atualnumber < mPolice && atualnumber / (mPolice * (mPolice + 1 - atualnumber) - atualnumber) <= Time.fixedTime - time && progress.Equals(3))
        {
            time = Time.fixedTime;
            atualnumber++;
            averages[2].text = "Media Policia:" + atualnumber.ToString() + "%";
        }
        else if (progress.Equals(3))
        {
            progress = 4;
            time = 0;
            atualnumber = 0;
        }

        if (atualnumber < mFinale && atualnumber / (mFinale * (mFinale + 1 - atualnumber) - atualnumber) <= Time.fixedTime - time && progress.Equals(4))
        {
            time = Time.fixedTime;
            atualnumber++;
            averages[3].text = "Media Final:" + atualnumber.ToString() + "%";
        }
        else if (progress.Equals(4))
        {
            progress = 5;
            time = 0;
            atualnumber = 0;
            MessageFeedBack(mFinale);
        }

    }
    void MessageFeedBack(float mFinale)
    {
        if (mFinale > 80)
        {
            message.text = "Perfect Media !";
        }
        else if (mFinale < 80 && mFinale > 60)
        {
            message.text = "Very Good Media !";
        }
        else if (mFinale < 60 && mFinale > 55)
        {
            message.text = " Good Media !";
        }
        else if (mFinale < 55)
        {
            message.text = " Bad Media !";
        }
    }



}
