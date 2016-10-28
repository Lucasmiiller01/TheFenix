using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TutorialFirst : MonoBehaviour {

    [SerializeField]
    private Image myImage;
    [SerializeField]
    private Sprite[] sprites;

    public void ChangeFace(bool happy)
    {
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

}
