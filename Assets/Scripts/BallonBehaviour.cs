using UnityEngine;
using System.Collections;

public class BallonBehaviour : MonoBehaviour {
    [SerializeField]
    private GameController gameController;
    void OnMouseDown()
    {
        if (!gameController.FinaleDay && !gameController.fade)
        {
           if (this.GetComponentInParent<PropsController>().decreaseValue > 0 && this.gameObject.activeSelf) this.GetComponentInParent<PropsController>().decreaseValue -= 1f;
           if (this.GetComponentInParent<PropsController>().nBallons > 0 && this.gameObject.activeSelf) this.GetComponentInParent<PropsController>().nBallons -= 1;
           this.gameObject.SetActive(false);
        }
    }
}
