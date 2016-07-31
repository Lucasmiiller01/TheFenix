using UnityEngine;
using System.Collections;

public class SetaController : MonoBehaviour {

    [SerializeField]
    private string myType;
    [SerializeField]
    private GameController gameController;

    void Start ()
    {
        switch (myType)
        {
            case "Hospital":
                if (gameController.props.x >= 6)
                {
                    Debug.Log("Good Hospital");

                }
                else this.GetComponent<SpriteRenderer>().color = Color.red;

                break;
            case "School":
                if (gameController.props.y >= 6)
                {
                    Debug.Log("Good School");

                }
                else this.GetComponent<SpriteRenderer>().color = Color.red;
                break;
            case "Police":
                if (gameController.props.z >= 6)
                {
                    Debug.Log("Good Police");

                }
                else this.GetComponent<SpriteRenderer>().color = Color.red;
                break;
        }

    }
	
	
	void Update () {
	
	}
}
