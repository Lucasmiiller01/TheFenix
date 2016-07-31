using UnityEngine;
using System.Collections;

public class SetaController : MonoBehaviour {

    [SerializeField]
    private string myType;
    [SerializeField]
    private GameController gameController;

    void Start()
    {
        InvokeRepeating("Actived", 0.2f, 0.2f);
    }
    void Update ()
    {
        switch (myType)
        {
            case "Hospital":
                if (gameController.props.x >= 6)
                {
                    this.GetComponent<SpriteRenderer>().flipY = false;
                }
                else
                {
                    this.GetComponent<SpriteRenderer>().color = Color.red;
                    this.GetComponent<SpriteRenderer>().flipY = true;
                }

                break;
            case "School":
                if (gameController.props.y >= 6)
                {
                   this.GetComponent<SpriteRenderer>().flipY = false;
                }
                else
                {
                    this.GetComponent<SpriteRenderer>().color = Color.red;
                    this.GetComponent<SpriteRenderer>().flipY = true;
                }
                break;
            case "Police":
                if (gameController.props.z >= 6)
                {
                    this.GetComponent<SpriteRenderer>().flipY = false;

                }
                else
                {
                    this.GetComponent<SpriteRenderer>().color = Color.red;
                    this.GetComponent<SpriteRenderer>().flipY = true;
                }
                break;
        }
    
    }

    private void Actived()
    {
        this.GetComponent<SpriteRenderer>().enabled = !this.GetComponent<SpriteRenderer>().enabled;
    }

}
