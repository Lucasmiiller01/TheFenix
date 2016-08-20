using UnityEngine;
using System.Collections;

public class ClockBehaviour : MonoBehaviour {

    public GameController gameController;
    public int Clock;
    public int velocidadeGame;
	void Start ()
    {
        InvokeRepeating("ClockTime", 2f, 2f);
        if (velocidadeGame.Equals(0)) velocidadeGame = 1;
    }
	
	
	void ClockTime()
    {
        if (velocidadeGame != 1 && velocidadeGame != 0) velocidadeGame = 5;
        if (!gameController.FinaleDay && !gameController.fade)
        {
            this.transform.Rotate(0, 0, -2.5f * velocidadeGame);
            Clock += 1 * velocidadeGame;
        }
        if(transform.rotation.eulerAngles.z >= 53 && transform.rotation.eulerAngles.z < 55)
        { gameController.FinaleDay = true; this.enabled = false; }

        if (transform.rotation.eulerAngles.z >= 241 && transform.rotation.eulerAngles.z < 245)
        {
            gameController.night = true;
            gameController.fade = true;
        }
    }
}
