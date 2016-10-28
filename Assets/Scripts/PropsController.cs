﻿using UnityEngine;
using System.Collections;

public class PropsController : MonoBehaviour {

    public string myType;
    [SerializeField]
    private GameController gameController;
    [SerializeField]
    private Sprite[] sprites;
    [SerializeField]
    private Sprite[] spritesNight;
    [SerializeField]
    private GameObject[] balloon;
    [SerializeField]
    public int nBallons;
    public float decreaseValue;
    private bool actived;
    [SerializeField]
    private FadeManager fadeManager;
    [SerializeField]
    private GameObject protest;
    void Start()
    {
        actived = false;
        //Turorial
    }
    public void OnActivedBallon()
    {
        if(!gameController.FinaleDay)
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
    }
 

    public void ChangeSprite ()
    {
        /*if (!gameController.FinaleDay)
        {
            if(gameController.night && !actived)
            {
                InvokeRepeating("OnActivedBallon", 4f, 8f);
                actived = true;
            }*/
           
            switch (myType)
            {
                case "Hospital":
                    if (gameController.props.x >= 8)
                    {
                        if (this.GetComponent<SpriteRenderer>().sprite != sprites[0]) this.GetComponent<SpriteRenderer>().sprite = sprites[0];
                        if (this.GetComponent<Animator>().enabled) this.GetComponent<Animator>().enabled = false;
                        if (protest.activeSelf) protest.SetActive(false);
                    }
                    else if (gameController.props.x < 8 && gameController.props.x >= 6)
                    {
                        if (this.GetComponent<SpriteRenderer>().sprite != sprites[1]) this.GetComponent<SpriteRenderer>().sprite = sprites[1];
                  
                        if (this.GetComponent<Animator>().enabled) this.GetComponent<Animator>().enabled = false;
                        if (protest.activeSelf) protest.SetActive(false);
                    }
                    else if (gameController.props.x < 6)
                    {
                       
                            this.GetComponent<SpriteRenderer>().sprite = sprites[2];
                            if (this.GetComponent<Animator>().enabled) this.GetComponent<Animator>().enabled = false;
                       
                            if (!protest.activeSelf) protest.SetActive(true);
  
                    }
                    break;
                case "School":
                    if (gameController.props.y >= 8)
                    {
                        if (this.GetComponent<SpriteRenderer>().sprite != sprites[3]) this.GetComponent<SpriteRenderer>().sprite = sprites[3];
                        if (this.GetComponent<Animator>().enabled) this.GetComponent<Animator>().enabled = false;
                        if (protest.activeSelf) protest.SetActive(false);
                    }
                    else if (gameController.props.y < 8 && gameController.props.y >= 6)
                    {
                        if (this.GetComponent<SpriteRenderer>().sprite != sprites[4]) this.GetComponent<SpriteRenderer>().sprite = sprites[4];
                      
                        if (this.GetComponent<Animator>().enabled) this.GetComponent<Animator>().enabled = false;
                        if (protest.activeSelf) protest.SetActive(false);

                    }
                    else if (gameController.props.y < 6)
                    {
                        
                            this.GetComponent<SpriteRenderer>().sprite = sprites[5];
                            if (this.GetComponent<Animator>().enabled) this.GetComponent<Animator>().enabled = false;
                            if (!protest.activeSelf) protest.SetActive(true);
                    }
                  
                    break;
                case "Police":
                    if (gameController.props.z >= 8)
                    {
                        if (this.GetComponent<SpriteRenderer>().sprite != sprites[6]) this.GetComponent<SpriteRenderer>().sprite = sprites[6];
                      
                        if (this.GetComponent<Animator>().enabled) this.GetComponent<Animator>().enabled = false;
                        if (protest.activeSelf) protest.SetActive(false);
                    }
                    else if (gameController.props.z <= 8 && gameController.props.z >= 6)
                    {
                        if (this.GetComponent<SpriteRenderer>().sprite != sprites[7]) this.GetComponent<SpriteRenderer>().sprite = sprites[7];
                      
                        if (protest.activeSelf) protest.SetActive(false);
                    }
                    else if (gameController.props.z < 6)
                    {
                            this.GetComponent<SpriteRenderer>().sprite = sprites[8];
                            if (this.GetComponent<Animator>().enabled) this.GetComponent<Animator>().enabled = false;
                            if (!protest.activeSelf) protest.SetActive(true);

                    }
                    break;
            }
    }
}
