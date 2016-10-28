using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TutorialFirst : MonoBehaviour {

    [SerializeField]
    private Image myImage;
    [SerializeField]
    private Sprite[] sprites;
    [SerializeField]
    private Text tut;
    [SerializeField]
    private GameObject nextLv;
    [SerializeField]
    private GameController gc;
    [SerializeField]
    private string[] tutTexts;

    public void ChangeFace(bool happy)
    {
        CancelInvoke();
        if (happy)
            myImage.sprite = sprites[Random.Range(1, 3)];
        else
            myImage.sprite = sprites[Random.Range(3, 5)];

        Invoke("BackFace", 1f);
    }
    void BackFace()
    {
        myImage.sprite = sprites[0];
    }
    public void ChangeFinal(Vector3 props)
    {
        if (props.z > 7 && props.x > 7 && props.y > 7)
        {
            myImage.sprite = sprites[2];
            tut.text = tutTexts[0];
            if(gc.GetEtapa().Equals(2))
                tut.text = tutTexts[4];
            nextLv.SetActive(true);
        }
        else if (props.z > 6 && props.x > 6 && props.y > 6)
        {
            myImage.sprite = sprites[1];
            tut.text = tutTexts[1];
            if (gc.GetEtapa().Equals(2))
                tut.text = tutTexts[5];
            nextLv.SetActive(true);
        }
        else if (props.z > 4 && props.x > 4 && props.y > 4)
        {
            myImage.sprite = sprites[0];
            tut.text = tutTexts[2];
            nextLv.SetActive(true);
            if (gc.GetEtapa().Equals(2))
            {
                tut.text = tutTexts[6];
                nextLv.SetActive(false);
            }
        }
        else
        {
            myImage.sprite = sprites[3];
            tut.text = tutTexts[3];
            if (gc.GetEtapa().Equals(2))
                tut.text = tutTexts[7];
            nextLv.SetActive(false);
        }
    }

}
